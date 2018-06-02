using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CustomerManagementViettelApp.EF;
using CustomerManagementViettelApp.App_Code;
using System.Collections.Generic;

namespace CustomerManagementViettelApp.Report
{
    public partial class HopDongReport : DevExpress.XtraReports.UI.XtraReport
    {
        private HopDong hopDong;

        public HopDongReport(HopDong hopDong)
        {
            InitializeComponent();
            this.hopDong = hopDong;

            PrintDetail();
        }

        public void PrintDetail()
        {
            List<ReportChiTietHopDongItem> list = new List<ReportChiTietHopDongItem>();
            int stt = 1;
            foreach (var chiTietHopDong in hopDong.ChiTietHopDongs)
            {
                ReportChiTietHopDongItem item = new ReportChiTietHopDongItem();

                item.DiaChiLapDat = chiTietHopDong.DiaChiLapDat;
                item.GhiChu = chiTietHopDong.GhiChu;
                item.STT = stt.ToString();
                stt++;
                item.TenDichVu = chiTietHopDong.DichVu.TenDichVu;
                list.Add(item);
            }
            this.bindingSource1.DataSource = list;
        }
    }
}
