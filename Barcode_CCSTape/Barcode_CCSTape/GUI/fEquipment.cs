using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode_CCSTape.DAL;

namespace Barcode_CCSTape.GUI
{
    public partial class fEquipment : Form
    {
        #region Define and Contructor
        DataConnection _dtcnn = new DataConnection();
        DataTable _equip = new DataTable();

        public string _equipName
        {
            get
            {
                return lblEquip_Name.Text;
            }
        }

        public string _equipDescription
        {
            get
            {
                return lblEquip_Description.Text;
            }
        }

        public fEquipment()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        private void btnEquipment_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _equip = _dtcnn.get_Equipment();

                dgvEquipment.DataSource = _equip;
                dgvEquipment.Rows[0].Cells[0].Selected = false;
                segAmount_Equip.Value = _equip.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle selection = new DataGridViewCellStyle();
            selection.ForeColor = Color.White;
            selection.BackColor = Color.Black;
            if (e.RowIndex > -1)
            {
                lblEquip_Name.Text = dgvEquipment.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblEquip_Description.Text = dgvEquipment.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dgvEquipment_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LawnGreen;
            }
        }

        private void dgvEquipment_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.RowIndex % 2 != 0)
                {
                    dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvEquipment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
                }
            }
        }

        private void dgvEquipment_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEquipment.Rows.Count; i++)
            {
                dgvEquipment.Rows[i].Cells[0].Value = i + 1;
            }
        }

        #endregion
    }
}
