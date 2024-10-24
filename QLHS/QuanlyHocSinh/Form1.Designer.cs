namespace QuanlyHocSinh
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;


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
            this.dtgSinhVien = new System.Windows.Forms.DataGridView();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.cmbNganh = new System.Windows.Forms.ComboBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btPre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSinhVien
            // 
            this.dtgSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSinhVien.Location = new System.Drawing.Point(56, 165);
            this.dtgSinhVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgSinhVien.Name = "dtgSinhVien";
            this.dtgSinhVien.RowHeadersWidth = 51;
            this.dtgSinhVien.RowTemplate.Height = 24;
            this.dtgSinhVien.Size = new System.Drawing.Size(677, 324);
            this.dtgSinhVien.TabIndex = 0;
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(612, 115);
            this.txtTuoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(121, 26);
            this.txtTuoi.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 113);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(169, 26);
            this.txtHoTen.TabIndex = 2;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // cmbNganh
            // 
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(344, 113);
            this.cmbNganh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(199, 28);
            this.cmbNganh.TabIndex = 3;
            // 
            // btThem
            // 
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(739, 226);
            this.btThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(115, 54);
            this.btThem.TabIndex = 4;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(739, 353);
            this.btXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(115, 54);
            this.btXoa.TabIndex = 5;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click_2);
            // 
            // btSua
            // 
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(739, 291);
            this.btSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(115, 54);
            this.btSua.TabIndex = 6;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click_2);
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.Location = new System.Drawing.Point(415, 508);
            this.btNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(112, 41);
            this.btNext.TabIndex = 7;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click_2);
            // 
            // btPre
            // 
            this.btPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPre.Location = new System.Drawing.Point(554, 508);
            this.btPre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btPre.Name = "btPre";
            this.btPre.Size = new System.Drawing.Size(112, 41);
            this.btPre.TabIndex = 8;
            this.btPre.Text = "Previous";
            this.btPre.UseVisualStyleBackColor = true;
            this.btPre.Click += new System.EventHandler(this.btPre_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Họ Tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(562, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tuổi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngành:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(276, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "QUẢN LÝ HỌC SINH";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btPre);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.cmbNganh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtTuoi);
            this.Controls.Add(this.dtgSinhVien);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSinhVien;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cmbNganh;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

