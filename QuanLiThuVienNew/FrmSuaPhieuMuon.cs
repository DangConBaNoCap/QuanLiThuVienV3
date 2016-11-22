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
    public partial class FrmSuaPhieuMuon : Form
    {
        private int MaPM;
        private int MaNV;
        private int MaDG;
        private DateTime NgayMuon;
        public FrmSuaPhieuMuon(string MaPMuon)
        {
            MaPM = int.Parse(MaPMuon);
            InitializeComponent();
        }
        private void LoadDL()
        {
            txtMaPM.Text = MaPM.ToString();
            cboNhanVien.SelectedValue = MaNV;
            cboDocGia.SelectedValue = MaDG;
            dtThoiGian.Value = NgayMuon;
        }

        private void FrmSuaPhieuMuon_Load(object sender, EventArgs e)
        {
            DataTable dt = PhieuMuon_DAO.LoadDuLieuTheoMa(MaPM.ToString());
            MaNV = int.Parse(dt.Rows[0][3].ToString());
            MaDG = int.Parse(dt.Rows[0][1].ToString());
            NgayMuon = DateTime.Parse(dt.Rows[0][2].ToString());

            cboNhanVien.DataSource = NhanVien_DAO.LoadDuLieu();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            //Khach Hang
            cboDocGia.DataSource = DocGia_DAO.LoadDuLieu();
            cboDocGia.DisplayMember = "HoTen";
            cboDocGia.ValueMember = "MaDocGia";
            LoadDL();
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            PhieuMuon_DTO pm = new PhieuMuon_DTO();
            pm.MAPM = MaPM;
            pm.MaDG = int.Parse(cboDocGia.SelectedValue.ToString());
            pm.MaNV = int.Parse(cboNhanVien.SelectedValue.ToString());
            pm.NgayMuon = dtThoiGian.Value;
            PhieuMuon_DAO.Sua(pm);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
