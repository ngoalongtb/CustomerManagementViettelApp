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
            this.SuspendLayout();
            // 
            // pnDichVuDaDangKy
            // 
            this.pnDichVuDaDangKy.Location = new System.Drawing.Point(21, 66);
            this.pnDichVuDaDangKy.Name = "pnDichVuDaDangKy";
            this.pnDichVuDaDangKy.Size = new System.Drawing.Size(770, 228);
            this.pnDichVuDaDangKy.TabIndex = 0;
            // 
            // pnDichVu
            // 
            this.pnDichVu.Location = new System.Drawing.Point(22, 343);
            this.pnDichVu.Name = "pnDichVu";
            this.pnDichVu.Size = new System.Drawing.Size(770, 228);
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
            // DangKyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnDichVu);
            this.Controls.Add(this.pnDichVuDaDangKy);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DangKyUC";
            this.Size = new System.Drawing.Size(814, 595);
            this.Load += new System.EventHandler(this.DangKyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnDichVuDaDangKy;
        private System.Windows.Forms.FlowLayoutPanel pnDichVu;
        private System.Windows.Forms.Label label1;
    }
}
