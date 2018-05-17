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
        public DangKyUC()
        {
            InitializeComponent();
        }

        private void DangKyUC_Load(object sender, EventArgs e)
        {
            LoadDichVu();
            LoadDichVuDaDangKy();
            LoadDanhMuc();
            AppState.DangKyUC = this;
        }

        public void LoadDichVu()
        {
            List<DichVu> dichVus = db.DichVus.ToList();
            pnDichVu.Controls.Clear();
            foreach (var item in dichVus)
            {
                DichVuComponent dichVuComponent = new DichVuComponent(item);
                pnDichVu.Controls.Add(dichVuComponent);
                dichVuComponent.Show();
            }
        }

        public void LoadDichVuDaDangKy()
        {
            List<TaiKhoanDichVu> dichVus = db.TaiKhoanDichVus.Where(x=>x.TenTaiKhoan == Session.LoginAccount.TenTaiKhoan).ToList();
            foreach (var item in dichVus)
            {
                DichVuComponent dichVuComponent = new DichVuComponent(item.DichVu, true);
                pnDichVuDaDangKy.Controls.Add(dichVuComponent);
                dichVuComponent.Show();
            }
        }

        public void LoadDanhMuc()
        {
            List<DanhMuc> danhMucs = db.DanhMucs.ToList();
            foreach (var item in danhMucs)
            {
                Button btn = CreateButton(item);
                btn.Show();
                pnDanhMuc.Controls.Add(btn);
            }
        }

        public Button CreateButton(DanhMuc danhMuc)
        {
            Button btn = new Button();
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("Calibri", 12F);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Name = "btnDanhMuc_" + danhMuc.MaDanhMuc;
            btn.Height = 27;
            btn.AutoSize = true;
            btn.TabIndex = 47;
            btn.Text = danhMuc.TenDanhMuc;
            btn.Tag = danhMuc;
            btn.UseVisualStyleBackColor = false;
            btn.Click += btnDanhMuc_Click;

            return btn;
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            DanhMuc danhMuc = (DanhMuc)((sender as Button).Tag);
            pnDichVu.Controls.Clear();
            List<DichVu> dichVus = db.DichVus.Where(x => x.MaDanhMuc == danhMuc.MaDanhMuc).ToList();
            foreach (var item in dichVus)
            {
                DichVuComponent dichVuComponent = new DichVuComponent(item);
                pnDichVu.Controls.Add(dichVuComponent);
                dichVuComponent.Show();
            }
        }

        public void Trigger()
        {
            pnDichVuDaDangKy.Controls.Clear();
            pnDichVu.Controls.Clear();
            LoadDichVu();
            LoadDichVuDaDangKy();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadDichVu();
        }
    }
}
