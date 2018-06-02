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
using CustomerManagementViettelApp.Report;
using DevExpress.XtraReports.UI;

namespace CustomerManagementViettelApp
{
    public partial class DanhSachHopDongUC : UserControl
    {
        public DanhSachHopDongUC()
        {
            InitializeComponent();
        }

        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();


        private void DanhSachHopDong_Load(object sender, EventArgs e)
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
            bds.DataSource = db.HopDongs.Select(x => new { x.MaHopDong, x.HoTen, x.ChucVu, x.NgaySinh, x.NgayTao, x }).ToList();
        }

        public void ChangHeader()
        {
            dtgv.Columns["MaHopDong"].HeaderText = "Mã hợp đồng";
            dtgv.Columns["HoTen"].HeaderText = "Họ tên";
            dtgv.Columns["ChucVu"].HeaderText = "Chức vụ";
            dtgv.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dtgv.Columns["NgayTao"].HeaderText = "Ngày tạo";
        }
        public void LoadDataBinding()
        {
            lblMaHopDong.DataBindings.Add("Text", dtgv.DataSource, "MaHopDong", true, DataSourceUpdateMode.Never);
        }

        public void LoadMore()
        {
            //cbxDanhMuc.DataSource = db.DanhMucs.ToList();
            //cbxDanhMuc.DisplayMember = "TenDanhMuc";
            //cbxDanhMuc.ValueMember = "MaDanhMuc";
        }

        public void HideColumn()
        {
            dtgv.Columns["x"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AppState.ManagerForm.Trigger();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            HopDong hopDong = db.HopDongs.Find(int.Parse(lblMaHopDong.Text));
            HopDongReport report = new HopDongReport(hopDong);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();

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
                    HopDong hopDong = db.HopDongs.Find(int.Parse(lblMaHopDong.Text));
                    db.HopDongs.Remove(hopDong);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    LoadDtgv();
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra!! Không thể xóa hợp đồng này!!");
                }
            }
            else
            {
                //do nothing
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.HopDongs.Select(x => new { x.MaHopDong, x.HoTen, x.ChucVu, x.NgaySinh, x.NgayTao, x }).Where(x => x.MaHopDong.ToString().Contains(txtTimKiem.Text) || x.HoTen.Contains(txtTimKiem.Text)).ToList();
        }
    }
}
