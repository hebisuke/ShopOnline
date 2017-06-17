using DoAn_ShopOnline.Models.BUS;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace DoAn_ShopOnline.Controllers
{
    [Authorize]
    public class ThongTinCaNhanController : Controller
    {
        // GET: ThongTinCaNhan
        public ActionResult Index()
        {
           var ds= ThongTinCaNhanBUS.LoadThongTin(User.Identity.GetUserId());
            return View(ds);
        }
        public ActionResult Them()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Them(ThongTinCaNhan ttcn)
        {
            try
            {
                // TODO: Add update logic here
                ThongTinCaNhanBUS.ThemThongTin(ttcn);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}