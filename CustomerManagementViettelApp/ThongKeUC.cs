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
using DevExpress.XtraReports.UI;
using CustomerManagementViettelApp.Report;
using CustomerManagementViettelApp.App_Code;

namespace CustomerManagementViettelApp
{
    public partial class ThongKeUC : UserControl
    {
        public ThongKeUC()
        {
            InitializeComponent();
        }

        private void btnThongKeNhanVien_Click(object sender, EventArgs e)
        {
            AppState.ManagerForm.Trigger(Commons.ThongKeTheoNhanVien);
        }

        private void btnThongKeDichVu_Click(object sender, EventArgs e)
        {
            AppState.ManagerForm.Trigger(Commons.ThongKeTheoDichVu);
        }

        private void btnThongKeKhachHang_Click(object sender, EventArgs e)
        {

        }
    }
}
