using CustomerManagementViettelApp.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementViettelApp
{
    public partial class ManagerForm : Form, Triggerable
    {
        public ManagerForm()
        {
            InitializeComponent();
            AppState.ManagerForm = this;
            timer1.Interval = 30;
            timer1.Start();
        }
        #region menu
        private bool isMouseDown = false;
        private int x, y;

        private void pn_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x = e.X;
            y = e.Y;
        }

        private void pn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                this.Location = new Point(this.Location.X + e.X - x, this.Location.Y + e.Y - y);
            }
        }

        private void pn_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x = e.X;
            y = e.Y;
        }

        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                this.Location = new Point(this.Location.X + e.X - x, this.Location.Y + e.Y - y);
            }
        }

        private void lbl_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.LoginAccount = null;
            this.Close();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            if (Session.LoginAccount.LoaiTaiKhoan.TenLoaiTaiKhoan != Commons.Manager)
            {
                pnAdmin.Visible = false;
            }

            if (Session.LoginAccount.LoaiTaiKhoan.TenLoaiTaiKhoan == Commons.Customer)
            {
                btnTaiKhoan.Visible = false;
            }
        }

        private void btnLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            LoaiTaiKhoanUC f = new LoaiTaiKhoanUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            DanhMucUC f = new DanhMucUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeUC f = new ThongKeUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanUC f = new TaiKhoanUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            DichVuUC f = new DichVuUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnMayTinh_Click(object sender, EventArgs e)
        {
            LichSuUC f = new LichSuUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKyUC f = new DangKyUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblChayChu.Location.Y == -200)
            {
                lblChayChu.Location = new Point(lblChayChu.Location.X, 300);
            }
            lblChayChu.Location = new Point(lblChayChu.Location.X, lblChayChu.Location.Y - 1);
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            pn f = new pn();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        public void Trigger()
        {
            DKDichVuUC f = new DKDichVuUC(Session.TaiKhoanQLDV);
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }
    }
}
