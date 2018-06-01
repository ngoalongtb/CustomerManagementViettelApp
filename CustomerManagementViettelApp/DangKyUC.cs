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

        }

        public void Trigger()
        {
            pnDichVuDaDangKy.Controls.Clear();
            pnDichVu.Controls.Clear();
        }
    }
}
