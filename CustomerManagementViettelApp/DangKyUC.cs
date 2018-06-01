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
using CustomerManagementViettelApp.App_Code;

namespace CustomerManagementViettelApp
{
    public partial class DangKyUC : UserControl, Triggerable
    {
        private AppDB db = new AppDB();
        private BindingSource bds = new BindingSource();
        private List<ChiTietHopDong> chiTietHopDongs = new List<ChiTietHopDong>();

        public DangKyUC()
        {
            InitializeComponent();
        }


        public void LoadDtgv()
        {
            bds.DataSource = chiTietHopDongs.Select(x => new { x.DichVu.MaDichVu, x.DichVu.TenDichVu, x.DiaChiLapDat, x.GhiChu }).ToList();
        }
        public void ChangHeader()
        {
            dtgv.Columns["MaDichVu"].HeaderText = "Mã danh mục";
            dtgv.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["DiaChiLapDat"].HeaderText = "Địa chỉ lắp đặt";
            dtgv.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void DangKyUC_Load(object sender, EventArgs e)
        {
            lblNgay.Text = DateTime.Now.ToShortDateString();
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadMore();
        }

        public void LoadMore()
        {
            var source = new AutoCompleteStringCollection();
            List<DichVu> dichVus = db.DichVus.ToList();
            foreach (var item in dichVus)
            {
                source.Add(item.MaDichVu + " - " + item.TenDichVu);
            }
            txtMaDichVu.AutoCompleteCustomSource = source;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                HopDong hopDong = new HopDong();
                hopDong.NgayTao = DateTime.Now;
                hopDong.HoTen = txtHoTen.Text;
                hopDong.ChucVu = txtChucVu.Text;
                hopDong.NgaySinh = dtpkNgaySinh.Value;
                hopDong.NgayCap = dtpkNgayCap.Value;
                hopDong.GioiTinh = cbxGioiTinh.Text == "Nam" ? false : true;
                hopDong.Cmtnd = txtCmtnd.Text;
                hopDong.NoiCap = txtNoiCap.Text;
                hopDong.SoNha = txtSoNha.Text;
                hopDong.Duong = txtDuong.Text;
                hopDong.To = txtTo.Text;
                hopDong.Quan = txtQuan.Text;
                hopDong.Phuong = txtPhuongXa.Text;
                hopDong.Tinh = txtTinh.Text;
                hopDong.MaSoThue = txtMaSoThue.Text;
                hopDong.NhanVien = Session.LoginAccount.TenTaiKhoan;
                hopDong.DienThoai = txtDienThoai.Text;
                hopDong.ChiTietHopDongs = chiTietHopDongs;
                db.HopDongs.Add(hopDong);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra!!! Vui lòng kiểm tra lại !!!");
            }
            
        }

        public void Trigger()
        {

        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHopDong chiTietHopDong = new ChiTietHopDong();
                DichVu dichVu = db.DichVus.Find(int.Parse(txtMaDichVu.Text.Split('-')[0]));
                chiTietHopDong.GhiChu = txtGhiChu.Text;
                chiTietHopDong.DiaChiLapDat = txtDiaChiLapDat.Text;
                chiTietHopDong.DichVu = dichVu;
                chiTietHopDongs.Add(chiTietHopDong);
                LoadDtgv();

            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm");
            }
            

        }
    }
}
