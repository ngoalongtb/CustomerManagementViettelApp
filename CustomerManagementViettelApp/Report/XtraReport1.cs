using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CustomerManagementViettelApp.Properties;
using CustomerManagementViettelApp.App_Code;

namespace CustomerManagementViettelApp.Report
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportModel model = new ReportModel();
        public object DataBindingMode { get; private set; }

        public XtraReport1()
        {
            InitializeComponent();
        }

        public XtraReport1(ReportModel model)
        {
            InitializeComponent();
            this.model = model;
            Load();
            
        }

        public void Load()
        {
            lblDoanhThu.Text = model.Total;
            lblFromDate.Text = model.FromDate;
            lblToDate.Text = model.ToDate;
            lblDate.Text = model.Date;
            lblStaff.Text = model.Staff;
        }
    }
}
