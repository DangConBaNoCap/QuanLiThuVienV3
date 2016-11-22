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
using System.Data.SqlClient;

namespace QuanLiThuVienNew
{
    public partial class frmMuonTra : Form
    {
        public frmMuonTra()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmMuonTra_Load(object sender, EventArgs e)
        {

            LoadDocGia();
            LoadDSSach();

        }
      
        private void ThemPhieuMuon(int idDG)
        {
            PhieuMuon_DTO pm = new PhieuMuon_DTO();
            pm.MaDG = idDG;
            pm.NgayMuon = DateTime.Now;
            pm.MaNV =int.Parse(cboTenNhanVien.SelectedValue.ToString());
            PhieuMuon_DAO.Them(pm);
            txtMaPM.Text = PhieuMuon_DAO.LayIDMoiNhat().ToString();
       }
        private void LoadDocGia()
        {
            ThoiGianNow.DateTime = DateTime.Now;
            cboTenNhanVien.DataSource = NhanVien_DAO.LoadDuLieu();
            cboTenNhanVien.DisplayMember = "HoTen";
            cboTenNhanVien.ValueMember = "MaNV";


            cboTenChuDe.DataSource = ChuDe_DAO.LoadDuLieu();
            cboTenChuDe.DisplayMember = "TenCD";
            cboTenChuDe.ValueMember = "MaCD";
            cboTenChuDe.Text = "";

            cboNhaXuatBan.DataSource = NhaXuatBan_DAO.LoadDuLieu();
            cboNhaXuatBan.DisplayMember = "TenNXB";
            cboNhaXuatBan.ValueMember = "MaNXB";
            cboNhaXuatBan.Text = "";
        }
        private void LoadDSSach()
        {
            DataTable dt = Sach_DAO.LoadDuLieu();
            DataTable dtg = ChuDe_DAO.LoadDuLieu();
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            for (int i = 0; i < dtg.Rows.Count; i++)
            {
                ListViewGroup lvg = new ListViewGroup(dtg.Rows[i][0].ToString(), dtg.Rows[i][1].ToString());
                lsvSach.Groups.Add(lvg);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dt.Rows[i][1].ToString()); // ten mon
                lvi.SubItems.Add(dt.Rows[i][2].ToString()); // Don gia
                lvi.SubItems.Add(dt.Rows[i][4].ToString()); //So luong
                DataTable nxb = NhaXuatBan_DAO.LoadDuLieuNXB(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(nxb.Rows[0][1].ToString());//NXB
                lvi.SubItems.Add(dt.Rows[i][7].ToString());//id chu de
                lvi.SubItems.Add(dt.Rows[i][0].ToString());  // id mon
                lvi.Group = lsvSach.Groups[lvi.SubItems[4].Text];
                lsvSach.Items.Add(lvi);
                ac.Add(lvi.SubItems[0].Text);
            }
            txtTenSach.AutoCompleteCustomSource = ac;

        }
        ListViewItem FindItem;
        private void button1_Click(object sender, EventArgs e)
        {
            //Load Ten Doc Gia
            string IDDG = "";
            IDDG = txtMaDG.Text;
            try
                {
            DataTable dt = DocGia_DAO.LayDuLieu(IDDG);
            txtTenDG.Text = dt.Rows[0][1].ToString();
            ThemPhieuMuon(int.Parse(IDDG));
                }
                catch(Exception ex)
            {
                MessageBox.Show("Mã Độc Giả không tồn tại", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

           // LoadDSSach();
            lsvSach.Items.Clear();
            if (txtTenSach.Text == "" && cboTenChuDe.Text == "" && cboNhaXuatBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", "Thông báo");
            }
            else
            {
                if (txtTenSach.Text != "")
                {
                    LoadDSSach();
                    ListViewItem item = lsvSach.FindItemWithText(txtTenSach.Text);
                    if (item == null)
                    {
                        MessageBox.Show("Thư viện không có sách này!", "Thông báo");
                    }
                    else
                    {
                        FindItem = item;
                        lsvSach.TopItem = item;
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                }

                else
                {
                    lsvSach.Items.Clear();
                    string temp = "";
                    DataTable dt = new DataTable();
                    DataTable cd = new DataTable();
                    DataTable nxb = new DataTable();
                    AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                    if (cboTenChuDe.Text != "")
                    {
                        temp = cboTenChuDe.SelectedValue.ToString();
                        dt = Sach_DAO.LoadDuLieuCD(temp);
                      
                    }
                    else
                    if (cboNhaXuatBan.Text != "")
                        {
                            temp = cboNhaXuatBan.SelectedValue.ToString();
                            dt = Sach_DAO.LoadDuLieuNXB(temp);
                       
                        }
                   if (dt.Rows.Count == 0)                            
                                MessageBox.Show("Nhập sai nhà xuất bản hoặc tên chủ đề", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                   else                           
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ListViewItem lvi = new ListViewItem(dt.Rows[i][1].ToString()); // ten Sach
                                    lvi.SubItems.Add(dt.Rows[i][2].ToString()); // Gia Ban
                                    lvi.SubItems.Add(dt.Rows[i][4].ToString()); // So Luong
                                    nxb = NhaXuatBan_DAO.LoadDuLieuNXB(dt.Rows[i][6].ToString());
                                    lvi.SubItems.Add(nxb.Rows[0][1].ToString());//NXB
                                    lvi.SubItems.Add(dt.Rows[i][7].ToString());//IDCD
                                    lvi.SubItems.Add(dt.Rows[i][0].ToString());//IDSach
                                    lsvSach.Items.Add(lvi);
                                }                                            
                }
                txtTenSach.Text = "";
                cboNhaXuatBan.Text = "";
                cboTenChuDe.Text = "";
            }
        }
        ListViewItem itemSelect;
        int indexItemSelect;
        DataTable cd;
        string IdCD;
        string IdSach;
        string GiaBan;
        string NhaXuatBan;
        private void lsvSach_Click(object sender, EventArgs e)
        {
            txtSoLuong.ReadOnly = false;
            ListViewItem lvi = lsvSach.SelectedItems[0];
            txtSach.Text = lvi.SubItems[0].Text;
            itemSelect = lsvSach.SelectedItems[0];
            indexItemSelect = lsvSach.SelectedItems[0].Index;          
            IdCD = itemSelect.SubItems[4].Text;
            IdSach = itemSelect.SubItems[5].Text;
            GiaBan = itemSelect.SubItems[1].Text;
            NhaXuatBan = itemSelect.SubItems[3].Text;
            cd = ChuDe_DAO.LoadDuLieuCD(IdCD);
            txtChuD.Text = cd.Rows[0][1].ToString();

        }

        private void lsvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FindItem != null)
            {
                FindItem.BackColor = Color.White;
                FindItem.ForeColor = Color.Black;
            }
        }

        private void cboTenChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSuaDsChon_Click(object sender, EventArgs e)
        {
            btnSuaDsChon.Enabled = false;
            txtSoLuong.ReadOnly = false;    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
              int ktsoluong=0;
            if(txtSoLuong.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập số lượng !");
                return;
            }
            else
            {
                int.TryParse(txtSoLuong.Text, out ktsoluong);
                if (ktsoluong == 0)
                {
                    MessageBox.Show("Đề nghị bạn nhập lại số lượng sách");
                    return;
                }
               
            }
            ListViewItem item = lsvDsDuocChon.FindItemWithText(txtSach.Text);
            if(item != null)
            {
                item.SubItems[2].Text = (int.Parse(item.SubItems[2].Text) + int.Parse(txtSoLuong.Text)).ToString();
                return;
            }
            ListViewItem lvi = new ListViewItem(txtSach.Text);//TenSach
            lvi.SubItems.Add(GiaBan);//GiaBan
             lvi.SubItems.Add(txtSoLuong.Text);  // so luong
            lvi.SubItems.Add(NhaXuatBan);//NXB
            lvi.SubItems.Add(IdCD);
            lvi.SubItems.Add(IdSach);
            lvi.SubItems.Add(dtNgayHenTra.Value.ToString());
            lsvDsDuocChon.Items.Add(lvi);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            lsvDsDuocChon.Items.RemoveAt(indexItemSelect);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = new ListViewItem(txtSach.Text);
                item.SubItems.Add(itemSelect.SubItems[1].Text);//Giá Bán
                item.SubItems.Add(txtSoLuong.Text);
                item.SubItems.Add(itemSelect.SubItems[3].Text);//NXB
                item.SubItems.Add(itemSelect.SubItems[4].Text);//MaCD
                item.SubItems.Add(itemSelect.SubItems[5].Text);//MaSach
                item.SubItems.Add(dtNgayHenTra.Value.ToString());//NgayHenTra
                lsvDsDuocChon.Items.RemoveAt(indexItemSelect);
                lsvDsDuocChon.Items.Insert(indexItemSelect, item);
                txtSoLuong.ReadOnly = true;
                btnSuaDsChon.Enabled = true;
            }
            catch
            {
                return;
            }
        }
        private void ThemPhieuMuon()
        {

            PhieuMuon_DTO pm = new PhieuMuon_DTO();
            pm.NgayMuon = ThoiGianNow.DateTime;
            pm.MAPM = int.Parse(txtMaPM.Text);
            pm.MaDG = int.Parse(txtMaDG.Text);
            pm.MaNV = int.Parse(cboTenNhanVien.SelectedValue.ToString());
            PhieuMuon_DAO.Sua(pm);
        }
        private void ThemChiTietPhieuMuon()
        {
            for (int i = 0; i < lsvDsDuocChon.Items.Count; i++)
            {
                ChiTietPhieuMuon_DTO ctpm = new ChiTietPhieuMuon_DTO();
                ctpm.MaPM = int.Parse(txtMaPM.Text);
                ctpm.MaSach = int.Parse(lsvDsDuocChon.Items[i].SubItems[5].Text);
                ctpm.SoLuong = int.Parse(lsvDsDuocChon.Items[i].SubItems[2].Text);
                ChiTietPhieuMuon_DAO.Them(ctpm);
            }
        }
        bool isHoanTat = false;

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            int ktSoLuong = 0;
            int.TryParse(txtMaDG.Text, out ktSoLuong);
            if (ktSoLuong == 0)
            {
                MessageBox.Show("Nhập Độc Giả");
                return;
            }
            
            if (lsvDsDuocChon.Items.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn thực đơn");
                return;
            }
            isHoanTat = true;
            ThemPhieuMuon();
            ThemChiTietPhieuMuon();
            MessageBox.Show("Đã hoàn tất yêu cầu mượn sách");
            this.Close();
        }

        private void l(object sender, EventArgs e)
        {
            ListViewItem lvi = lsvDsDuocChon.SelectedItems[0];
            txtSach.Text = lvi.SubItems[0].Text;
            itemSelect = lsvDsDuocChon.SelectedItems[0];
            indexItemSelect = lsvDsDuocChon.SelectedItems[0].Index;
            IdCD = itemSelect.SubItems[4].Text;
            txtSoLuong.Text=itemSelect.SubItems[2].Text;
            cd = ChuDe_DAO.LoadDuLieuCD(IdCD);
            txtChuD.Text = cd.Rows[0][1].ToString();
            dtNgayHenTra.Value = DateTime.Parse(itemSelect.SubItems[6].Text);
            txtSoLuong.ReadOnly = true;
            btnSuaDsChon.Enabled = true;
        }


    }        
 }

