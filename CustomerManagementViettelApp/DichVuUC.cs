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
using System.IO;

namespace CustomerManagementViettelApp
{
    public partial class DichVuUC : UserControl
    {
        public DichVuUC()
        {
            InitializeComponent();
        }
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();
        private OpenFileDialog open = new OpenFileDialog();

        private void DichVuUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadMore();
            HideColumn();
            LoadDataBinding();
        }
        public void LoadDtgv()
        {
            bds.DataSource = db.DichVus.Select(x => new { x.MaDichVu, x.TenDichVu, x.Gia, x.KhuyenMai, x.MaDanhMuc, x.DanhMuc.TenDanhMuc, x.MoTa, x.NgayTao, x }).ToList();
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
            txtTenDichVu.DataBindings.Add("Text", dtgv.DataSource, "TenDichVu", true, DataSourceUpdateMode.Never);
            txtGia.DataBindings.Add("Text", dtgv.DataSource, "Gia", true, DataSourceUpdateMode.Never);
            txtKhuyenMai.DataBindings.Add("Text", dtgv.DataSource, "KhuyenMai", true, DataSourceUpdateMode.Never);
            txtMoTa.DataBindings.Add("Text", dtgv.DataSource, "MoTa", true, DataSourceUpdateMode.Never);
            cbxDanhMuc.DataBindings.Add("SelectedValue", dtgv.DataSource, "MaDanhMuc", true, DataSourceUpdateMode.Never);
            txtHinhAnh.DataBindings.Add("Text", dtgv.DataSource, "x.HinhAnh", true, DataSourceUpdateMode.Never);
        }

        public void LoadMore()
        {
            cbxDanhMuc.DataSource = db.DanhMucs.ToList();
            cbxDanhMuc.DisplayMember = "TenDanhMuc";
            cbxDanhMuc.ValueMember = "MaDanhMuc";
        }

        public void HideColumn()
        {
            dtgv.Columns["MaDanhMuc"].Visible = false;
            dtgv.Columns["x"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên danh mục"))
            //    return;
            //else
            DichVu service = new DichVu();
            service.NgayTao = DateTime.Now;
            service.Gia = double.Parse(txtGia.Text);
            service.KhuyenMai = double.Parse(txtKhuyenMai.Text);
            service.MoTa = txtMoTa.Text;
            service.TenDichVu = txtTenDichVu.Text;
            service.MaDanhMuc = (int)cbxDanhMuc.SelectedValue;

            try
            {
                db.DichVus.Add(service);
                db.SaveChanges();
                if (open.CheckFileExists)
                {
                    string directory = AppDomain.CurrentDomain.BaseDirectory;
                    File.Copy(open.FileName, directory + service.MaDichVu + open.SafeFileName);
                    service.HinhAnh = open.SafeFileName;
                }
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DichVu service = db.DichVus.Find(int.Parse(txtMaDichVu.Text));
                service.Gia = double.Parse(txtGia.Text);
                service.KhuyenMai = double.Parse(txtKhuyenMai.Text);
                service.MoTa = txtMoTa.Text;
                service.TenDichVu = txtTenDichVu.Text;
                service.MaDanhMuc = (int)cbxDanhMuc.SelectedValue;

                if (open.CheckFileExists)
                {
                    string directory = AppDomain.CurrentDomain.BaseDirectory;
                    File.Copy(open.FileName, directory + service.MaDichVu + open.SafeFileName);
                    service.HinhAnh = open.SafeFileName;
                }
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DichVu service = db.DichVus.Find(int.Parse(txtMaDichVu.Text));
                db.DichVus.Remove(service);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Tồn tại Máy tính trong danh mục này");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.DichVus.Select(x => new { x.MaDichVu, x.TenDichVu, x.Gia, x.KhuyenMai, x.MaDanhMuc, x.DanhMuc.TenDanhMuc, x.MoTa, x.NgayTao }).Where(x => x.MaDichVu.ToString().Contains(txtTimKiem.Text) || x.TenDichVu.Contains(txtTimKiem.Text)).ToList();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = open.SafeFileName;
            }
        }
    }
}
