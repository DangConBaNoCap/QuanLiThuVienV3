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
    public partial class FrmSuaSach : Form
    {
        string MaSach;
        public FrmSuaSach(string dk)
        {
            InitializeComponent();
            MaSach = dk;
        }

        private void FrmSuaSach_Load(object sender, EventArgs e)
        {
           
            DataTable tb = Sach_DAO.TimKiemSach("where MaSach=" + MaSach.Trim());
            txtMasach.Text = tb.Rows[0]["MaSach"].ToString();
            txtMasach.ReadOnly = true;
            txtTensach.Text = tb.Rows[0]["TenSach"].ToString();
            txtGiaban.Text = tb.Rows[0]["GiaBan"].ToString();
            txtMota.Text = tb.Rows[0]["MoTa"].ToString();
            txtNgaynhap.Text = tb.Rows[0]["NgayNhap"].ToString();
            txtSoluong.Text = tb.Rows[0]["SoLuong"].ToString();

            txtMaCD.Text = tb.Rows[0]["MaCD"].ToString();
            txtMaCD.ReadOnly = true;
            txtMaNXB.Text = tb.Rows[0]["MaNXB"].ToString();
            txtMaNXB.ReadOnly = true;
        }
        Sach_DTO enty_sach = new Sach_DTO();
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                enty_sach.TenSach = txtTensach.Text;
                enty_sach.GiaBan = int.Parse(txtGiaban.Text);
                enty_sach.MaCD = int.Parse(txtMaCD.Text.ToString());
                enty_sach.MaNXB = int.Parse(txtMaNXB.Text.ToString());
                enty_sach.SoLuong = int.Parse(txtSoluong.Text);
                enty_sach.NgayNhap = Convert.ToDateTime(txtNgaynhap.Text);
                enty_sach.MoTa = txtMota.Text;
                enty_sach.MaSach = int.Parse(txtMasach.Text.ToString());
                Sach_DAO.Sua(enty_sach);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
