using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerManagementViettelApp.EF;
using CustomerManagementViettelApp.App_Code;

namespace CustomerManagementViettelApp.Components
{
    public partial class DichVuComponent : UserControl
    {

        private DichVu service;
        private AppDB db = new AppDB();
        private Boolean registered;

        public bool Registered
        {
            get
            {
                return registered;
            }

            set
            {
                registered = value;
            }
        }

        public DichVuComponent(DichVu service)
        {
            InitializeComponent();
            this.service = service;
        }

        public DichVuComponent(DichVu service, bool registered)
        {
            InitializeComponent();
            this.service = service;
            this.Registered = registered;
            if(registered)
            {
                btnDangKy.Text = "Hủy ĐK";
            }
        }

        private void DichVuComponent_Load(object sender, EventArgs e)
        {
            this.lblTenDichVu.Text = service.TenDichVu;
            this.lblGia.Text = service.Gia.ToString();
            this.lblKhuyenMai.Text = service.KhuyenMai.ToString() + "%";
            this.lblThanhTien.Text = (service.Gia.Value * (100 - service.KhuyenMai.Value)).ToString();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(Registered)
            {
                HuyDangKy();
            } else
            {
                DangKy();
            }
        }

        private void HuyDangKy()
        {
            try
            {
                TaiKhoanDichVu taiKhoanDichVu = db.TaiKhoanDichVus.SingleOrDefault(x => x.TenTaiKhoan == Session.LoginAccount.TenTaiKhoan && x.MaDichVu == service.MaDichVu);
                db.TaiKhoanDichVus.Remove(taiKhoanDichVu);
                db.SaveChanges();
                MessageBox.Show("Hủy đăng ký thành công");
                AppState.DangKyUC.Trigger();
            }
            catch (Exception)
            {
                MessageBox.Show("Hủy đăng ký không thành công");
            }
        }
        private void DangKy()
        {
            try
            {
                TaiKhoanDichVu taiKhoanDichVu = new TaiKhoanDichVu();
                taiKhoanDichVu.TenTaiKhoan = Session.LoginAccount.TenTaiKhoan;
                taiKhoanDichVu.MaDichVu = this.service.MaDichVu;
                taiKhoanDichVu.NgayTao = DateTime.Now;
                db.TaiKhoanDichVus.Add(taiKhoanDichVu);

                LichSuDangKy lichSu = new LichSuDangKy();
                lichSu.Gia = service.Gia * (100 - service.KhuyenMai);
                lichSu.NgayTao = DateTime.Now;
                lichSu.TenTaiKhoan = Session.LoginAccount.TenTaiKhoan;
                lichSu.MaDichVu = this.service.MaDichVu;
                db.LichSuDangKies.Add(lichSu);
                db.SaveChanges();
                MessageBox.Show("Đăng ký thành công");
                AppState.DangKyUC.Trigger();
            }
            catch (Exception)
            {
                MessageBox.Show("Đăng ký không thành công");
            }
        }
    }
}
