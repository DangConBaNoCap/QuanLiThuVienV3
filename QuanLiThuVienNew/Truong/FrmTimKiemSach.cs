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
    public partial class FrmTimKiemSach : Form
    {
        public FrmTimKiemSach()
        {
            InitializeComponent();
        }

        private void FrmTimKiemSach_Load(object sender, EventArgs e)
        {
            dgvDausach.DataSource = Sach_DAO.TimKiem("");
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string dk;

            if (cboDanhmuc.SelectedItem.ToString()== "Tên sách")
            {
                dk = txtTim.Text.ToString();
                dgvDausach.DataSource = Sach_DAO.TimKiem("where TenSach like N'%" + dk.Trim()+"%'");
            }
            if (cboDanhmuc.SelectedItem.ToString() == "Chủ đề")
            {
                dk = txtTim.Text.ToString();
                dgvDausach.DataSource = Sach_DAO.TimKiem("where TenCD like N'%" + dk.Trim() + "%'");
            }
            if (cboDanhmuc.SelectedItem.ToString() == "Nhà xuất bản")
            {
                dk = txtTim.Text.ToString();
                dgvDausach.DataSource = Sach_DAO.TimKiem("where TenNXB like N'%" + dk.Trim() + "%'");
            }
            if (cboDanhmuc.SelectedItem.ToString() == "Ngày nhập")
            {
                dk = txtTim.Text.ToString();
                dgvDausach.DataSource = Sach_DAO.TimKiem("where NgayNhap= '" + dk.Trim() + "'");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemDS them = new FrmThemDS();
            them.ShowDialog();
        }
        string XoaMa;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Sach_DTO entity = new Sach_DTO();
            entity.MaSach = int.Parse(XoaMa);
            Sach_DAO.Xoa(entity);
            dgvDausach.DataSource = Sach_DAO.TimKiem("");
        }

        private void dgvDausach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            XoaMa = dgvDausach.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
        }
      
        private void btnSua_Click(object sender, EventArgs e)
        {

            FrmSuaSach suasach = new FrmSuaSach(XoaMa);
            suasach.ShowDialog();
            dgvDausach.DataSource = Sach_DAO.TimKiem("");
        }
    }
}
