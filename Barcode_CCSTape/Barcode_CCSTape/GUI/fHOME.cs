using ActUtlTypeLib;
using Barcode_CCSTape.DAL;
using Barcode_CCSTape.DTO;
using DmitryBrant.CustomControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Barcode_CCSTape.GUI
{
    public partial class fHOME : Form
    {
        #region Define Value
        readonly DataConnection _dtcnn = new DataConnection();
        public ActUtlType _plc = new ActUtlType();
        string _dataReceive1 = string.Empty;
        string _dataReceive2 = string.Empty;
        List<Tape_DTO> _tapeItems;
        DataTable _tbProdOfLot;
        DataTable _tbProdPass;
        bool _runMode;
        readonly bool _rsScan1 = false;
        readonly bool _rsScan2 = false;
        string _path;
        #endregion

        #region Contructor and Event Form 
        public fHOME()
        {
            InitializeComponent();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            currentTime.Start();
            _runMode = false;
            appConfig(sender, e);
            load_logDataConfig();
        }

        private void fHOME_FormClosing(object sender, FormClosingEventArgs e)
        {
            logData_Config();
            Properties.Settings.Default.Path = txtPath.Text;
            Properties.Settings.Default.Serial1_Name = serialPort1.PortName;
            Properties.Settings.Default.Serial1_Baudrate = serialPort1.BaudRate;
            Properties.Settings.Default.Serial1_Status = serialPort1.IsOpen;
            Properties.Settings.Default.Serial2_Name = serialPort2.PortName;
            Properties.Settings.Default.Serial2_Baudrate = serialPort2.BaudRate;
            Properties.Settings.Default.Serial2_Status = serialPort2.IsOpen;
            if (!string.IsNullOrEmpty(lblEquip_Name.Text))
            {
                Properties.Settings.Default.Equip_Name = lblEquip_Name.Text;
            }
            if (!string.IsNullOrEmpty(lblEquip_Description.Text))
            {
                Properties.Settings.Default.Equip_Description = lblEquip_Description.Text;
            }
            Properties.Settings.Default.Save();
        }

        private void CCSControl_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F1:
                    txtLOT_Scan.Focus();
                    break;
                case Keys.F2:
                    txtTape_Serial_Scan.Focus();
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    btnEquipment_Search_Click(sender, e);
                    break;
                case Keys.F6:
                    btnConnect_Scanner_Click(sender, e);
                    break;
                case Keys.F7:
                    btnExportText_Click(sender, e);
                    break;
                case Keys.F8:
                    btnExportExcel_Click(sender, e);
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    {
                        Application.Exit();
                        break;
                    }

            }
        }
        /// <summary>
        /// config for the program
        /// </summary>
        private void appConfig(object sender, EventArgs e)
        {
            try
            {
                btnSaveTapeInfo.Enabled = false;
                _tapeItems = new List<Tape_DTO>();

                _tbProdPass = new DataTable();
                _tbProdOfLot = new DataTable();

                txtPath.Text = Properties.Settings.Default.Path;
                _path = txtPath.Text + @"\DATA_CCS";

                if (Properties.Settings.Default.Serial1_Name != string.Empty)
                {
                    foreach (string item in SerialPort.GetPortNames())
                    {
                        if (item.ToUpper().Contains(Properties.Settings.Default.Serial1_Name))
                        {
                            serialPort1.PortName = Properties.Settings.Default.Serial1_Name;
                            serialPort1.BaudRate = Properties.Settings.Default.Serial1_Baudrate;
                            if (Properties.Settings.Default.Serial1_Status)
                            {
                                serialPort1.Open();
                            }
                        }
                    }
                }
                if (Properties.Settings.Default.Serial2_Name != string.Empty)
                {
                    foreach (string item in SerialPort.GetPortNames())
                    {
                        if (item.ToUpper().Contains(Properties.Settings.Default.Serial2_Name))
                        {
                            serialPort2.PortName = Properties.Settings.Default.Serial2_Name;
                            serialPort2.BaudRate = Properties.Settings.Default.Serial2_Baudrate;
                            if (Properties.Settings.Default.Serial2_Status)
                            {
                                serialPort2.Open();
                            }
                        }
                    }
                }
                //lblEquip_Name.Text = Properties.Settings.Default.Equip_Name;
                //lblEquip_Description.Text = Properties.Settings.Default.Equip_Description;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem with App Config!"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENT

        #region Timer
        /// <summary>
        /// real-time clock and component recognition
        /// </summary>
        private void currentTime_Tick(object sender, EventArgs e)
        {
            base.Invoke(new MethodInvoker(delegate ()
            {
                lblCurrent_Time.Text = DateTime.Now.ToString("HH:MM:ss");
                try
                {
                    int count = 0;
                    if (serialPort1.IsOpen) count++;
                    if (serialPort2.IsOpen) count++;
                    lblScanner_Status.Text = count.ToString() + " Scanner";
                    lblScanner_Status.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with the real-time!\n"
                        + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }
        /// <summary>
        /// real-time to comunication with PLC and RUN
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (readBitFromPLC("M251") == 1)
                {
                    timer1.Stop();
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write("\x16" + "T" + "\x0D");
                    }
                    if (serialPort2.IsOpen)
                    {
                        serialPort2.Write("\x16" + "T" + "\x0D");
                    }
                    writeBitToPLC("M261", 1);
                    DelayTime("M261", 0);
                    DelayCheckResult();

                    resetFlag();
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem with Timer!"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Button Event

        private void btnEquipment_Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (fEquipment frm = new fEquipment())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        lblEquip_Name.Text = frm._equipName;
                        lblEquip_Description.Text = frm._equipDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem with the Equipment selection process!\n"
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnConnectPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (_plc.Open() == -268435453)
                {
                    _plc.Close();
                    btnConnectPLC.BackColor = System.Drawing.SystemColors.ControlLightLight;
                    MessageBox.Show("Disconnect successful", "NOtification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblConnectPLC_Status.Text = "Disconnected";
                    lblConnectPLC_Status.ForeColor = Color.Black;
                    this.lblConnectPLC_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F,
                                         System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
                else
                {
                    _plc.ActLogicalStationNumber = 1;
                    _plc.Open();
                    if (_plc.Open() != -268435453)
                    {
                        MessageBox.Show("Can not connect to PLC!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_plc.Open() == -268435453)
                    {
                        timer1.Start();
                        //MessageBox.Show("Connect successfully", "NOtification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    lblConnectPLC_Status.Text = "Connected";
                    lblConnectPLC_Status.ForeColor = Color.Green;
                    this.lblConnectPLC_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F,
                                         System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem connecting to the PLC!\n"
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Scanner_Click(object sender, EventArgs e)
        {
            try
            {
                using (fConnectScanner frm = new fConnectScanner(serialPort1, serialPort2))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        serialPort1 = frm.scanner1;
                        serialPort2 = frm.scanner2;
                    }
                }
                if (serialPort1 != null && serialPort1.PortName != "COM1" && serialPort1.IsOpen == false)
                {
                    serialPort1.Open();
                    serialPort1.ReadTimeout = 1300;
                }
                if (serialPort2 != null && serialPort2.PortName != "COM1" && serialPort2.IsOpen == false)
                {
                    serialPort2.Open();
                    serialPort2.ReadTimeout = 1300;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem connecting to the scanner!\n"
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportText_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.Title = "Choose a Save Place";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "Text files (*.txt) | *.txt";
                saveFileDialog.FileName = DateTime.Now.ToString("ddMMyyyy") + "_" + lblTrayNum_Using.Text;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new TableHelper().WriteDataTableToTextFile(_tbProdPass, saveFileDialog.FileName);
                    MessageBox.Show("Successfully created Text file at \n " + saveFileDialog.FileName);
                    string fileOpen = saveFileDialog.FileName;
                    if (MessageBox.Show("Do you want to see the file you just save?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (File.Exists(fileOpen))
                        {
                            FileInfo fi = new FileInfo(fileOpen);
                            System.Diagnostics.Process.Start(fileOpen);
                        }
                        else
                        {
                            MessageBox.Show("File does not exist !", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem exporting the text file!\n"
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.Title = "Choose a Save Place";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "Excel files (*.xlsx) | *.xlsx";
                saveFileDialog.FileName = DateTime.Now.ToString("ddMMyyyy") + "_" + lblTrayNum_Using.Text;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Successfully created Excel file  \n " + saveFileDialog.FileName);
                    string fileOpen = saveFileDialog.FileName;
                    if (MessageBox.Show("Do you want to see the file you just save?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (File.Exists(fileOpen))
                        {
                            FileInfo fi = new FileInfo(fileOpen);
                            System.Diagnostics.Process.Start(fileOpen);
                        }
                        else
                        {
                            MessageBox.Show("File does not exist!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem exporting the excel file!\n"
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRunMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkRunMode_Conditons())
                {
                    _runMode = true;
                    btnRunMode.BackColor = Color.LawnGreen;
                    btnStop.BackColor = Color.DarkGray;
                    timer1.Start();
                    tableLayoutPanel_Input.Enabled = false;
                    btnManualCheck.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem turning ON run mode!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_runMode)
                {
                    timer1.Stop();
                    _runMode = false;
                    btnRunMode.BackColor = Color.DarkGray;
                    btnStop.BackColor = Color.Red;
                    tableLayoutPanel_Input.Enabled = true;
                    txtProd01_Scan.ReadOnly = false;
                    txtProd02_Scan.ReadOnly = false;
                    btnManualCheck.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem turning OFF run mode!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit program?", "CONFIRM", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLOT_Check_Click(object sender, EventArgs e)
        {
            if (txtLOT_Scan.Text == string.Empty)
            {
                return;
            }
            else
            {
                checkLOTDB(txtLOT_Scan.Text);
                txtLOT_Scan.SelectAll();
            }
        }

        private void btnSaveFPCBInfor_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTrayNum_Using.Text != lblTray_Num.Text)
                {
                    if (_tbProdOfLot != null && _tbProdOfLot.Rows.Count > 0)
                    {
                        int i = _tbProdOfLot.Rows.Count;
                        if (MessageBox.Show("This FPCB Serial has still " + i + "ea. \r Decided to change?", "Warning", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            checkProdOfLot(lblTray_Num.Text);
                            lblTrayNum_Using.Text = lblTray_Num.Text;
                            if (Int32.TryParse(lblPCB_Qty.Text, out int q))
                            {
                                segTotalQty_Prod.Value = q.ToString();
                            }
                        }
                    }
                    else
                    {
                        checkProdOfLot(lblTray_Num.Text);
                        lblTrayNum_Using.Text = lblTray_Num.Text;
                        if (Int32.TryParse(lblPCB_Qty.Text, out int q))
                        {
                            segTotalQty_Prod.Value = q.ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("FPCB Seria is in use!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                txtLOT_Scan.Clear();
                btnSaveFPCBInfor.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem with Saving FPCB infor!"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTape_Check_Scan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTape_Serial_Scan.Text))
            {
                return;
            }
            else
            {
                txtTape_Serial_Scan.SelectAll();
                checkTapeDB();
            }
        }

        private void btnSaveTapeInfo_Click(object sender, EventArgs e)
        {
            try
            {
                switch (lblTape_Type.Text.ToUpper())
                {
                    case "TAPE01":
                        {
                            checkTapeBeforeChange(lblTape1_MaterialCode, lblTape1_Material_LotNo, lblTape1_Serial,
                            "TAPE01", lblTape1_Qty, segTape1_QtyUse, segTape1_TotalNG);
                            break;
                        }
                    case "TAPE02":
                        {
                            checkTapeBeforeChange(lblTape2_MaterialCode, lblTape2_Material_LotNo, lblTape2_Serial,
                                "TAPE02", lblTape2_Qty, segTape2_QtyUse, segTape2_TotalNG);
                            break;
                        }
                    case "TAPE03":
                        {
                            checkTapeBeforeChange(lblTape3_MaterialCode, lblTape3_Material_LotNo, lblTape3_Serial,
                                "TAPE03", lblTape3_Qty, segTape3_QtyUse, segTape3_TotalNG);
                            break;
                        }
                    case "TAPE04":
                        {
                            checkTapeBeforeChange(lblTape4_MaterialCode, lblTape4_Material_LotNo, lblTape4_Serial,
                                "TAPE04", lblTape4_Qty, segTape4_QtyUse, segTape4_TotalNG);
                            break;
                        }
                    case "TAPE05":
                        {
                            checkTapeBeforeChange(lblTape5_MaterialCode, lblTape5_Material_LotNo, lblTape5_Serial,
                                "TAPE05", lblTape5_Qty, segTape5_QtyUse, segTape5_TotalNG);
                            break;
                        }
                    default:
                        MessageBox.Show("Plese check the infomation of TAPE!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        break;
                }

                Tape_DTO tapeNew = new Tape_DTO(lblTape_MaterialCode.Text, lblTape_Material_LotNo.Text, lblTape_SerialLot.Text,
                        lblTape_Type.Text, lblTape_Qty.Text);
                logTape_Infor(tapeNew, "USING", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), string.Empty, string.Empty);
                btnSaveTapeInfo.Enabled = false;
                txtTape_Serial_Scan.Clear();
                txtTape_Serial_Scan.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem saving the Tape information!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_Folder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    _path = txtPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem selecting folder!\n"
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            if (!_rsScan1)
            {
                CCSProcess(txtProd01_Scan.Text, lblProd01_Status);
            }
            if (!_rsScan2)
            {
                CCSProcess(txtProd02_Scan.Text, lblProd02_Status);
            }
        }

        private void btnManualCheck_Click(object sender, EventArgs e)
        {
            fManualCheck frm = new fManualCheck();
            frm.ShowDialog();
        }

        #endregion

        #region TextBox Event
        private void txtTape_Serial_Scan_TextChanged(object sender, EventArgs e)
        {
            btnTape_Check_Scan.Enabled = true;
        }

        private void txtLOT_Scan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    if (txtLOT_Scan.Text == string.Empty)
                    {
                        return;
                    }
                    else
                    {
                        checkLOTDB(txtLOT_Scan.Text);
                        txtLOT_Scan.SelectAll();
                    }
                }));
            }
        }

        private void txtTape_Serial_Scan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    txtTape_Serial_Scan.SelectAll();
                    checkTapeDB();
                }));
            }
        }

        private void txtProd01_Scan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProd01_Scan.SelectAll();
                CCSProcess(txtProd01_Scan.Text, lblProd01_Status);
            }
        }

        private void txtProd02_Scan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProd02_Scan.SelectAll();
                CCSProcess(txtProd02_Scan.Text, lblProd02_Status);
            }
        }

        #endregion

        #region DataGridView Event

        #endregion
        #endregion

        #region Method

        #region Check Standard Conditions
        /// <summary>
        /// check if the equipment is selected?
        /// </summary>
        /// <returns>return true if Equipment is selected othewise return fale</returns>
        private bool checkEquipEmpty()
        {
            if (string.IsNullOrEmpty(lblEquip_Name.Text))
            {
                MessageBox.Show("Equipment has not been selected!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// check conditions of runMode before active
        /// </summary>
        private bool checkRunMode_Conditons()
        {
            if (_plc.Open() != -268435453)
            {
                MessageBox.Show("Do not connected to PLC!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            //if (!serialPort1.IsOpen || !serialPort2.IsOpen)
            //{
            //    MessageBox.Show("Do not connected to Scanner!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //    return false;
            //}
            if (!checkEquipEmpty())
            {
                MessageBox.Show("Equipment has not been selected!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dgvProdOf_LOT.Rows.Count == 0)
            {
                MessageBox.Show("FPCB information has not been loaded!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(lblTape1_Serial.Text))
            {
                MessageBox.Show("The information of Tape1 have not been entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(lblTape2_Serial.Text))
            {
                MessageBox.Show("The information of Tape2 have not been entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(lblTape3_Serial.Text))
            {
                MessageBox.Show("The information of Tape3 have not been entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(lblTape4_Serial.Text))
            {
                MessageBox.Show("The information of Tape4 have not been entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(lblTape5_Serial.Text))
            {
                MessageBox.Show("The information of Tape5 have not been entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// check the status of Tape being used
        /// </summary>
        /// <returns></returns>
        private bool checkTapeUsing()
        {
            if (lblTape1_Qty.Text == "0")
            {
                MessageBox.Show("TAPE1 has no data!", "WARNING");
                return false;
            }
            if (segTape1_QtyUse.Value == lblTape1_Qty.Text)
            {
                MessageBox.Show("Out of TAPE1!", "WARNING");
                return false;
            }

            if (lblTape2_Qty.Text == "0")
            {
                MessageBox.Show("TAPE2 has no data!");
                return false;
            }
            if (segTape2_QtyUse.Value == lblTape2_Qty.Text)
            {
                MessageBox.Show("Out of TAPE2!", "WARNING");
                return false;
            }

            if (lblTape3_Qty.Text == "0")
            {
                MessageBox.Show("TAPE3 has no data!");
                return false;
            }
            if (segTape3_QtyUse.Value == lblTape3_Qty.Text)
            {
                MessageBox.Show("Out of TAPE3!", "WARNING");
                return false;
            }

            if (lblTape4_Qty.Text == "0")
            {
                MessageBox.Show("TAPE4 has no data!");
                return false;
            }
            if (segTape4_QtyUse.Value == lblTape4_Qty.Text)
            {
                MessageBox.Show("Out of TAPE4!", "WARNING");
                return false;
            }

            if (lblTape5_Qty.Text == "0")
            {
                MessageBox.Show("TAPE5 has no data!");
                return false;
            }
            if (segTape5_QtyUse.Value == lblTape5_Qty.Text)
            {
                MessageBox.Show("Out of TAPE5!", "WARNING");
                return false;
            }
            return true;
        }
        /// <summary>
        /// reset flag and clear data received
        /// </summary>
        private void resetFlag()
        {
            _dataReceive1 = string.Empty;
            _dataReceive2 = string.Empty;
            formatText(lblProd01_Status, "Waiting", Color.Black, Color.Transparent);
            formatText(lblProd02_Status, "Waiting", Color.Black, Color.Transparent);
        }
        /// <summary>
        /// format properties of label
        /// </summary>
        private void formatText(Label label, string text, Color foreColor, Color backColor)
        {
            if (!string.IsNullOrEmpty(text))
            {
                label.Text = text;
            }
            label.ForeColor = foreColor;
            label.BackColor = backColor;
        }

        #endregion

        #region Data Process
        /// <summary>
        /// binding data to dataGridView
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="tb"></param>
        /// <param name="count"></param>
        private void dataBindingDGV(DataGridView dgv, DataTable tb, SevenSegmentArray count)
        {
            dgv.Invoke(new MethodInvoker(() =>
            {
                dgv.DataSource = tb;
                dgv.Rows[0].Cells[0].Selected = false;
                count.Value = dgv.Rows.Count.ToString();
            }));
        }
        /// <summary>
        /// dislay data on dataGridView via other thread
        /// </summary>
        private void bindingData()
        {
            try
            {
                if (_tbProdPass != null)
                {
                    dataBindingDGV(dgvLOT_PASS, _tbProdPass, segQty_Pass);
                }
                else
                {
                    dgvLOT_PASS.Invoke(new MethodInvoker(() =>
                    {
                        var dt = dgvLOT_PASS.DataSource as DataTable;
                        if (dt != null)
                        {
                            dt.Rows.Clear();
                            dgvLOT_PASS.DataSource = dt;
                        }
                    }));
                }
                if (_tbProdOfLot.Rows.Count != 0)
                {
                    dataBindingDGV(dgvProdOf_LOT, _tbProdOfLot, segQty_Remaining);
                }
                else
                {
                    //writeBitToPLC("M258", 1);
                    dgvProdOf_LOT.Invoke(new MethodInvoker(() =>
                    {
                        var dt = dgvProdOf_LOT.DataSource as DataTable;
                        if (dt !=null)
                        {
                            dt.Rows.Clear();

                            dgvProdOf_LOT.DataSource = dt;
                        }
                        MessageBox.Show("All FPCB have CCS Tape!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem with Binding data to View!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// get lot data from database through input data
        /// </summary>
        /// <param name="scan"></param>
        private void checkLOTDB(string scan)
        {
            try
            {
                DataTable table = _dtcnn.get_LotFPCB(scan);
                if (table != null)
                {
                    lblLOT_Status.Text = "OK";
                    lblLOT_Status.ForeColor = Color.Green;
                    lblTray_Num.Text = table.Rows[0][0].ToString().ToUpper();
                    lblTray_Num.ForeColor = Color.Green;
                    lblPCB_Qty.Text = table.Rows[0][1].ToString().ToUpper();
                    lblPCB_Qty.ForeColor = Color.Green;
                    lblQty_Pass.Text = table.Rows[0][2].ToString().ToUpper();
                    lblQty_Pass.ForeColor = Color.Green;
                    btnSaveFPCBInfor.Enabled = true;
                    btnSaveFPCBInfor.Focus();
                }
                else
                {
                    lblLOT_Status.Text = "NOT FOUND";
                    lblLOT_Status.ForeColor = Color.Red;
                    lblTray_Num.Text = ".........................";
                    lblTray_Num.ForeColor = Color.Red;
                    lblPCB_Qty.Text = ".........................";
                    lblPCB_Qty.ForeColor = Color.Red;
                    lblQty_Pass.Text = "...............";
                    lblQty_Pass.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem retieving Lot data form system database!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// get product(FPCB) data from database through input data
        /// </summary>
        /// <param name="scan"></param>
        private void checkProdOfLot(string scan)
        {
            try
            {
                _tbProdOfLot = _dtcnn.get_FPCB(scan);
                _tbProdPass = _dtcnn.get_FPCBAfterCCS(scan);
                Thread t = new Thread(new ThreadStart(bindingData)) { IsBackground = true };
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem retrieving FPCB data form system database!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// get Tape data from database through input data
        /// </summary>
        private void checkTapeDB()
        {
            using (SqlConnection conn = _dtcnn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "select * from tbTAPE where serial = '" + txtTape_Serial_Scan.Text + "'";
                    DataTable table = _dtcnn.GetTable(sql);
                    if (table.Rows.Count > 0)
                    {
                        lblTape_Status.Text = "OK";
                        lblTape_Status.ForeColor = Color.Green;
                        lblTape_MaterialCode.Text = table.Rows[0][0].ToString().ToUpper();
                        lblTape_MaterialCode.ForeColor = Color.Green;
                        lblTape_Material_LotNo.Text = table.Rows[0][1].ToString().ToUpper();
                        lblTape_Material_LotNo.ForeColor = Color.Green;
                        lblTape_SerialLot.Text = table.Rows[0][2].ToString().ToUpper();
                        lblTape_SerialLot.ForeColor = Color.Green;
                        lblTape_Type.Text = table.Rows[0][3].ToString().ToUpper();
                        lblTape_Type.ForeColor = Color.Green;
                        lblTape_Qty.Text = table.Rows[0][4].ToString().ToUpper();
                        lblTape_Qty.ForeColor = Color.Green;
                        btnSaveTapeInfo.Enabled = true;
                        btnSaveTapeInfo.Focus();
                    }
                    else
                    {
                        lblTape_Status.Text = "NOT FOUND";
                        lblTape_Status.ForeColor = Color.Red;
                        lblTape_MaterialCode.Text = ".................";
                        lblTape_MaterialCode.ForeColor = Color.OrangeRed;
                        lblTape_Material_LotNo.Text = ".................";
                        lblTape_Material_LotNo.ForeColor = Color.OrangeRed;
                        lblTape_SerialLot.Text = ".................";
                        lblTape_SerialLot.ForeColor = Color.OrangeRed;
                        lblTape_Type.Text = "........";
                        lblTape_Type.ForeColor = Color.OrangeRed;
                        lblTape_Qty.Text = "........";
                        lblTape_Qty.ForeColor = Color.OrangeRed;
                        btnSaveTapeInfo.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem retrieving Tape data form system database!\n"
                        + ex.Message, "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            };
        }
        /// <summary>
        /// check standard conditions before replacing Tape
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lotno"></param>
        /// <param name="serial"></param>
        /// <param name="type"></param>
        /// <param name="qty"></param>
        /// <param name="use"></param>
        /// <param name="ng"></param>
        private void checkTapeBeforeChange(Label code, Label lotno, Label serial, string type, Label qty, SevenSegmentArray use, SevenSegmentArray ng)
        {
            try
            {
                if (lblTape_SerialLot.Text != serial.Text)
                {
                    if (int.Parse(use.Value) < int.Parse(qty.Text))
                    {
                        int i = int.Parse(qty.Text) - int.Parse(use.Value);
                        if (MessageBox.Show("This Tape Serial has still " + i + "ea. \r Decided to change?", "Warning", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (!serial.Text.ToUpper().Contains("SERIAL"))
                            {
                                Tape_DTO tape = new Tape_DTO(code.Text, lotno.Text, serial.Text, type, qty.Text);
                                logTape_Infor(tape, "USED", string.Empty, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), use.Value);
                            }
                            ng.Value = int.Parse(ng.Value) + int.Parse(qty.Text) - int.Parse(use.Value) + string.Empty;
                            use.Value = "0000";
                            code.Text = lblTape_MaterialCode.Text;
                            lotno.Text = lblTape_Material_LotNo.Text;
                            serial.Text = lblTape_SerialLot.Text;
                            qty.Text = lblTape_Qty.Text;
                        }
                    }
                    else
                    {
                        if (!serial.Text.ToUpper().Contains("SERIAL"))
                        {
                            Tape_DTO tape = new Tape_DTO(code.Text, lotno.Text, serial.Text, type, qty.Text);
                            logTape_Infor(tape, "USED", string.Empty, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), use.Value);
                        }
                        ng.Value = int.Parse(ng.Value) + int.Parse(qty.Text) - int.Parse(use.Value) + string.Empty;
                        use.Value = "0000";
                        code.Text = lblTape_MaterialCode.Text;
                        lotno.Text = lblTape_Material_LotNo.Text;
                        serial.Text = lblTape_SerialLot.Text;
                        qty.Text = lblTape_Qty.Text;
                    }
                    btnSaveTapeInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Tape Serial is in use", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem checking the Tape before runnning!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// increase the amount of tape used for the current lot
        /// </summary>
        private void CCSTape()
        {
            segTape1_QtyUse.Value = int.Parse(segTape1_QtyUse.Value) + 1 + string.Empty;
            segTape2_QtyUse.Value = int.Parse(segTape2_QtyUse.Value) + 1 + string.Empty;
            segTape3_QtyUse.Value = int.Parse(segTape3_QtyUse.Value) + 1 + string.Empty;
            segTape4_QtyUse.Value = int.Parse(segTape4_QtyUse.Value) + 1 + string.Empty;
            segTape5_QtyUse.Value = int.Parse(segTape5_QtyUse.Value) + 1 + string.Empty;
        }
        /// <summary>
        /// check the result and send signal to PLC
        /// </summary>
        private void checkResult()
        {
            if (lblProd01_Status.Text.Contains("NG") && lblProd02_Status.Text.Contains("NG"))
            {
                writeBitToPLC("M253", 1);
                return;
            }
            else if (lblProd01_Status.Text.Contains("NG"))
            {
                writeBitToPLC("M253", 1);
                return;
            }
            else if (lblProd02_Status.Text.Contains("NG"))
            {
                writeBitToPLC("M254", 1);
                return;
            }
            else
            {
                writeBitToPLC("M262", 1);
                return;
            }
        }
        /// <summary>
        /// attach Tapes data to the FPCBs
        /// </summary>
        private void CCSProcess(string scan, Label lbl)
        {
            try
            {
                if (_tbProdOfLot.Rows.Count < 1)
                {
                    MessageBox.Show("There are no more products form this LOT !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    writeBitToPLC("M258", 1);
                    return;
                }
                else if (!checkTapeUsing() || !checkEquipEmpty())
                {
                    writeBitToPLC("M257", 1);
                    return;
                }
                else
                {
                    DataTable tb = _dtcnn.search_FPCB_Scan(lblTrayNum_Using.Text, scan);
                    if (tb != null)
                    {
                        string _equip = lblEquip_Name.Text;
                        string _orderno = tb.Rows[0][1].ToString();
                        string _serial = tb.Rows[0][2].ToString();
                        string _code = tb.Rows[0][3].ToString();
                        string _pcb_lot = tb.Rows[0][4].ToString();
                        string _fpcb_lot = tb.Rows[0][5].ToString();
                        string _tape1 = lblTape1_Serial.Text;
                        string _tape2 = lblTape2_Serial.Text;
                        string _tape3 = lblTape3_Serial.Text;
                        string _tape4 = lblTape4_Serial.Text;
                        string _tape5 = lblTape5_Serial.Text;
                        string _time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        string _tray_num = lblTrayNum_Using.Text;

                        _dtcnn.add_FPCBCCS(_tray_num, _equip, _serial, _code, _orderno,
                                           _pcb_lot, _fpcb_lot, _tape1, _tape2, _tape3, _tape4, _tape5);
                        formatText(lbl, "OK", Color.LightGreen, Color.Transparent);

                        logSave_FPCB(_tray_num, _serial, _code, _orderno, _pcb_lot, _fpcb_lot, _time);
                        CCSTape();
                        checkProdOfLot(_tray_num);
                    }
                    else
                    {
                        formatText(lbl, "NG", Color.OrangeRed, Color.Transparent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem Scanning Barcode!\n" +
                    ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region LogFile
        /// <summary>
        /// check if the directory exists or not. otherwise create directory
        /// </summary>
        /// <param name="path"></param>
        private void checkFolder(string path)
        {
            try
            {
                DirectoryInfo direc = new DirectoryInfo(path);
                DirectoryInfo direcConfig = new DirectoryInfo(path + @"\Config");
                if (!direc.Exists)
                {
                    direc.Create();
                }
                if (!direcConfig.Exists)
                {
                    direcConfig.Create();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem checking the folder path!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// record FPCB information after CCS
        /// </summary>
        /// <param name="serial">label contains text serial</param>
        /// <param name="orderno"></param>
        /// <param name="code"></param>
        /// <param name="time"></param>
        private void logSave_FPCB(string tray_num, string serial, string code, string orderno, string pcb_lot, string fpcb_lot, string time)
        {
            try
            {
                string fname = _path + @"/FPCB_" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".csv";
                string contents = "";
                if (!File.Exists(fname) && _tbProdOfLot != null)
                {
                    string s = "EQUIPMENT, TRAY NUMBER, ORDER NO, PROD. SERIAL, PROD. CODE, PCB_LOT, FPCB_LOT, " +
                        "TAPE1-C_PSA, TAPE2-TAIL, TAPE3-BODY, TAPE4-CELL_ID, TAPE5-BENDING, WORKING TIME" + "\n";
                    File.WriteAllText(fname, s);
                }
                contents += string.Concat(new string[] {
                lblEquip_Name.Text, ",",
                tray_num, ",",
                orderno, ",",
                serial, ",",
                code, ",",
                pcb_lot, ",",
                fpcb_lot, ",",
                lblTape1_Serial.Text, ",",
                lblTape2_Serial.Text, ",",
                lblTape3_Serial.Text, ",",
                lblTape4_Serial.Text, ",",
                lblTape5_Serial.Text, ",",
                time, "\n"}); ;
                File.AppendAllText(fname, contents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem recording FPCB data!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// record Tape information
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="status"></param>
        /// <param name="timeStart"></param>
        /// <param name="timeEnd"></param>
        /// <param name="used"></param>
        private void logTape_Infor(Tape_DTO newItem, string status, string timeStart, string timeEnd, string used)
        {
            try
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    string fname = _path + @"\Tape_" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".csv";
                    if (!File.Exists(fname))
                    {
                        string s = string.Concat(
                            "Material_code", ",",
                            "Material_Lotno", ",",
                            "Serial", ",",
                            "Type", ",",
                            "Qty", ",",
                            "Status", ",",
                            "TimeStart", ",",
                            "TimeEnd", ",",
                            "Used", "\n");
                        File.WriteAllText(fname, s);
                    }

                    string contents = string.Concat(new string[] {
                newItem.material_code, ",",
                newItem.material_lotno, ",",
                newItem.serial, ",",
                newItem.type, ",",
                newItem.quantity.ToString(), ",",
                status, ",",
                timeStart, ",",
                timeEnd, ",",
                used, "\n"});

                    File.AppendAllText(fname, contents);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem recording Tape data!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// record the data Tape is using in the program
        /// </summary>
        private void logData_Config()
        {
            try
            {
                if (!string.IsNullOrEmpty(lblTape1_Serial.Text))
                {
                    _tapeItems.Add(new Tape_DTO(lblTape1_MaterialCode.Text, lblTape1_Material_LotNo.Text, lblTape1_Serial.Text,
                        "TAPE01", lblTape1_Qty.Text, segTape1_QtyUse.Value, segTape1_TotalNG.Value));
                }
                if (!string.IsNullOrEmpty(lblTape2_Serial.Text))
                {
                    _tapeItems.Add(new Tape_DTO(lblTape2_MaterialCode.Text, lblTape2_Material_LotNo.Text, lblTape2_Serial.Text,
                    "TAPE02", lblTape2_Qty.Text, segTape2_QtyUse.Value, segTape2_TotalNG.Value));
                }
                if (!string.IsNullOrEmpty(lblTape3_Serial.Text))
                {
                    _tapeItems.Add(new Tape_DTO(lblTape3_MaterialCode.Text, lblTape3_Material_LotNo.Text, lblTape3_Serial.Text,
                    "TAPE03", lblTape3_Qty.Text, segTape3_QtyUse.Value, segTape3_TotalNG.Value));
                }
                if (!string.IsNullOrEmpty(lblTape4_Serial.Text))
                {
                    _tapeItems.Add(new Tape_DTO(lblTape4_MaterialCode.Text, lblTape4_Material_LotNo.Text, lblTape4_Serial.Text,
                    "TAPE04", lblTape4_Qty.Text, segTape4_QtyUse.Value, segTape4_TotalNG.Value));
                }
                if (!string.IsNullOrEmpty(lblTape5_Serial.Text))
                {
                    _tapeItems.Add(new Tape_DTO(lblTape5_MaterialCode.Text, lblTape5_Material_LotNo.Text, lblTape5_Serial.Text,
                    "TAPE05", lblTape5_Qty.Text, segTape5_QtyUse.Value, segTape5_TotalNG.Value));
                }
                string fTape = _path + @"\Config\Tape_Config.txt";
                String jsTapeOut = JsonConvert.SerializeObject(_tapeItems.ToArray(), Formatting.Indented);
                File.WriteAllText(fTape, jsTapeOut);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem recording Tape data!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// load file configuration of the data Tape is using
        /// </summary>
        private void load_logDataConfig()
        {
            try
            {
                string fTape = _path + @"\Config\Tape_Config.txt";
                if (File.Exists(fTape))
                {
                    using (StreamReader r = new StreamReader(fTape))
                    {
                        String js = r.ReadToEnd();
                        _tapeItems = JsonConvert.DeserializeObject<List<Tape_DTO>>(js);
                        if (_tapeItems == null)
                        {
                            _tapeItems = new List<Tape_DTO>();
                        }
                    }
                }
                if (_tapeItems != null)
                {
                    foreach (var item in _tapeItems)
                    {
                        switch (item.type.ToUpper())
                        {
                            case "TAPE01":
                                {
                                    lblTape1_MaterialCode.Text = item.material_code;
                                    lblTape1_Material_LotNo.Text = item.material_lotno;
                                    lblTape1_Serial.Text = item.serial;
                                    lblTape1_Qty.Text = item.quantity.ToString();
                                    segTape1_QtyUse.Value = item.use.ToString();
                                    segTape1_TotalNG.Value = item.totalNG.ToString();
                                    break;
                                }
                            case "TAPE02":
                                {
                                    lblTape2_MaterialCode.Text = item.material_code;
                                    lblTape2_Material_LotNo.Text = item.material_lotno;
                                    lblTape2_Serial.Text = item.serial;
                                    lblTape2_Qty.Text = item.quantity.ToString();
                                    segTape2_QtyUse.Value = item.use.ToString();
                                    segTape2_TotalNG.Value = item.totalNG.ToString();
                                    break;
                                }
                            case "TAPE03":
                                {
                                    lblTape3_MaterialCode.Text = item.material_code;
                                    lblTape3_Material_LotNo.Text = item.material_lotno;
                                    lblTape3_Serial.Text = item.serial;
                                    lblTape3_Qty.Text = item.quantity.ToString();
                                    segTape3_QtyUse.Value = item.use.ToString();
                                    segTape3_TotalNG.Value = item.totalNG.ToString();
                                    break;
                                }
                            case "TAPE04":
                                {
                                    lblTape4_MaterialCode.Text = item.material_code;
                                    lblTape4_Material_LotNo.Text = item.material_lotno;
                                    lblTape4_Serial.Text = item.serial;
                                    lblTape4_Qty.Text = item.quantity.ToString();
                                    segTape4_QtyUse.Value = item.use.ToString();
                                    segTape4_TotalNG.Value = item.totalNG.ToString();
                                    break;
                                }
                            case "TAPE05":
                                {
                                    lblTape5_MaterialCode.Text = item.material_code;
                                    lblTape5_Material_LotNo.Text = item.material_lotno;
                                    lblTape5_Serial.Text = item.serial;
                                    lblTape5_Qty.Text = item.quantity.ToString();
                                    segTape5_QtyUse.Value = item.use.ToString();
                                    segTape5_TotalNG.Value = item.totalNG.ToString();
                                    break;
                                }
                            default:
                                MessageBox.Show("Please check the infomation of TAPE!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    _tapeItems.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem recording DataConfig data!\n"
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// convert type of table to type of List
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        private List<Product_DTO> convert_TabletoList(DataTable tb)
        {
            List<Product_DTO> obj = new List<Product_DTO>();
            foreach (DataRow row in tb.Rows)
            {
                Product_DTO prod = new Product_DTO
                {
                    lot_serial = row[0].ToString(),
                    prod_serial = row[1].ToString(),
                    prod_code = row[2].ToString(),
                    order_no = row[3].ToString()
                };
                obj.Add(prod);
            }
            return obj;
        }
        #endregion

        #region Export
        /// <summary>
        /// configure excel file
        /// </summary>
        /// <param name="filePath"></param>
        private void ExportExcel(string filePath)
        {
            ////Excel.Application application
            //int inHeaderLength = 3, inColumn = 0, inRow = 0;
            //System.Reflection.Missing Default = System.Reflection.Missing.Value;
            ////tạo file excel
            //Microsoft.Office.Interop.Excel.Application excelApp = new Excel.Application();
            //Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            ////tạo sheet
            //Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets[1];
            ////tạo cột
            //excelWorkSheet.Cells[inHeaderLength + 1, 1] = "prod_serial".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 2] = "group_no".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 3] = "prod_code".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 4] = "lot_mark".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 5] = "cpsa_serial".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 6] = "tail_serial".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 7] = "body_serial".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 8] = "cellid_serial".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 9] = "bending_serial".ToUpper();
            //excelWorkSheet.Cells[inHeaderLength + 1, 10] = "time".ToUpper();

            ////tạo dòng
            //for (int j = 0; j < _tbProdPass.Rows.Count; j++)
            //{
            //    for (int k = 0; k < _tbProdPass.Columns.Count; k++)
            //    {
            //        inColumn = k + 1;
            //        inRow = inHeaderLength + 2 + j;
            //        excelWorkSheet.Cells[inRow, inColumn] = _tbProdPass.Rows[j].ItemArray[k].ToString();
            //        if (j % 2 == 0)
            //        {
            //            excelWorkSheet.get_Range("A" + inRow.ToString(), "J" +
            //                inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
            //        }
            //    }
            //}
            ////Tiêu đề
            //Excel.Range cellRang = excelWorkSheet.get_Range("A1", "J3");
            //cellRang.Merge(false);
            //cellRang.Interior.Color = System.Drawing.Color.White;
            //cellRang.Font.Color = System.Drawing.Color.Green;
            //cellRang.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //cellRang.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //cellRang.Font.Size = 16;
            //excelWorkSheet.Cells[1, 1] = "LOT " + lblTrayNum_Using.Text + " " + DateTime.Now.ToString("dd/MM/yyyy");


            ////Định dạng cột
            //cellRang = excelWorkSheet.get_Range("A4", "J4");
            //cellRang.Font.Bold = true;
            //cellRang.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //cellRang.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            //cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
            //excelWorkSheet.Columns.AutoFit();

            //excelWorkBook.SaveAs(filePath, Default, Default, Default, false, Default,
            //    Excel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
            //excelWorkBook.Close();
            //excelApp.Quit();

        }
        /// <summary>
        /// configure text file
        /// </summary>
        private void exportFile_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region PLC
        /// <summary>
        /// read signal from PLC program
        /// </summary>
        private int readBitFromPLC(string t)
        {
            _plc.GetDevice(t, out int bit);
            return bit;
        }
        /// <summary>
        /// return signal to PLC program
        /// </summary>
        /// <param name="rs"></param>
        private void writeBitToPLC(string address, int bit)
        {
            _plc.SetDevice(address, bit);
        }
        #endregion

        #region Serial Port
        private int _delay;
        Thread _delayCal;
        /// <summary>
        /// wait for timeout before taking the next action
        /// </summary>
        /// <param name="serialPort"></param>
        private void DelayTime(SerialPort serialPort)
        {
            _delay += 200;
            if (_delayCal != null && _delayCal.IsAlive)
            {
                return;
            }
            _delayCal = new Thread(() =>
            {
                while (_delay >= 200)
                {
                    _delay -= 100;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                Invoke(new Action(() =>
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Write("\x16" + "U" + "\x0D");
                    }
                }));
            });
            _delayCal.Start();
        }
        /// <summary>
        /// wait for timeout before send signal to PLC
        /// </summary>
        private void DelayTime(string adres, int i)
        {
            _delay += 200;
            if (_delayCal != null && _delayCal.IsAlive)
            {
                return;
            }
            _delayCal = new Thread(() =>
            {
                while (_delay >= 200)
                {
                    _delay -= 100;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                Invoke(new Action(() =>
                {
                    writeBitToPLC(adres, i);
                }));
            });
            _delayCal.Start();
        }

        private int _delay2;
        Thread _delayCal2;
        /// <summary>
        /// wait for timeout before check scan result
        /// </summary>
        private void DelayCheckResult()
        {
            _delay2 += 2000;
            if (_delayCal2 != null && _delayCal2.IsAlive)
            {
                return;
            }
            _delayCal2 = new Thread(() =>
            {
                while (_delay2 >= 200)
                {
                    _delay2 -= 100;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                Invoke(new Action(() =>
                {
                    try
                    {
                        serialPort1.Write("\x16" + "U" + "\x0D");
                        serialPort2.Write("\x16" + "U" + "\x0D");
                        if (string.IsNullOrEmpty(_dataReceive1) && !string.IsNullOrEmpty(_dataReceive2))
                        {
                            writeBitToPLC("M255", 1);
                            lbltest.Text = "1111111";

                        }
                        else if (!string.IsNullOrEmpty(_dataReceive1) && string.IsNullOrEmpty(_dataReceive2))
                        {
                            writeBitToPLC("M256", 1);
                            lbltest.Text = "222222";

                        }
                        else if (string.IsNullOrEmpty(_dataReceive1) && string.IsNullOrEmpty(_dataReceive2))
                        {
                            writeBitToPLC("M255", 1);
                            lbltest.Text = "3333333";
                        }
                        else
                        {
                            lbltest.Text = "444444";
                            checkResult();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem with delay check result!" +
                            ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }));
            });
            _delayCal2.Start();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _dataReceive1 = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(showDataS1));
        }
        /// <summary>
        /// fill scanned data and do CCS
        /// </summary>
        private void showDataS1(object sender, EventArgs e)
        {
            txtProd01_Scan.Text = _dataReceive1;
            if (!String.IsNullOrEmpty(_dataReceive1))
            {
                CCSProcess(txtProd01_Scan.Text.Trim(), lblProd01_Status);
            }
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _dataReceive2 = serialPort2.ReadExisting();
            this.Invoke(new EventHandler(showDataS2));
        }
        /// <summary>
        /// fill scanned data and do CCS
        /// </summary>
        private void showDataS2(object sender, EventArgs e)
        {
            txtProd02_Scan.Text = _dataReceive2;
            if (!String.IsNullOrEmpty(_dataReceive2))
            {
                CCSProcess(txtProd02_Scan.Text.Trim(), lblProd02_Status);
            }
        }

        #endregion

        private void txtProd01_Scan_TextChanged(object sender, EventArgs e)
        {
            //txtProd01_Scan.SelectAll();
            //CCSProcess(txtProd01_Scan.Text.Trim(), lblProd01_Status);
        }

        private void txtProd02_Scan_TextChanged(object sender, EventArgs e)
        {
            //txtProd02_Scan.SelectAll();
            //CCSProcess(txtProd02_Scan.Text.Trim(), lblProd02_Status);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            writeBitToPLC("M253", 1);
        }
    }
}
