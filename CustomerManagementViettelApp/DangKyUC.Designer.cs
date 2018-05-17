namespace CustomerManagementViettelApp
{
    partial class DangKyUC
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
            this.pnDichVuDaDangKy = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDichVu = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnDanhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.pnDanhMuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDichVuDaDangKy
            // 
            this.pnDichVuDaDangKy.AutoScroll = true;
            this.pnDichVuDaDangKy.Location = new System.Drawing.Point(21, 51);
            this.pnDichVuDaDangKy.Name = "pnDichVuDaDangKy";
            this.pnDichVuDaDangKy.Size = new System.Drawing.Size(770, 243);
            this.pnDichVuDaDangKy.TabIndex = 0;
            // 
            // pnDichVu
            // 
            this.pnDichVu.AutoScroll = true;
            this.pnDichVu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnDichVu.Location = new System.Drawing.Point(22, 343);
            this.pnDichVu.Name = "pnDichVu";
            this.pnDichVu.Size = new System.Drawing.Size(770, 236);
            this.pnDichVu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(19, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách dịch vụ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dịch vụ đã đăng ký:";
            // 
            // pnDanhMuc
            // 
            this.pnDanhMuc.Controls.Add(this.btnTatCa);
            this.pnDanhMuc.Location = new System.Drawing.Point(168, 306);
            this.pnDanhMuc.Name = "pnDanhMuc";
            this.pnDanhMuc.Size = new System.Drawing.Size(622, 30);
            this.pnDanhMuc.TabIndex = 2;
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnTatCa.FlatAppearance.BorderSize = 0;
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTatCa.Location = new System.Drawing.Point(3, 3);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(97, 28);
            this.btnTatCa.TabIndex = 47;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // DangKyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.pnDanhMuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnDichVu);
            this.Controls.Add(this.pnDichVuDaDangKy);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangKyUC";
            this.Size = new System.Drawing.Size(814, 595);
            this.Load += new System.EventHandler(this.DangKyUC_Load);
            this.pnDanhMuc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnDichVuDaDangKy;
        private System.Windows.Forms.FlowLayoutPanel pnDichVu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pnDanhMuc;
        private System.Windows.Forms.Button btnTatCa;
    }
}
