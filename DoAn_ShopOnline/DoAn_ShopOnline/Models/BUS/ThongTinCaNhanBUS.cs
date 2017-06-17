using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_ShopOnline.Models.BUS
{
    public class ThongTinCaNhanBUS
    {
        public static void ThemThongTin(ThongTinCaNhan thongtin)
        {
            var db = new ShopOnlineConnectionDB();
            db.Insert(thongtin);
        }
        public static IEnumerable<ThongTinCaNhan> LoadThongTin(string mataikhoan)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<ThongTinCaNhan>("select * from ThongTinCaNhan where MaTaiKhoan = '" + mataikhoan + "'");
            
        }
    }
}