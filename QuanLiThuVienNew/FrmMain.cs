using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLiThuVienNew
{
    public partial class FrmMain :XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            FrmThemTaiKhoan _frmThemTK = new FrmThemTaiKhoan();
            _frmThemTK.ShowDialog();
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {

            FrmDoiMatKhau _frmDoiMK = new FrmDoiMatKhau();
            _frmDoiMK.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                FrmQLMuonTra _frm = new FrmQLMuonTra();
                _frm.ShowDialog();
            }
           catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void tileItem10_ItemClick(object sender, TileItemEventArgs e)
        {
       
        }
    }
}
