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
    public partial class ThongKeTheoKhachHangUC : UserControl
    {
        private AppDB db = new AppDB();
        private BindingSource bds = new BindingSource();
        public ThongKeTheoKhachHangUC()
        {
            InitializeComponent();
        }

        private void ThongKeTheoKhachHangUC_Load(object sender, EventArgs e)
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
            bds.DataSource = db.ChiTietHopDongs.Where(u => u.HopDong.NgayTao >= dtpkFrom.Value && u.HopDong.NgayTao <= dtpkTo.Value).GroupBy(u => new { u.HopDong.HoTen, u.HopDong.Cmtnd }).Select(x => new { x.Key.HoTen, x.Key.Cmtnd, Count = x.Count() }).OrderByDescending(x => x.Count).Take(5).ToList();
        }

        public void ChangHeader()
        {
            dtgv.Columns["HoTen"].HeaderText = "Tên khách hàng";
            dtgv.Columns["Cmtnd"].HeaderText = "CMTND";
            dtgv.Columns["Count"].HeaderText = "Số lượt đăng ký";
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ReportModel reportModel = new ReportModel();
            reportModel.Staff = Session.LoginAccount.TenTaiKhoan;
            reportModel.FromDate = dtpkFrom.Value.ToShortDateString();
            reportModel.ToDate = dtpkTo.Value.ToShortDateString();
            reportModel.Date = DateTime.Now.ToShortDateString();



            List<ThongKeTheoKhachHangReportItem> list = new List<ThongKeTheoKhachHangReportItem>();


            var temp = db.ChiTietHopDongs.Where(u => u.HopDong.NgayTao >= dtpkFrom.Value && u.HopDong.NgayTao <= dtpkTo.Value).GroupBy(u => new { u.HopDong.HoTen, u.HopDong.Cmtnd }).Select(x => new { x.Key.HoTen, x.Key.Cmtnd, Count = x.Count() }).OrderByDescending(x => x.Count).Take(5).ToList();

            foreach (var item in temp)
            {
                ThongKeTheoKhachHangReportItem reportItem = new ThongKeTheoKhachHangReportItem();
                reportItem.TenKhachHang = item.HoTen.ToString();
                reportItem.CMTND = item.Cmtnd.ToString();
                reportItem.SoHopDong = item.Count;
                list.Add(reportItem);
            }

            ThongKeTheoKhachHangReport report = new ThongKeTheoKhachHangReport(reportModel);
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
