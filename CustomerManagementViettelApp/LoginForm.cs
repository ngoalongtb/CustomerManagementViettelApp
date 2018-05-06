using CustomerManagementViettelApp.App_Code;
using CustomerManagementViettelApp.EF;
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
    public partial class LoginForm : Form
    {
        private AppDB db = new AppDB();
        public LoginForm()
        {
            InitializeComponent();
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
            Application.Exit();
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var loginQuery = db.TaiKhoans.Where(x => x.TenTaiKhoan == txtUserName.Text && x.MatKhau == txtPassword.Text);
                if (loginQuery.Count() > 0)
                {
                    this.Hide();
                    TaiKhoan loginAccount = loginQuery.First();
                    Session.LoginAccount = loginAccount;
                    ManagerForm f = new ManagerForm();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối không thành công.\r\n Kiểm tra lại connection string hoặc liên hệ admin");
            }
        }
    }
}
