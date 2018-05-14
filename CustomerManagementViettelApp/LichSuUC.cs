﻿using System;
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
    public partial class LichSuUC : UserControl
    {
        public LichSuUC()
        {
            InitializeComponent();
        }
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        private void LichSuUC_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadDataBinding();
            HideColumns();
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.LichSuDangKies.Where(x => x.TenTaiKhoan == Session.LoginAccount.TenTaiKhoan).Select(x => new { x.DichVu.TenDichVu, x.NgayTao, x }).ToList();
        }

        public void ChangHeader()
        {
            dtgv.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
            dtgv.Columns["NgayTao"].HeaderText = "Ngày tạo";
        }

        public void LoadDataBinding()
        {
            //txtId.DataBindings.Add("Text", dtgv.DataSource, "MaLoaiTaiKhoan", true, DataSourceUpdateMode.Never);
            //txtTen.DataBindings.Add("Text", dtgv.DataSource, "TenLoaiTaiKhoan", true, DataSourceUpdateMode.Never);
        }

        public void HideColumns()
        {
            dtgv.Columns["x"].Visible = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.LichSuDangKies.Where(x => x.TenTaiKhoan == Session.LoginAccount.TenTaiKhoan && (x.DichVu.TenDichVu.Contains(txtTimKiem.Text)) && x.MaDichVu.ToString().Contains(txtTimKiem.Text)).Select(x => new { x.DichVu.TenDichVu, x.NgayTao, x }).ToList();
        }
    }
}
