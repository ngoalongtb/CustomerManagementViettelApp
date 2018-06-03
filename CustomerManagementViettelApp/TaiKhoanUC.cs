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
    public partial class TaiKhoanUC : UserControl
    {
        public TaiKhoanUC()
        {
            InitializeComponent();
        }
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        private void TaiKhoanUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadMore();
            LoadDataBinding();
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.TaiKhoans.Select(x => new { x.TenTaiKhoan, x.TenHienThi, x.MaLoaiTaiKhoan, x.LoaiTaiKhoan.TenLoaiTaiKhoan, x.NgayTao }).ToList();
        }
        public void ChangHeader()
        {
            dtgv.Columns["TenTaiKhoan"].HeaderText = "Tên tài khoản";
            dtgv.Columns["TenHienThi"].HeaderText = "Tên hiển thị";
            dtgv.Columns["MaLoaiTaiKhoan"].HeaderText = "Mã loại tài khoản";
            dtgv.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dtgv.Columns["TenLoaiTaiKhoan"].HeaderText = "Loại tài khoản";
        }
        public void LoadDataBinding()
        {
            txtUsername.DataBindings.Add("Text", dtgv.DataSource, "TenTaiKhoan", true, DataSourceUpdateMode.Never);
            txtDisplayName.DataBindings.Add("Text", dtgv.DataSource, "TenHienThi", true, DataSourceUpdateMode.Never);
            cbxType.DataBindings.Add("SelectedValue", dtgv.DataSource, "MaLoaiTaiKhoan", true, DataSourceUpdateMode.Never);
            cbxType.SelectedValue = "";
        }

        public void LoadMore()
        {
            cbxType.DataSource = db.LoaiTaiKhoans.ToList();
            cbxType.DisplayMember = "TenLoaiTaiKhoan";
            cbxType.ValueMember = "MaLoaiTaiKhoan";
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên danh mục"))
            //    return;
            //else
            TaiKhoan account = new TaiKhoan();
            account.TenTaiKhoan = txtUsername.Text;
            account.TenHienThi = txtDisplayName.Text;
            account.NgayTao = DateTime.Now;
            account.MatKhau = "12345";
            account.MaLoaiTaiKhoan = (int)cbxType.SelectedValue;
            //category.TenDanhMuc = txtTen.Text;
            try
            {
                db.TaiKhoans.Add(account);
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công. Mật khẩu mặc định là '12345'");
                LoadDtgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm mới không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan account = db.TaiKhoans.Find(txtUsername.Text);
            account.TenHienThi = txtDisplayName.Text;
            account.MaLoaiTaiKhoan = (int)cbxType.SelectedValue;
            try
            {
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
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa",
                                     "Xác nhận!!",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                TaiKhoan account = db.TaiKhoans.Find(txtUsername.Text);
                try
                {
                    db.TaiKhoans.Remove(account);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    LoadDtgv();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa! Có lỗi xảy ra");
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.TaiKhoans.Where(x => x.TenHienThi.ToString().Contains(txtTimKiem.Text) 
            || x.TenTaiKhoan.Contains(txtTimKiem.Text) || x.LoaiTaiKhoan.TenLoaiTaiKhoan.Contains(txtTimKiem.Text)).ToList();
        }
    }
}
