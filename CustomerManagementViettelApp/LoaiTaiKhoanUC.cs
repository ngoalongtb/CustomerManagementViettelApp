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
    public partial class LoaiTaiKhoanUC : UserControl
    {
        public LoaiTaiKhoanUC()
        {
            InitializeComponent();
        }
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        private void LoaiTaiKhoanUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadDataBinding();
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.LoaiTaiKhoans.Select(x => new { x.MaLoaiTaiKhoan, x.TenLoaiTaiKhoan }).ToList();
        }
        public void ChangHeader()
        {
            dtgv.Columns["MaLoaiTaiKhoan"].HeaderText = "Mã loại tài khoản";
            dtgv.Columns["TenLoaiTaiKhoan"].HeaderText = "Tên loại tài khoản";
        }
        public void LoadDataBinding()
        {
            txtId.DataBindings.Add("Text", dtgv.DataSource, "MaLoaiTaiKhoan", true, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "TenLoaiTaiKhoan", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiTaiKhoan accountType = new LoaiTaiKhoan();
            accountType.TenLoaiTaiKhoan = txtTen.Text;
            try
            {
                db.LoaiTaiKhoans.Add(accountType);
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
            LoaiTaiKhoan accountType = db.LoaiTaiKhoans.Find(int.Parse(txtId.Text));
            accountType.TenLoaiTaiKhoan = txtTen.Text;
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
            LoaiTaiKhoan accountType = db.LoaiTaiKhoans.Find(int.Parse(txtId.Text));

            try
            {
                db.LoaiTaiKhoans.Remove(accountType);
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
            bds.DataSource = db.LoaiTaiKhoans.Where(x => x.MaLoaiTaiKhoan.ToString().Contains(txtTimKiem.Text) || x.TenLoaiTaiKhoan.Contains(txtTimKiem.Text)).ToList();
        }
    }
}
