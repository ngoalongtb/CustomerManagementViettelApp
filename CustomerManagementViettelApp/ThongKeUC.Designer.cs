namespace CustomerManagementViettelApp
{
    partial class ThongKeUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnThongKeNhanVien = new System.Windows.Forms.Button();
            this.btnThongKeDichVu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(320, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 75;
            this.label1.Text = "Thống kê";
            // 
            // btnThongKeNhanVien
            // 
            this.btnThongKeNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThongKeNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeNhanVien.Font = new System.Drawing.Font("Calibri", 24F);
            this.btnThongKeNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnThongKeNhanVien.Location = new System.Drawing.Point(78, 169);
            this.btnThongKeNhanVien.Name = "btnThongKeNhanVien";
            this.btnThongKeNhanVien.Size = new System.Drawing.Size(280, 107);
            this.btnThongKeNhanVien.TabIndex = 76;
            this.btnThongKeNhanVien.Text = "Thống kê nhân viên";
            this.btnThongKeNhanVien.UseVisualStyleBackColor = false;
            this.btnThongKeNhanVien.Click += new System.EventHandler(this.btnThongKeNhanVien_Click);
            // 
            // btnThongKeDichVu
            // 
            this.btnThongKeDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThongKeDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeDichVu.Font = new System.Drawing.Font("Calibri", 24F);
            this.btnThongKeDichVu.ForeColor = System.Drawing.Color.White;
            this.btnThongKeDichVu.Location = new System.Drawing.Point(417, 169);
            this.btnThongKeDichVu.Name = "btnThongKeDichVu";
            this.btnThongKeDichVu.Size = new System.Drawing.Size(280, 107);
            this.btnThongKeDichVu.TabIndex = 76;
            this.btnThongKeDichVu.Text = "Thống kê dịch vụ";
            this.btnThongKeDichVu.UseVisualStyleBackColor = false;
            this.btnThongKeDichVu.Click += new System.EventHandler(this.btnThongKeDichVu_Click);
            // 
            // ThongKeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.btnThongKeDichVu);
            this.Controls.Add(this.btnThongKeNhanVien);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongKeUC";
            this.Size = new System.Drawing.Size(814, 595);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThongKeNhanVien;
        private System.Windows.Forms.Button btnThongKeDichVu;
    }
}
