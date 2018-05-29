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
    public partial class DKDichVuUC : UserControl
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();
        private TaiKhoan taiKhoan;

        public DKDichVuUC(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
        }

        private void DKDichVuUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            HideColumn();
            LoadDataBinding();
            LoadMore();
            LoadInfo();
        }

        public void LoadInfo()
        {
            if(taiKhoan.ThongTinTaiKhoan != null)
            {
                lblHoTen.Text = taiKhoan.ThongTinTaiKhoan.HoTen;
                lblSoDienThoai.Text = taiKhoan.ThongTinTaiKhoan.SoDienThoai;
                lblEmail.Text = taiKhoan.ThongTinTaiKhoan.Email;
            }
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.TaiKhoanDichVus.Where(x => x.TaiKhoan.TenTaiKhoan == taiKhoan.TenTaiKhoan).Select(x => new { x.DichVu.MaDichVu, x.DichVu.TenDichVu, x.DichVu.Gia, x.DichVu.KhuyenMai, x.DichVu.MaDanhMuc, x.DichVu.DanhMuc.TenDanhMuc, x.DichVu.MoTa, x.DichVu.NgayTao }).Where(x => x.MaDichVu.ToString().Contains(txtTimKiem.Text) || x.TenDichVu.Contains(txtTimKiem.Text)).ToList();
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.TaiKhoanDichVus.Where(x => x.TaiKhoan.TenTaiKhoan == taiKhoan.TenTaiKhoan).Select(x => new { x.DichVu.MaDichVu, x.DichVu.TenDichVu, x.DichVu.Gia, x.DichVu.KhuyenMai, x.DichVu.MaDanhMuc, x.DichVu.DanhMuc.TenDanhMuc, x.DichVu.MoTa, x.DichVu.NgayTao }).ToList();
        }
        public void ChangHeader()
        {
            dtgv.Columns["MaDichVu"].HeaderText = "Mã DV";
            dtgv.Columns["TenDichVu"].HeaderText = "Tên DV";
            dtgv.Columns["Gia"].HeaderText = "Giá";
            dtgv.Columns["KhuyenMai"].HeaderText = "Khuyến mại";
            dtgv.Columns["MaDanhMuc"].HeaderText = "Mã DM";
            dtgv.Columns["TenDanhMuc"].HeaderText = "Tên DM";
            dtgv.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dtgv.Columns["MoTa"].HeaderText = "Mô tả";
        }
        public void LoadDataBinding()
        {
            txtMaDichVu.DataBindings.Add("Text", dtgv.DataSource, "MaDichVu", true, DataSourceUpdateMode.Never);
        }

        public void HideColumn()
        {
            dtgv.Columns["MoTa"].Visible = false;
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //try
            //{
                string maDichVuStr = txtMaDichVu.Text.Split(' ')[0];
                int maDichVu = int.Parse(maDichVuStr);
                DichVu dichVu = db.DichVus.Find(maDichVu);
                TaiKhoanDichVu taiKhoanDichVu = new TaiKhoanDichVu();
                taiKhoanDichVu.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                taiKhoanDichVu.MaDichVu = maDichVu;
                taiKhoanDichVu.NgayTao = DateTime.Now;
                db.TaiKhoanDichVus.Add(taiKhoanDichVu);

                LichSuDangKy lichSu = new LichSuDangKy();
                lichSu.Gia = dichVu.Gia * (100 - dichVu.KhuyenMai);
                lichSu.NgayTao = DateTime.Now;
                lichSu.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                lichSu.MaDichVu = maDichVu;
                db.LichSuDangKies.Add(lichSu);
                db.SaveChanges();
                MessageBox.Show("Đăng ký thành công");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Có lỗi xảy ra");
            //}
            

        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                string maDichVuStr = txtMaDichVu.Text.Split(' ')[0];
                int maDichVu = int.Parse(maDichVuStr);
                TaiKhoanDichVu taiKhoanDichVu = db.TaiKhoanDichVus.SingleOrDefault(x => x.TenTaiKhoan == taiKhoan.TenTaiKhoan && x.MaDichVu == maDichVu);
                db.TaiKhoanDichVus.Remove(taiKhoanDichVu);
                db.SaveChanges();
                MessageBox.Show("Hủy đăng ký thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Hủy đăng ký không thành công");
            }
        }
    }
}
