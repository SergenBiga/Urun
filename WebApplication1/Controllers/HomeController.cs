using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(ctx.Urunler.ToList());
        }

        public PartialViewResult Menu()
        {

            return PartialView(ctx.Kategoriler.ToList());
        }
        public ActionResult TelevizyonListe()
        {
            return View(ctx.Urunler.Where(x => x.KategoriID == 1).ToList());
        }
        public ActionResult KategoriDetay(int? id)
        {
            if(id == null)
            {
                ViewBag.mesaj = "id seçmediniz sayfayı gösteremiyoruz";
            }
            else
            {
                ApplicationDbContext ctx = new ApplicationDbContext();
                var kat = ctx.Urunler.Where(x=>x.KategoriID == id).ToList();
                return View(kat);
            }
            return View(ctx.Urunler.ToList());
        }
        public ActionResult Hakkımızda()
        {
            return View();
        }
        public ActionResult İletişim()
        {
            return View();
        }
        public PartialViewResult SonEklenen2()
        {
            return PartialView(ctx.Urunler.OrderByDescending(x=>x.UrunlerModelID).Take(2).ToList());
        }






    }
}