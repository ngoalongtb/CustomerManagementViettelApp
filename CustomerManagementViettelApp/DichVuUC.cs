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
    public partial class DichVuUC : UserControl
    {
        public DichVuUC()
        {
            InitializeComponent();
        }
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        private void DichVuUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadDataBinding();
        }
        public void LoadDtgv()
        {
            bds.DataSource = db.DichVus.Select(x => new { x.MaDichVu, x.TenDichVu, x.Gia, x.KhuyenMai, x.DanhMuc.MaDanhMuc }).ToList();
        }
        public void ChangHeader()
        {
            //dtgv.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
            //dtgv.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
            //dtgv.Columns["NgayTao"].HeaderText = "Ngày tạo";
        }
        public void LoadDataBinding()
        {
            //txtId.DataBindings.Add("Text", dtgv.DataSource, "MaDanhMuc", true, DataSourceUpdateMode.Never);
            //txtTen.DataBindings.Add("Text", dtgv.DataSource, "TenDanhMuc", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên danh mục"))
            //    return;
            //else
            DanhMuc category = new DanhMuc();
            category.NgayTao = DateTime.Now;
            category.TenDanhMuc = txtTen.Text;
            try
            {
                db.DanhMucs.Add(category);
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
            DichVu service = db.DichVus.Find(txtCmtnd.Text);
            //category.TenDanhMuc = txtTen.Text;
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
            DichVu service = db.DichVus.Find(txtCmtnd.Text);

            try
            {
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
            //bds.DataSource = db.DanhMucs.Where(x => x.MaDanhMuc.ToString().Contains(txtId.Text) || x.TenDanhMuc.Contains(txtTen.Text));
        }

        
    }
}
