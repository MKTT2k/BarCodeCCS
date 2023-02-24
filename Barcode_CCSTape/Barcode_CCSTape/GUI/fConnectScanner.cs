using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode_CCSTape.GUI;

namespace Barcode_CCSTape.GUI
{
    public partial class fConnectScanner : Form
    {
        #region Define and Contructor
        public ActUtlType _plc = new ActUtlType();

        public SerialPort scanner1
        {
            get
            {
                return serialPort1;
            }
        }

        public SerialPort scanner2
        {
            get
            {
                return serialPort2;
            }
        }

        public fConnectScanner()
        {
            InitializeComponent();
        }

        public fConnectScanner(SerialPort sp1, SerialPort sp2)
        {
            InitializeComponent();
            load_Data(sp1, sp2);
        }

        private void fConnectScanner_Load(object sender, EventArgs e)
        {
            defaultConfig();
        }
        #endregion

        #region Method
        private void defaultConfig()
        {
            string[] ports = SerialPort.GetPortNames();

            cbbComPort.Items.Clear();
            cbbComPort.Items.AddRange(ports);

            ckbDTREnable.Checked = false;
            serialPort1.DtrEnable = false;
            ckbRTSsEnable.Checked = false;
            serialPort1.RtsEnable = false;
        }

        private void load_Data(SerialPort sp1, SerialPort sp2)
        {
            if (sp1.PortName != "COM1" && sp2.PortName == "COM1")
            {
                serialPort1 = sp1;
                lblPort1_Name.Text = serialPort1.PortName;
                lblPort1_BaudRate.Text = serialPort1.BaudRate.ToString();
                ckbPort1_Status.Checked = serialPort1.IsOpen;
                btnTrigger1.Enabled = true;
            }
            else if (sp1.PortName == "COM1" && sp2.PortName != "COM1")
            {
                serialPort1 = sp2;
                lblPort1_Name.Text = serialPort1.PortName;
                lblPort1_BaudRate.Text = serialPort1.BaudRate.ToString();
                ckbPort1_Status.Checked = serialPort1.IsOpen;
                btnTrigger1.Enabled = true;

            }
            else if (sp1.PortName != "COM1" && sp2.PortName != "COM1")
            {
                serialPort1 = sp1;
                lblPort1_Name.Text = serialPort1.PortName;
                lblPort1_BaudRate.Text = serialPort1.BaudRate.ToString();
                ckbPort1_Status.Checked = serialPort1.IsOpen;
                btnTrigger1.Enabled = true;

                serialPort2 = sp2;
                lblPort2_Name.Text = serialPort2.PortName;
                lblPort2_BaudRate.Text = serialPort2.BaudRate.ToString();
                ckbPort2_Status.Checked = serialPort2.IsOpen;
                btnTrigger2.Enabled = true;
            }
            else return;
        }

        private void connectSerialPort(SerialPort serialPort)
        {
            try
            {
                progressBar1.Value = 0;
                serialPort.PortName = cbbComPort.Text;
                serialPort.BaudRate = Convert.ToInt32(cbbBaudRate.Text);
                serialPort.DataBits = Convert.ToInt32(cbbDataBits.Text);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbbStopBits.Text);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cbbParityBits.Text);

                serialPort.Open();
                progressBar1.Value = 100;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!checkStatusSerial())
            {
                timer.Stop();
                MessageBox.Show("Disconnect!");
            }
        }

        private bool checkStatusSerial()
        {
            if (serialPort1.IsOpen) return true;
            return false;
        }

        private int _delay;
        Thread _delayCal;
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

        #endregion

        #region Button Click Event
        private void btnopen_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    connectSerialPort(serialPort1);
                    lblPort1_Name.Text = serialPort1.PortName;
                    lblPort1_BaudRate.Text = serialPort1.BaudRate.ToString();
                    ckbPort1_Status.Checked = serialPort1.IsOpen;
                    btnTrigger1.Enabled = true;
                }));
                return;

            }
            else if (!serialPort2.IsOpen)
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    connectSerialPort(serialPort2);
                    lblPort2_Name.Text = serialPort2.PortName;
                    lblPort2_BaudRate.Text = serialPort2.BaudRate.ToString();
                    ckbPort2_Status.Checked = serialPort2.IsOpen;
                    btnTrigger2.Enabled = true;
                }));
                return;
            }
            else
            {
                MessageBox.Show("Connected with 2Scanner, Can't connect more scanner!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            defaultConfig();
        }

        private void btnTrigger1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("\x16" + "T" + "\x0D");
            }
            DelayTime(serialPort1);
        }

        private void btnTrigger2_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Write("\x16" + "T" + "\x0D");
            }
            DelayTime(serialPort2);
        }

        private void btnClearScan1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1 = new SerialPort();
            lblPort1_Name.Text = ".....................";
            lblPort1_BaudRate.Text = ".....................";
            ckbPort1_Status.Checked = false;
            btnTrigger1.Enabled = false;
        }

        private void btnClearScan2_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }
            serialPort2 = new SerialPort();
            lblPort2_Name.Text = ".....................";
            lblPort2_BaudRate.Text = ".....................";
            ckbPort2_Status.Checked = false;
            btnTrigger2.Enabled = false;
        }

        #endregion
    }
}
