using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;

namespace QuanLiThuVienNew
{
    public partial class FrmDocGia : Form
    {
        private string MaDGia;
        public FrmDocGia()
        {
            InitializeComponent();
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            grdDocGia.DataSource = DocGia_DAO.LoadDuLieu();
            txtTen.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtEmail.ReadOnly = true;
           txtGTinh.ReadOnly = true;           
        }

        private void grdDocGia_Click(object sender, EventArgs e)
        {
            try
            {
                MaDGia = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaDocGia").ToString();
               txtTen.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HoTen").ToString();
               if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GioiTinh").ToString() == "1")
                   txtGTinh.Text = "Nữ";
               else
                   txtGTinh.Text = "Nam";
               txtDienThoai.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DienThoai").ToString();
               txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DiaChi").ToString();
               txtEmail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Email").ToString();
               if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgaySinh").ToString() != "")
                   dtNgaySinh.Value = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgaySinh").ToString());
               else
                   dtNgaySinh.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu", "THÔNG BÁO", MessageBoxButtons.OK);
            }
           
        }

        private void barBtnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           //Sửa
            try
            {
                txtDienThoai.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtGTinh.ReadOnly = false;

                DocGia_DTO dg = new DocGia_DTO();
                dg.MaDocGia = int.Parse(MaDGia);
                dg.HoTen = txtTen.Text;
                dg.GioiTinh = 1;
                if (txtGTinh.Text == "Nam") dg.GioiTinh = 0;
                dg.NgaySinh = dtNgaySinh.Value;
                dg.Email = txtEmail.Text;
                dg.DienThoai = txtDienThoai.Text;
                dg.DiaChi = txtDiaChi.Text;
                DocGia_DAO.Sua(dg);

                grdDocGia.DataSource = DocGia_DAO.LoadDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa chọn độc giả cần chỉnh sửa", "THÔNG BÁO", MessageBoxButtons.OK);
            }
           

        }

        private void barBtbThemTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTen.ReadOnly = false;
            txtDienThoai.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtGTinh.ReadOnly = false;
          

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
               
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DocGia_DTO dg = new DocGia_DTO();
            //  dg.MaDocGia = int.Parse(MaDGia);
            dg.HoTen = txtTen.Text;
            dg.GioiTinh = 1;
            if (txtGTinh.Text == "Nam") dg.GioiTinh = 0;
            dg.NgaySinh = dtNgaySinh.Value;
            dg.Email = txtEmail.Text;
            dg.DienThoai = txtDienThoai.Text;
            dg.DiaChi = txtDiaChi.Text;
            DocGia_DAO.Them(dg);
            grdDocGia.DataSource = DocGia_DAO.LoadDuLieu();
        }
    }
}
