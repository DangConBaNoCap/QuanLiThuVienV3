using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QuanLiThuVienNew
{
    public partial class FrmQLMuonTra : Form
    {
        private string MaPM = "";
        private string MaSach = "";
        private string TenSach = "";
        public FrmQLMuonTra()
        {
            InitializeComponent();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm Mượn
            frmMuonTra frm = new frmMuonTra();
            frm.ShowDialog();
            grdPhieuMuon.DataSource = PhieuMuon_DAO.LoadChiTiet();
        }

        private void btnReLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdPhieuMuon.DataSource = PhieuMuon_DAO.LoadChiTiet();
        }

        private void FrmQLMuonTra_Load(object sender, EventArgs e)
        {
            grdPhieuMuon.DataSource = PhieuMuon_DAO.LoadChiTiet();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Sửa Phiếu Thuê
            try
            {
                FrmSuaPhieuMuon frm = new FrmSuaPhieuMuon(MaPM);
                frm.ShowDialog();
                grdPhieuMuon.DataSource = PhieuMuon_DAO.LoadChiTiet();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn phiếu mượn!");
            }  
        }

        private void grdPhieuMuon_Click(object sender, EventArgs e)
        {
            try
            {   //KiemTra = true;
                MaPM = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPM").ToString();
                grdChiTietPhieuMuon.DataSource = ChiTietPhieuMuon_DAO.LoadDuLieuTheoMa(MaPM);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Sửa Chi Tiết 
            try
            {

                FrmSuaChiTiet frm = new FrmSuaChiTiet(MaPM,MaSach,TenSach);
                frm.ShowDialog();
                grdChiTietPhieuMuon.DataSource = ChiTietPhieuMuon_DAO.LoadDuLieuTheoMa(MaPM);

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn chi tiết phiếu Mượn!");
            }
          
        }

        private void grdChiTietPhieuMuon_Click(object sender, EventArgs e)
        {
           MaSach = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "MaSach").ToString();
            TenSach = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, "TenSach").ToString();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Xóa Chi Tiết
            try
            {
                ChiTietPhieuMuon_DTO ct = new ChiTietPhieuMuon_DTO();
                ct.MaPM = int.Parse(MaPM);
                ct.MaSach = int.Parse(MaSach);
                ChiTietPhieuMuon_DAO.Xoa(ct);
                grdChiTietPhieuMuon.DataSource = ChiTietPhieuMuon_DAO.LoadDuLieuTheoMa(MaPM);
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn chi tiết phiếu Mượn!");
            }
      
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm Chi Tiết

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Xóa Phiếu Mượn
            try
            {
                ChiTietPhieuMuon_DTO ct = new ChiTietPhieuMuon_DTO();
                ct.MaPM = int.Parse(MaPM);
                ChiTietPhieuMuon_DAO.Xoa1(ct);
                PhieuMuon_DTO pm = new PhieuMuon_DTO();
                pm.MAPM = int.Parse(MaPM);
                PhieuMuon_DAO.Xoa(pm);
                grdPhieuMuon.DataSource = PhieuMuon_DAO.LoadChiTiet();
            }

            catch
            {
                MessageBox.Show("Bạn chưa chọn phiếu Mượn!");
            }

        }
    }
}
