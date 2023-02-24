
namespace Barcode_CCSTape.GUI
{
    partial class fEquipment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEquipment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblEquip_Name = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblEquip_Description = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnEquipment_Search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modified_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segAmount_Equip = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvEquipment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 540);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel13);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Controls.Add(this.segAmount_Equip);
            this.panel2.Controls.Add(this.btnEquipment_Search);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 107);
            this.panel2.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Controls.Add(this.lblEquip_Name);
            this.panel11.Location = new System.Drawing.Point(202, 41);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(185, 20);
            this.panel11.TabIndex = 23;
            // 
            // lblEquip_Name
            // 
            this.lblEquip_Name.AutoSize = true;
            this.lblEquip_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEquip_Name.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquip_Name.ForeColor = System.Drawing.Color.White;
            this.lblEquip_Name.Location = new System.Drawing.Point(0, 0);
            this.lblEquip_Name.Margin = new System.Windows.Forms.Padding(0);
            this.lblEquip_Name.Name = "lblEquip_Name";
            this.lblEquip_Name.Size = new System.Drawing.Size(96, 16);
            this.lblEquip_Name.TabIndex = 0;
            this.lblEquip_Name.Text = "Equipment name";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Black;
            this.panel13.Controls.Add(this.lblEquip_Description);
            this.panel13.Location = new System.Drawing.Point(202, 68);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(185, 20);
            this.panel13.TabIndex = 22;
            // 
            // lblEquip_Description
            // 
            this.lblEquip_Description.AutoSize = true;
            this.lblEquip_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEquip_Description.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquip_Description.ForeColor = System.Drawing.Color.White;
            this.lblEquip_Description.Location = new System.Drawing.Point(0, 0);
            this.lblEquip_Description.Margin = new System.Windows.Forms.Padding(0);
            this.lblEquip_Description.Name = "lblEquip_Description";
            this.lblEquip_Description.Size = new System.Drawing.Size(128, 16);
            this.lblEquip_Description.TabIndex = 0;
            this.lblEquip_Description.Text = "Equipment description";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(393, 42);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(62, 43);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm && Close";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnEquipment_Search
            // 
            this.btnEquipment_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEquipment_Search.Image = ((System.Drawing.Image)(resources.GetObject("btnEquipment_Search.Image")));
            this.btnEquipment_Search.Location = new System.Drawing.Point(3, 3);
            this.btnEquipment_Search.Name = "btnEquipment_Search";
            this.btnEquipment_Search.Size = new System.Drawing.Size(72, 59);
            this.btnEquipment_Search.TabIndex = 0;
            this.btnEquipment_Search.Text = "Search";
            this.btnEquipment_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEquipment_Search.UseVisualStyleBackColor = true;
            this.btnEquipment_Search.Click += new System.EventHandler(this.btnEquipment_Search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Equip description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Equip. name";
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.AllowUserToAddRows = false;
            this.dgvEquipment.AllowUserToDeleteRows = false;
            this.dgvEquipment.AllowUserToResizeColumns = false;
            this.dgvEquipment.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEquipment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.name,
            this.description,
            this.modified_date});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipment.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEquipment.Location = new System.Drawing.Point(0, 112);
            this.dgvEquipment.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEquipment.MultiSelect = false;
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipment.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEquipment.RowHeadersVisible = false;
            this.dgvEquipment.RowHeadersWidth = 51;
            this.dgvEquipment.RowTemplate.Height = 24;
            this.dgvEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipment.Size = new System.Drawing.Size(688, 428);
            this.dgvEquipment.TabIndex = 1;
            this.dgvEquipment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipment_CellClick);
            this.dgvEquipment.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipment_CellMouseLeave);
            this.dgvEquipment.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipment_CellMouseMove);
            this.dgvEquipment.Sorted += new System.EventHandler(this.dgvEquipment_Sorted);
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.no.DefaultCellStyle = dataGridViewCellStyle3;
            this.no.HeaderText = "";
            this.no.MinimumWidth = 6;
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 19;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 70;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 101;
            // 
            // modified_date
            // 
            this.modified_date.DataPropertyName = "modified_date";
            this.modified_date.HeaderText = "Modified date";
            this.modified_date.Name = "modified_date";
            this.modified_date.ReadOnly = true;
            this.modified_date.Width = 115;
            // 
            // segAmount_Equip
            // 
            this.segAmount_Equip.ArrayCount = 3;
            this.segAmount_Equip.ColorBackground = System.Drawing.Color.Black;
            this.segAmount_Equip.ColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.segAmount_Equip.ColorLight = System.Drawing.Color.LawnGreen;
            this.segAmount_Equip.DecimalShow = false;
            this.segAmount_Equip.ElementPadding = new System.Windows.Forms.Padding(4);
            this.segAmount_Equip.ElementWidth = 11;
            this.segAmount_Equip.ItalicFactor = 0F;
            this.segAmount_Equip.Location = new System.Drawing.Point(612, 69);
            this.segAmount_Equip.Name = "segAmount_Equip";
            this.segAmount_Equip.Size = new System.Drawing.Size(73, 35);
            this.segAmount_Equip.TabIndex = 10;
            this.segAmount_Equip.TabStop = false;
            this.segAmount_Equip.Value = null;
            // 
            // fEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 540);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fEquipment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Equipment";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEquipment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEquipment_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn modified_date;
        private DmitryBrant.CustomControls.SevenSegmentArray segAmount_Equip;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblEquip_Name;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblEquip_Description;
    }
}