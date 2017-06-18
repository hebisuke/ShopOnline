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
        public static void SuaThongTin(ThongTinCaNhan thongtin)
        {
            var db = new ShopOnlineConnectionDB();

            db.Update(thongtin,LayIDThongTin(thongtin.MaTaiKhoan));
        }
        public static string LayIDThongTin(string mataikhoan)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<string>("select id from ThongTinCaNhan where MaTaiKhoan ='" + mataikhoan + "'").FirstOrDefault();
        }
        public static IEnumerable<ThongTinCaNhan> LoadThongTin(string mataikhoan)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<ThongTinCaNhan>("select * from ThongTinCaNhan where MaTaiKhoan = '" + mataikhoan + "'");
            
        }
        public static IEnumerable<ThongTinCaNhan> DanhSachTaiKhoan( )
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<ThongTinCaNhan>("select * from ThongTinCaNhan");

        }
        public static AspNetUser LoadTaiKhoan(string mataikhoan)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<AspNetUser>("select * from AspNetUsers where Id = '" + mataikhoan + "'").FirstOrDefault();

        }
        public static void KhoaTaiKhoan(string mataikhoan, DateTime ngay)
        {
            //var tk = LoadTaiKhoan(mataikhoan);
            //tk.LockoutEndDateUtc = ngay;
            //var db = new ShopOnlineConnectionDB();
            //db.Update(tk, tk.Id);
        }
        public static IEnumerable<AspNetUserRole> LoadCapQuyen(string mataikhoan)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<AspNetUserRole>("select * from AspNetUserRoles where UserId = '" + mataikhoan + "'");

        }
        public static void CapQuyen(string mataikhoan,string loaiquyen)
        {
            var db = new ShopOnlineConnectionDB();
            var mapq = LoadCapQuyen(mataikhoan);
            if(mapq.Count() ==0)
            {
                if(loaiquyen =="Admin")
                {
                    // tạo mới
                    var tam = new AspNetUserRole();
                    tam.UserId = mataikhoan;
                    tam.RoleId = "a26637a0-2c98-46b4-a493-4d5a142ae721";
                    db.Insert(tam);
                }
            }
            else
            {
                if (loaiquyen == "Admin")
                {
                    mapq.ElementAt(0).RoleId = "Admin";
                    db.Update(mapq.ElementAt(0), mapq.ElementAt(0).UserId);
                }
                else
                {
                    db.Delete("AspNetUserRoles", mapq.ElementAt(0).UserId,mapq.ElementAt(0));
                }
            }
        }

        //public static void TaoMoi( string email)
        //{
        //    ThongTinCaNhan ttcn = new ThongTinCaNhan();
        //    ttcn.MaTaiKhoan = LayMaTaiKhoan(email);
        //    ttcn.TenTaiKhoan = email;
        //    ttcn.SoDienThoai = 0000;
        //    ttcn.DiaChi = "Chưa Cập Nhật";
        //    ttcn.GioiTinh = "nam";
        //    ttcn.NgaySinh = DateTime.Now.ToShortDateString();
        //    var db = new ShopOnlineConnectionDB();
        //    db.Insert(ttcn);
        //}
        //public static string LayMaTaiKhoan(string email)
        //{
        //    var db = new ShopOnlineConnectionDB();
        //    return db.Query<string>("select Id from AspNetUsers where Email ='"+email+"'").FirstOrDefault();
        //}
    }
}