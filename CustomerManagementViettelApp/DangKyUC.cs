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

namespace CustomerManagementViettelApp
{
    public partial class DangKyUC : UserControl
    {
        private AppDB db = new AppDB();
        public DangKyUC()
        {
            InitializeComponent();
        }

        private void DangKyUC_Load(object sender, EventArgs e)
        {
            List<DichVu> dichVus = db.DichVus.ToList();
            foreach (var item in dichVus)
            {
                DichVuComponent dichVuComponent = new DichVuComponent(item);
                pnDichVu.Controls.Add(dichVuComponent);
                dichVuComponent.Show();
            }
        }
    }
}
