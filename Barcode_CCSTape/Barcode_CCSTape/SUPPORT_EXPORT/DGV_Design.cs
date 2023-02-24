using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_CCSTape
{
    class DGV_Design
    {
        public DataGridView dataGridView1 = new DataGridView();
        public void showRowNumber(DataGridView dgv)
        {
            dgv.RowHeadersWidth = 50;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dgv.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void setDataGrridView(List<DataGridView> dgv)
        {
            foreach (var item in dgv)
            {
                dataGridView1 = item;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(CellPainting);
                dataGridView1.Paint += new PaintEventHandler(Paint);
            }

        }

        public void Paint(object sender, PaintEventArgs e)
        {
            string defaultValues = "COUNT: " + dataGridView1.Rows.Count.ToString();
            int with = 0;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                with += dataGridView1.Columns[i].Width;
            }
            Rectangle r1 = dataGridView1.GetCellDisplayRectangle(0, -1, true); //get the column header cell
            r1.X += 1;
            r1.Y += 1;
            r1.Width = with - 2;
            r1.Height = r1.Height / 2;
            e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(defaultValues, dataGridView1.ColumnHeadersDefaultCellStyle.Font,
            new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),
            r1,
            format);
        }

        public void CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.PaintBackground(e.CellBounds, false);

                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintContent(r2);
                e.Handled = true;
            }
        }
    }
}
