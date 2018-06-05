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
            PrintParam();
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

        public void PrintParam()
        {
            lblHoTen.Text = hopDong.HoTen;
            lblTo.Text = hopDong.To;
            lblTinh.Text = hopDong.Tinh;
            lblNoiCap.Text = hopDong.NoiCap;
            lblPhuongXa.Text = hopDong.Phuong;
            lblQuanHuyen.Text = hopDong.Quan;
            lblSoNha.Text = hopDong.SoNha;
            lblMaSoThue.Text = hopDong.MaSoThue;
            if(hopDong.NgaySinh != null)
            {
                lblNgaySinh.Text = hopDong.NgaySinh.Value.ToShortDateString();
            }
            if(hopDong.NgayCap != null)
            {
                lblNgayCap.Text = hopDong.NgayCap.Value.ToShortDateString();
            }
            lblTinh.Text = hopDong.Tinh;
            if (hopDong.GioiTinh != null)
            {
                lblGioiTinh.Text = hopDong.GioiTinh.Value ? "Nữ" : "Nam";
            }
        }
    }
}
