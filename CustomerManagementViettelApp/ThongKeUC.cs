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

namespace CustomerManagementViettelApp
{
    public partial class ThongKeUC : UserControl
    {
        public ThongKeUC()
        {
            InitializeComponent();
        }
        private AppDB db = new AppDB();
        private BindingSource bds = new BindingSource();

        private void ThongKeUC_Load(object sender, EventArgs e)
        {
            InitParameters();
            LoadDtgv();
            CalculateMoney();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadDataBinding();
            HideColumns();
        }

        public void InitParameters()
        {
            dtpkFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpkTo.Value = DateTime.Now;
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.LichSuDangKies.Where(u => u.NgayTao >= dtpkFrom.Value && u.NgayTao <= dtpkTo.Value).GroupBy(u => u.DichVu).Select(x => new { x.Key.MaDichVu, TenDichVu=x.Key.TenDichVu, Count = x.Count() }).ToList();
        }

        public void CalculateMoney()
        {
            lblTongTien.Text = db.LichSuDangKies.Where(u => u.NgayTao >= dtpkFrom.Value && u.NgayTao <= dtpkTo.Value).Sum(x => x.Gia).ToString();
        }

        public void ChangHeader()
        {
            dtgv.Columns["MaDichVu"].HeaderText = "Mã dịch vụ";
            dtgv.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["Count"].HeaderText = "Số lượt đăng ký";
        }

        public void LoadDataBinding()
        {
            //lblMaDichVu.DataBindings.Add("Text", dtgv.DataSource, "x.DichVu.MaDichVu", true, DataSourceUpdateMode.Never);
            //lblTenDichVu.DataBindings.Add("Text", dtgv.DataSource, "x.DichVu.TenDichVu", true, DataSourceUpdateMode.Never);
            //lblGia.DataBindings.Add("Text", dtgv.DataSource, "x.DichVu.Gia", true, DataSourceUpdateMode.Never);
            //lblKhuyenMai.DataBindings.Add("Text", dtgv.DataSource, "x.DichVu.KhuyenMai", true, DataSourceUpdateMode.Never);
            //lblMoTa.DataBindings.Add("Text", dtgv.DataSource, "x.DichVu.MoTa", true, DataSourceUpdateMode.Never);
        }

        public void HideColumns()
        {
            //dtgv.Columns["x"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDtgv();
            CalculateMoney();
        }
    }
}
