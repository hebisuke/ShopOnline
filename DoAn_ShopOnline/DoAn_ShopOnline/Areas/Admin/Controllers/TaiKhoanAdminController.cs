using DoAn_ShopOnline.Models.BUS;
using PagedList;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_ShopOnline.Areas.Admin.Controllers
{
    public class TaiKhoanAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/TaiKhoanAdmin
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            
            var ds= ThongTinCaNhanBUS.DanhSachTaiKhoan().ToPagedList(page, pagesize); ;
            return View(ds);
        }

        // GET: Admin/TaiKhoanAdmin/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        
        public ActionResult Sua(string id)
        {
            return View(ThongTinCaNhanBUS.LoadThongTin(id));
        }

        // POST: Admin/TaiKhoanAdmin/Create
        [HttpPost]
        public ActionResult Sua(ThongTinCaNhan ttcn)
        {
            try
            {
                // TODO: Add insert logic here
                ThongTinCaNhanBUS.SuaThongTin(ttcn);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TaiKhoanAdmin/Edit/5
        public ActionResult Khoa(string id)
        {
           
            return View(ThongTinCaNhanBUS.LoadTaiKhoan(id));
        }

        // POST: Admin/TaiKhoanAdmin/Edit/5
        [HttpPost]
        public ActionResult Khoa(string id,DateTime ngaymo)
        {
            try
            {
                // TODO: Add update logic here
               // ThongTinCaNhanBUS.KhoaTaiKhoan(id, (DateTime)ngaymo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TaiKhoanAdmin/Delete/5
        public ActionResult CapQuyen(string id)
        {
            var tam = ThongTinCaNhanBUS.LoadCapQuyen(id);
            if (tam.Count() != 0)
            {
                ViewBag.CapQuyen = "Admin";
            }
            else ViewBag.CapQuyen = "Dân";


            return View(ThongTinCaNhanBUS.LoadTaiKhoan(id));
        }

        // POST: Admin/TaiKhoanAdmin/Delete/5
        [HttpPost]
        public ActionResult CapQuyen(string id, string  CapQuyen)
        {
            //try
            //{
                // TODO: Add delete logic here
                ThongTinCaNhanBUS.CapQuyen(id, CapQuyen);
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
