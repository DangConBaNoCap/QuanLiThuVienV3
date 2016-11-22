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

namespace QuanLiThuVienNew
{
    public partial class FrmQLMuonTra : Form
    {
        private string MaPM = "";
        public FrmQLMuonTra()
        {
            InitializeComponent();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm Mượn
            frmMuonTra frm = new frmMuonTra();
            frm.ShowDialog();
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
    }
}
