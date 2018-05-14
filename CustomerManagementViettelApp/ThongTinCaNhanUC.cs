using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerManagementViettelApp.App_Code;
using CustomerManagementViettelApp.EF;

namespace CustomerManagementViettelApp
{
    public partial class ThongTinCaNhanUC : UserControl
    {
        private AppDB db = new AppDB();
        public ThongTinCaNhanUC()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            TaiKhoan loginAccount = Session.LoginAccount;
            txtDisplayName.Text = Session.LoginAccount.TenHienThi;
            txtUsername.Text = Session.LoginAccount.TenTaiKhoan;

            if(loginAccount.ThongTinTaiKhoan != null)
            {
                txtHoTen.Text = loginAccount.ThongTinTaiKhoan.HoTen;
                txtHinhAnh.Text = loginAccount.ThongTinTaiKhoan.HinhAnh;
                txtEmail.Text = loginAccount.ThongTinTaiKhoan.Email;
                txtSoDienThoai.Text = loginAccount.ThongTinTaiKhoan.SoDienThoai;
                if(loginAccount.ThongTinTaiKhoan.NgaySinh != null)
                {
                    dtpkNgaySinh.Value = loginAccount.ThongTinTaiKhoan.NgaySinh.Value;
                }
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            if (txtPassword.Text != Session.LoginAccount.MatKhau)
            {
                MessageBox.Show("Mật khẩu không chính xác");
                return;
            }
            if (txtDisplayName.Text.Trim() == "")
            {
                MessageBox.Show("Bắt buộc phải nhập tên hiển thị");
                return;
            }
            if (txtNewPass.Text != txtReNewPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp");
                return;
            }
            string strNewPass = Session.LoginAccount.MatKhau;
            if (txtNewPass.Text.Trim() != "")
                strNewPass = txtNewPass.Text;

            TaiKhoan account = db.TaiKhoans.Find(Session.LoginAccount.TenTaiKhoan);
            account.MatKhau = strNewPass;
            account.TenHienThi = txtDisplayName.Text;
            if(account.ThongTinTaiKhoan == null)
            {
                account.ThongTinTaiKhoan = new ThongTinTaiKhoan();
            }

            account.ThongTinTaiKhoan.HoTen = txtHoTen.Text;
            account.ThongTinTaiKhoan.HinhAnh = txtHinhAnh.Text;
            account.ThongTinTaiKhoan.Email = txtEmail.Text;
            account.ThongTinTaiKhoan.SoDienThoai = txtSoDienThoai.Text;
            account.ThongTinTaiKhoan.NgaySinh = dtpkNgaySinh.Value;

            try
            {
                db.SaveChanges();
                Session.LoginAccount = db.TaiKhoans.Find(Session.LoginAccount.TenTaiKhoan);
                MessageBox.Show("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại. Xin lỗi vì sự cố đáng tiếc. Vui lòng gặp admin để sửa lỗi!!!");
            }
        }
    }
}
