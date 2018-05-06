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
            this.lblKhuyenMai.Text = service.KhuyenMai.ToString();
            this.lblThanhTien.Text = (service.Gia.Value * (100 - service.KhuyenMai.Value)).ToString();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

        }
    }
}
