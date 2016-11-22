﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private int _MaNV;

        public int MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }


        private string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }


        private DateTime _NgaySinh;

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }


        private int _GioiTinh;

        public int GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }


        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }


        private string _DienThoai;

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

    }
}
