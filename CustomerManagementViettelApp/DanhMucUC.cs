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
    public partial class DanhMucUC : UserControl
    {
        public DanhMucUC()
        {
            InitializeComponent();
        }

        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();


        private void DanhMucUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadDataBinding();
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.DanhMucs.Select(x => new { x.MaDanhMuc, x.TenDanhMuc, x.NgayTao}).ToList();
        }
        public void ChangHeader()
        {
            dtgv.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
            dtgv.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
            dtgv.Columns["NgayTao"].HeaderText = "Ngày tạo";
        }
        public void LoadDataBinding()
        {
            txtId.DataBindings.Add("Text", dtgv.DataSource, "MaDanhMuc", true, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "TenDanhMuc", true, DataSourceUpdateMode.Never);
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
            try
            {
                DanhMuc category = db.DanhMucs.Find(int.Parse(txtId.Text));
                category.TenDanhMuc = txtTen.Text;
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
                

                try
                {
                    DanhMuc category = db.DanhMucs.Find(int.Parse(txtId.Text));
                    db.DanhMucs.Remove(category);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    LoadDtgv();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.DanhMucs.Where(x => x.MaDanhMuc.ToString().Contains(txtTimKiem.Text) || x.TenDanhMuc.Contains(txtTimKiem.Text)).ToList();
        }
    }
}
