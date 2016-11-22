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
    public partial class FrmSuaChiTiet : Form
    {
        private int MaPM;
        private int MaSach;
        private string TenSach;

        public FrmSuaChiTiet(string MaPMuon,string MaSa,string TenSa)
        {
            MaPM = int.Parse(MaPMuon);
            MaSach = int.Parse(MaSa);
            TenSach = TenSa;
            InitializeComponent();
        }

        private void FrmSuaChiTiet_Load(object sender, EventArgs e)
        {
            txtMaHD.Text = MaPM.ToString();
            txtTenSach.Text = TenSach;
           
            DataTable ct = ChiTietPhieuMuon_DAO.LoadDuLieu1(MaPM.ToString(), MaSach.ToString());
            txtTinhTrang.Text = ct.Rows[0][2].ToString();
            txtSoLuong.Text = ct.Rows[0][3].ToString();
            if (ct.Rows[0][4].ToString()!="")
            {
                dtHenTra.Value = DateTime.Parse(ct.Rows[0][4].ToString());
            }
            else
            {
                dtHenTra.Value = DateTime.Now;
            }
            if (ct.Rows[0][5].ToString() != "")
            {
                dtTra.Value = DateTime.Parse(ct.Rows[0][5].ToString());
            }
            else
            {
                dtTra.Value = DateTime.Now;
            }

        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            ChiTietPhieuMuon_DTO ct = new ChiTietPhieuMuon_DTO();
            ct.MaPM = MaPM;
            ct.MaSach = MaSach;
            ct.TinhTrang = txtTinhTrang.Text;
            ct.SoLuong = int.Parse(txtSoLuong.Text);
            ct.NgayHenTra = dtHenTra.Value;
            ct.NgayTra = dtTra.Value;
            ChiTietPhieuMuon_DAO.Sua(ct);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
