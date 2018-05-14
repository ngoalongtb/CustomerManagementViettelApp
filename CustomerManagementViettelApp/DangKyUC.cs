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
using CustomerManagementViettelApp.Components;
using CustomerManagementViettelApp.App_Code;

namespace CustomerManagementViettelApp
{
    public partial class DangKyUC : UserControl, Triggerable
    {
        private AppDB db = new AppDB();
        public DangKyUC()
        {
            InitializeComponent();
        }

        private void DangKyUC_Load(object sender, EventArgs e)
        {
            LoadDichVu();
            LoadDichVuDaDangKy();
            AppState.DangKyUC = this;
        }

        public void LoadDichVu()
        {
            List<DichVu> dichVus = db.DichVus.ToList();
            foreach (var item in dichVus)
            {
                DichVuComponent dichVuComponent = new DichVuComponent(item);
                pnDichVu.Controls.Add(dichVuComponent);
                dichVuComponent.Show();
            }
        }

        public void LoadDichVuDaDangKy()
        {
            List<TaiKhoanDichVu> dichVus = db.TaiKhoanDichVus.Where(x=>x.TenTaiKhoan == Session.LoginAccount.TenTaiKhoan).ToList();
            foreach (var item in dichVus)
            {
                DichVuComponent dichVuComponent = new DichVuComponent(item.DichVu);
                pnDichVuDaDangKy.Controls.Add(dichVuComponent);
                dichVuComponent.Show();
            }
        }

        public void Trigger()
        {
            pnDichVuDaDangKy.Controls.Clear();
            pnDichVu.Controls.Clear();
            LoadDichVu();
            LoadDichVuDaDangKy();
        }
    }
}
