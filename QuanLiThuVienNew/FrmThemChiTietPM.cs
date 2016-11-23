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
    public partial class FrmThemChiTietPM : Form
    {
        private int MaPM;
        public FrmThemChiTietPM(string MaPMuon)
        {
            MaPM = int.Parse(MaPMuon);
            InitializeComponent();
        }

        private void FrmThemChiTietPM_Load(object sender, EventArgs e)
        {
            cboTenSach.DataSource = Sach_DAO.LoadDuLieu();
        }
    }
}
