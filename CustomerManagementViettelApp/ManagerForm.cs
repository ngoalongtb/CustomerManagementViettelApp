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

        private void ClearAllActiveButton()
        {
            btnThongTinCaNhan.BackColor = Color.FromArgb(21, 21, 21);
            btnDangKy.BackColor = Color.FromArgb(21, 21, 21);
            btnHopDong.BackColor = Color.FromArgb(21, 21, 21);
            btnTaiKhoan.BackColor = Color.FromArgb(21, 21, 21);
            btnDanhMuc.BackColor = Color.FromArgb(21, 21, 21);
            btnDichVu.BackColor = Color.FromArgb(21, 21, 21);
            btnLoaiTaiKhoan.BackColor = Color.FromArgb(21, 21, 21);
            btnThongKe.BackColor = Color.FromArgb(21, 21, 21);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.LoginAccount = null;
            this.Close();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            if (Session.LoginAccount.LoaiTaiKhoan.TenLoaiTaiKhoan == Commons.Manager)
            {
                
            }

            if (Session.LoginAccount.LoaiTaiKhoan.TenLoaiTaiKhoan == Commons.Admin)
            {
                btnDangKy.Visible = false;
                btnHopDong.Visible = false;
                //btnTaiKhoan.Visible = false;
                btnDanhMuc.Visible = false;
                btnDichVu.Visible = false;
                //btnLoaiTaiKhoan.Visible = false;
                btnThongKe.Visible = false;
            }

            if (Session.LoginAccount.LoaiTaiKhoan.TenLoaiTaiKhoan == Commons.Staff)
            {
                btnDangKy.Visible = false;
                btnHopDong.Visible = false;
                //btnTaiKhoan.Visible = false;
                //btnDanhMuc.Visible = false;
                btnDichVu.Visible = false;
                //btnLoaiTaiKhoan.Visible = false;
                //btnThongKe.Visible = false;
            }
        }

        private void btnLoaiTaiKhoan_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnLoaiTaiKhoan.BackColor = Color.FromArgb(255, 128, 0);
            LoaiTaiKhoanUC f = new LoaiTaiKhoanUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnDanhMuc.BackColor = Color.FromArgb(255, 128, 0);
            DanhMucUC f = new DanhMucUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnThongKe.BackColor = Color.FromArgb(255, 128, 0);
            ThongKeUC f = new ThongKeUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnTaiKhoan.BackColor = Color.FromArgb(255, 128, 0);
            TaiKhoanUC f = new TaiKhoanUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnDichVu.BackColor = Color.FromArgb(255, 128, 0);
            DichVuUC f = new DichVuUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnDangKy.BackColor = Color.FromArgb(255, 128, 0);
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
            ClearAllActiveButton();
            btnThongTinCaNhan.BackColor = Color.FromArgb(255, 128, 0);
            pn f = new pn();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            ClearAllActiveButton();
            btnHopDong.BackColor = Color.FromArgb(255, 128, 0);
            DanhSachHopDongUC f = new DanhSachHopDongUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        public void Trigger()
        {
            ClearAllActiveButton();
            btnDangKy.BackColor = Color.FromArgb(255, 128, 0);
            DangKyUC f = new DangKyUC();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }
    }
}
