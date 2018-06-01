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
            this.lblThanhTien.Text = (service.Gia.Value * (1 - 1.0*service.KhuyenMai.Value/100)).ToString();

            if (service.HinhAnh != null)
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                panel1.BackgroundImage = Image.FromFile(directory + service.MaDichVu + service.HinhAnh);
            }
            
            
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

        }
    }
}
