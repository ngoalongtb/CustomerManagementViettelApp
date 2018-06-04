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
using CustomerManagementViettelApp.Report;
using DevExpress.XtraReports.UI;

namespace CustomerManagementViettelApp
{
    public partial class ThongKeTheoDichVuUC : UserControl
    {
        private AppDB db = new AppDB();
        private BindingSource bds = new BindingSource();
        public ThongKeTheoDichVuUC()
        {
            InitializeComponent();
        }

        private void ThongKeTheoDichVuUC_Load(object sender, EventArgs e)
        {
            InitParameters();
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
        }

        public void InitParameters()
        {
            dtpkFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpkTo.Value = DateTime.Now;
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.ChiTietHopDongs.Where(u => u.HopDong.NgayTao >= dtpkFrom.Value && u.HopDong.NgayTao <= dtpkTo.Value).GroupBy(u => u.DichVu).Select(x => new { x.Key.MaDichVu, TenDichVu = x.Key.TenDichVu, Count = x.Count() }).OrderByDescending(x => x.Count).ToList();
        }

        public void ChangHeader()
        {
            dtgv.Columns["MaDichVu"].HeaderText = "Mã dịch vụ";
            dtgv.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["Count"].HeaderText = "Số lượt đăng ký";
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ReportModel reportModel = new ReportModel();
            reportModel.Staff = Session.LoginAccount.TenTaiKhoan;
            reportModel.FromDate = dtpkFrom.Value.ToString();
            reportModel.ToDate = dtpkTo.Value.ToString();
            reportModel.Date = DateTime.Now.ToString();



            List<ReportItem> list = new List<ReportItem>();


            var temp = db.ChiTietHopDongs.Where(u => u.HopDong.NgayTao >= dtpkFrom.Value && u.HopDong.NgayTao <= dtpkTo.Value).GroupBy(u => u.DichVu).Select(x => new { x.Key.MaDichVu, TenDichVu = x.Key.TenDichVu, Count = x.Count() }).OrderByDescending(x => x.Count).ToList();

            foreach (var item in temp)
            {
                ReportItem reportItem = new ReportItem();
                reportItem.MaDichVu = item.MaDichVu.ToString();
                reportItem.SoLuotDangKy = item.Count.ToString();
                reportItem.TenDichVu = item.TenDichVu;
                list.Add(reportItem);
            }

            ThongKeTheoDichVuReport report = new ThongKeTheoDichVuReport(reportModel);
            report.DataSource = list;
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }
    }
}
