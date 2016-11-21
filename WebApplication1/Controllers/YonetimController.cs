using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(KategoriModel k)
        {
            if (ModelState.IsValid)
            {
                ctx.Kategoriler.Add(k);
                ctx.SaveChanges();
            }
            return View();
        }
        public ActionResult KategoriSil()
        {

            return View();
        }
        public ActionResult KategoriDuzenle()
        {
            return View(ctx.Kategoriler.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            ViewBag.k = ctx.Kategoriler.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UrunEkle(UrunlerModel k)
        {
            ViewBag.k = ctx.Kategoriler.ToList();
            if (ModelState.IsValid)
            {
                ctx.Urunler.Add(k);
                ctx.SaveChanges();
            }
            return View();
        }
       

  
        public ActionResult UrunListele()
        {    

            return View(ctx.Urunler.ToList());
        }
        [HttpGet]
        public ActionResult UrunDuzenle(int? id)
        {
            if (id == null)
            {
                ViewBag.mesaj = "Bir urun seçmediniz, id bekleniyor";
                return View();
            }
            else
            {
                ApplicationDbContext ctx = new ApplicationDbContext();
                var urun = ctx.Urunler.Find(id);
                return View(urun);
            }
        }
        public ActionResult UrunDetay(int? id)
        {
            if (id == null)
            {
                ViewBag.mesaj = "Bir urun seçmediniz, id bekleniyor";
                return View();
            }
            else
            {
                ApplicationDbContext ctx = new ApplicationDbContext();
                var urun = ctx.Urunler.Find(id);
                return View(urun);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UrunDuzenle(UrunlerModel urun,HttpPostedFileBase resim)
        {
            var eski = "";
            using (ApplicationDbContext ctx2 = new ApplicationDbContext())
            {
                eski = ctx2.Urunler.Find(urun.UrunlerModelID).UrunResmiURL;
            }
            ApplicationDbContext ctx = new ApplicationDbContext();
            var klasor = Server.MapPath("/Content/urun/");
            //eğer resim yuklenmemisse
            if (resim != null && resim.ContentLength > 0)
            {
                //eski resim silinmeli
                if (string.IsNullOrEmpty(eski))
                    System.IO.File.Delete(klasor + eski);
                //kayıt edilmeli
                resim.SaveAs(klasor + resim.FileName);
                //modeldeki url değişmeli
                urun.UrunResmiURL = resim.FileName;
            }
            else
            {
                //resim yüklenmemişse
                urun.UrunResmiURL = eski;
                //eski resmi kaybetmemeliyiz
            }
            if (ModelState.IsValid)
            {
                //oda detayları kayıt edilmeli
                ctx.Entry(urun).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("UrunListele");
            }
            return View(urun);
        }
        public ActionResult UrunSil(int id)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            var silinecek = ctx.Urunler.Find(id);
            ctx.Urunler.Remove(silinecek);
            ctx.SaveChanges();
            return RedirectToAction("UrunListele");
        }
    }
}