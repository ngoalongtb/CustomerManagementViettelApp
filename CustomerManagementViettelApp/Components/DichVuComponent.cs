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

        public DichVuComponent(DichVu service)
        {
            InitializeComponent();
            this.service = service;
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
