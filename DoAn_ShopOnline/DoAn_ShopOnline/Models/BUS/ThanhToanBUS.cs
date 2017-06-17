using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_ShopOnline.Models.BUS
{
    public class ThanhToanBUS
    {
        public static void ThemOrder(string nguoinhan, string sdt, string diachi,string mataikhoan)
        {
            // tạo 1 row trong bảng order
            // lấy ID trong bảng order thông qua ID ngường dùng
            //Trạng thái  0:chưa duyệt , 1 : đang giao , 2 : đã giao, 3 : đã hủy ( có thể xóa ) 
            using (
                var db = new ShopOnlineConnectionDB())
            {
                //------------------Thêm đơn hàng ------------------
                HoaDon donhang = new HoaDon()
                {
                    NgayTao = DateTime.Now,
                    NguoiDat =mataikhoan,
                    NguoiNhan=nguoinhan,
                    SDT =sdt,
                    DiaChi=diachi,
                    TongTien = GioHangBUS.TongTien(mataikhoan),
                    TrangThai =0

                };
                
                 db.Insert("HoaDon","ID",donhang);
                //--------------------Thêm Chi tiết đơn hàng
                List<GioHang> gh = GioHangBUS.DanhSach(mataikhoan).ToList();
                ChiTietHoaDon odct = new ChiTietHoaDon();
                int i = 0;
                int id = LayIdOrder(mataikhoan);
                foreach(var item in gh)
                {
                    odct.OrderID = id;
                    odct.MaSanPham = item.MaSanPham;
                    odct.TenSanPham = item.TenSanPham;
                    odct.SoLuong = item.SoLuong;
                    odct.Gia = item.Gia;
                    odct.TongTien = item.TongTien;
                    i++;
                    db.Insert("ChiTietHoaDon", "OrderID", odct);
                }
                foreach(var item in gh)
                {
                    GioHangBUS.Xoa(item.MaSanPham, item.MaTaiKhoan);
                }
            }

        }

        public static int LayIdOrder(string mataikhoan)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                string a = "select ID from HoaDon Where NguoiDat ='" + mataikhoan + "' Order by NgayTao Desc";
                return db.Query<int>(a).FirstOrDefault();

            }
        }

        public static IEnumerable<HoaDon> DanhSachHoaDon()
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                string a = "select * from HoaDon";
                return db.Query<HoaDon>(a);

            }
        }
        public static IEnumerable<ChiTietHoaDon> ChiTietHoaDon(long mahoadon)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                string a = "select * from ChiTietHoaDon where OrderID ='"+mahoadon+"'";
                return db.Query<ChiTietHoaDon>(a);

            }
        }
        
        public static void SuaDonHang(long mahoadon,int tinhtrang)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                db.Update<HoaDon>("SET TrangThai=@0 WHERE ID =@1", tinhtrang, mahoadon);
                
            }
        }
    }
}