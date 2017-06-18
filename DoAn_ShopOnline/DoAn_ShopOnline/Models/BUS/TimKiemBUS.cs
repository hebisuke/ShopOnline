using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_ShopOnline.Models.BUS
{
    public class TimKiemBUS
    {
        public static IEnumerable<SanPham> TimKiem(string TimKiem, string MaNhaSanXuat, string MaLoaiSanPham, string GiaBatDau, string GiaKetThuc)
        {
            
            var db = new ShopOnlineConnectionDB();
            if(MaNhaSanXuat == "" & MaLoaiSanPham =="" & GiaBatDau ==""  & GiaKetThuc=="")
            {
                return db.Query<SanPham>("select * from SanPham where TenSanPham like '%" + TimKiem + "%'");
            }
            return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham ='"+MaLoaiSanPham+"' AND MaNhaSanXuat ='"+MaNhaSanXuat+"' AND Gia BETWEEN '"+GiaBatDau+"' AND '"+GiaKetThuc+"' AND TenSanPham like '%" + TimKiem + "%'");

        }
    }
}