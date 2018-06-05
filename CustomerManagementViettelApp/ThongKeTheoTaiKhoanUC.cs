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
    public partial class ThongKeTheoTaiKhoanUC : UserControl
    {
        public ThongKeTheoTaiKhoanUC()
        {
            InitializeComponent();
        }

        private AppDB db = new AppDB();
        private BindingSource bds = new BindingSource();

        private void ThongKeTheoTaiKhoanUC_Load(object sender, EventArgs e)
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
            bds.DataSource = db.HopDongs.Where(u => u.NgayTao >= dtpkFrom.Value && u.NgayTao <= dtpkTo.Value).GroupBy(u => u.TaiKhoan).Select(x => new { x.Key.TenTaiKhoan, TenHienThi = x.Key.TenHienThi, Count = x.Count() }).OrderByDescending( x=> x.Count).ToList();
        }

        public void ChangHeader()
        {
            dtgv.Columns["TenTaiKhoan"].HeaderText = "Tên tài khoản";
            dtgv.Columns["TenHienThi"].HeaderText = "Tên hiển thị";
            dtgv.Columns["Count"].HeaderText = "Số hợp đồng";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ReportModel reportModel = new ReportModel();
            reportModel.Staff = Session.LoginAccount.TenTaiKhoan;
            reportModel.FromDate = dtpkFrom.Value.ToShortDateString();
            reportModel.ToDate = dtpkTo.Value.ToShortDateString();
            reportModel.Date = DateTime.Now.ToShortDateString();



            List<ThongKeTheoNhanVienReportItem> list = new List<ThongKeTheoNhanVienReportItem>();


            var temp = db.HopDongs.Where(u => u.NgayTao >= dtpkFrom.Value && u.NgayTao <= dtpkTo.Value).GroupBy(u => u.TaiKhoan).Select(x => new { x.Key.TenTaiKhoan, TenHienThi = x.Key.TenHienThi, Count = x.Count() }).OrderByDescending(x => x.Count).ToList();

            foreach (var item in temp)
            {
                ThongKeTheoNhanVienReportItem reportItem = new ThongKeTheoNhanVienReportItem();
                reportItem.TenTaiKhoan = item.TenTaiKhoan;
                reportItem.TenNhanVien = item.TenHienThi;
                reportItem.SoHopDong = item.Count;
                list.Add(reportItem);
            }

            ThongKeTheoNhanVienReport report = new ThongKeTheoNhanVienReport(reportModel);
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
