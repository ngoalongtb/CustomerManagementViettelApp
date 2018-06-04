using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CustomerManagementViettelApp.App_Code;

namespace CustomerManagementViettelApp.Report
{
    public partial class ThongKeTheoKhachHangReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportModel model = new ReportModel();
        public object DataBindingMode { get; private set; }
        public ThongKeTheoKhachHangReport()
        {
            InitializeComponent();
        }


        public ThongKeTheoKhachHangReport(ReportModel model)
        {
            InitializeComponent();
            this.model = model;
            Load();
        }

        public void Load()
        {
            //lblFromDate.Text = model.FromDate;
            //lblToDate.Text = model.ToDate;
            //lblDate.Text = model.Date;
            //lblStaff.Text = model.Staff;
        }

    }
}
