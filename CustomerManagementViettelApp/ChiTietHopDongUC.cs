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

namespace CustomerManagementViettelApp
{
    public partial class ChiTietHopDongUC : UserControl
    {
        private HopDong hopDong;
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();
        public ChiTietHopDongUC()
        {
            InitializeComponent();
            if (Session.HopDong != null)
            {
                this.hopDong = Session.HopDong;
            }

            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
        }

        public ChiTietHopDongUC(HopDong hopDong)
        {
            InitializeComponent();
            this.hopDong = hopDong;

            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
        }

        private void ChiTietHopDongUC_Load(object sender, EventArgs e)
        {
            lblCmtnd.Text = hopDong.Cmtnd;
            lblDienThoai.Text = hopDong.DienThoai;
            lblDuong.Text = hopDong.Duong;
            lblTinhThanhPho.Text = hopDong.Tinh;
            lblTo.Text = hopDong.To;
            lblHoTen.Text = hopDong.HoTen;
            lblMaSoThue.Text = hopDong.MaSoThue;
            if (hopDong.NgayTao != null)
            {
                lblNgay.Text = hopDong.NgayTao.Value.ToShortDateString();
            }
            lblNoiCap.Text = hopDong.NoiCap;
            lblPhuongXa.Text = hopDong.Phuong;
            lblSoNha.Text = hopDong.SoNha;
            lblQuanHuyen.Text = hopDong.Quan;
            if(hopDong.NgayCap != null)
            {
                lblNgayCap.Text = hopDong.NgayCap.Value.ToShortDateString();
            }
            if(hopDong.GioiTinh != null)
            {
                lblGioiTinh.Text = hopDong.GioiTinh.Value ? "Nữ" : "Nam";
            }
            if(hopDong.NgaySinh != null)
            {
                lblNgaySinh.Text = hopDong.NgaySinh.Value.ToShortDateString();
            }
            lblChucVu.Text = hopDong.ChucVu;
        }

        public void LoadDtgv()
        {
            bds.DataSource = hopDong.ChiTietHopDongs.Select(x => new { x.DichVu.MaDichVu, x.DichVu.TenDichVu, x.DiaChiLapDat, x.GhiChu }).ToList();
        }
        public void ChangHeader()
        {
            dtgv.Columns["MaDichVu"].HeaderText = "Mã danh mục";
            dtgv.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["DiaChiLapDat"].HeaderText = "Địa chỉ lắp đặt";
            dtgv.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

    }
}
