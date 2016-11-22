namespace QuanLiThuVienNew
{
    partial class FrmSuaPhieuMuon
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
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtThoiGian = new System.Windows.Forms.DateTimePicker();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLUU = new System.Windows.Forms.Button();
            this.txtMaPM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(134, 196);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(173, 25);
            this.cboNhanVien.TabIndex = 48;
            // 
            // cboDocGia
            // 
            this.cboDocGia.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(134, 109);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(173, 25);
            this.cboDocGia.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Ngày Mượn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Độc Giả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Nhân Viên";
            // 
            // dtThoiGian
            // 
            this.dtThoiGian.Location = new System.Drawing.Point(134, 153);
            this.dtThoiGian.Name = "dtThoiGian";
            this.dtThoiGian.Size = new System.Drawing.Size(173, 20);
            this.dtThoiGian.TabIndex = 43;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(164, 247);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(126, 44);
            this.btnThoat.TabIndex = 42;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLUU
            // 
            this.btnLUU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLUU.ForeColor = System.Drawing.Color.Red;
            this.btnLUU.Location = new System.Drawing.Point(32, 247);
            this.btnLUU.Name = "btnLUU";
            this.btnLUU.Size = new System.Drawing.Size(126, 44);
            this.btnLUU.TabIndex = 41;
            this.btnLUU.Text = "LƯU";
            this.btnLUU.UseVisualStyleBackColor = true;
            this.btnLUU.Click += new System.EventHandler(this.btnLUU_Click);
            // 
            // txtMaPM
            // 
            this.txtMaPM.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPM.Location = new System.Drawing.Point(134, 64);
            this.txtMaPM.Name = "txtMaPM";
            this.txtMaPM.ReadOnly = true;
            this.txtMaPM.Size = new System.Drawing.Size(173, 25);
            this.txtMaPM.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Mã Phiếu Mượn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 19);
            this.label1.TabIndex = 38;
            this.label1.Text = "THÔNG TIN PHIẾU MƯỢN";
            // 
            // FrmSuaPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 312);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.cboDocGia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtThoiGian);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLUU);
            this.Controls.Add(this.txtMaPM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmSuaPhieuMuon";
            this.Text = "FrmSuaPhieuMuon";
            this.Load += new System.EventHandler(this.FrmSuaPhieuMuon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtThoiGian;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLUU;
        public System.Windows.Forms.TextBox txtMaPM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}