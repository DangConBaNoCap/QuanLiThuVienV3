using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
   public class PhieuMuon_DAO
    {
        public static SqlConnection con;

        public static DataTable LoadDuLieu()
        {
            string sTruyVan = "Select * From PhieuMuon";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static DataTable LoadDuLieuTheoMa(string MaPM)
        {
            string sTruyVan = "Select * From PhieuMuon where MaPM=";
            sTruyVan += MaPM;
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static DataTable LoadChiTiet()
        {
            string sTruyVan = "Select a.MaPM,DocGia=b.HoTen,a.NgayMuon,NhanVien=c.HoTen From PhieuMuon a,DocGia b,NhanVien c where a.MaDG=b.MaDocGia and a.MaNV=c.MaNV";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static int LayIDMoiNhat()
        {
            string sTruyVan = "select ID = max(MaPM) from PhieuMuon";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public static bool Them(PhieuMuon_DTO PM)
        {
            try
            {
                string sTruyVan = string.Format("Insert into PhieuMuon(MaDG,NgayMuon,MaNV) values('{0}','{1}','{2}')", PM.MaDG, PM.NgayMuon, PM.MaNV);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVanNonQuery(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Sua(PhieuMuon_DTO PM)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update PhieuMuon set MaDG = '{0}' ,NgayMuon= '{1}',MaNV='{2}' where MaPM ='{3}'", PM.MaDG, PM.NgayMuon, PM.MaNV, PM.MAPM);
                DataProvider.ThucThiTruyVanNonQuery(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Xoa(PhieuMuon_DTO PM)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Delete From PhieuMuon where MaPM = '{0}'", PM.MAPM);
                DataProvider.ThucThiTruyVanNonQuery(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
