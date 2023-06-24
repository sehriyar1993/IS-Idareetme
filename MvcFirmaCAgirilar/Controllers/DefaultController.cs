using MvcFirmaCAgirilar.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcFirmaCAgirilar.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        DbisTakipEntities db = new DbisTakipEntities();

        public ActionResult Actifcagiri()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();

            var cagirilar = db.TblCagrilar.Where(x => x.Durum == true && x.CagriFirma == id).ToList();
            ViewBag.m = cagirilar.Count();
            return View(cagirilar);
        }
        public ActionResult passifcagiri()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var cagirilar = db.TblCagrilar.Where(x => x.Durum == false && x.CagriFirma == id).ToList();
            return View(cagirilar);
        }
        [HttpGet]
        public ActionResult Yenicagiri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenicagiri(TblCagrilar p)
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            p.Durum = true;
            p.CagriFirma = id;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCagrilar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Yenicagiri");
        }
        //public ActionResult CagiriDetay(int id) 
        // {
        //var cagri= db.TblCAgriDetay.Where(x=>x.Cagri==id).ToList();  
        // return View(cagri);

        // }
        public ActionResult CagiriDetaylar(int id)
        {
            var Cagri = db.TblCAgriDetay.Where(x => x.Cagri == id).ToList();
            return View(Cagri);
        }
        public ActionResult CagiriGetir(int id)
        {
            var cagri = db.TblCagrilar.Find(id);
            return View("Cagirigetir", cagri);
        }
        public ActionResult CagiriDuzenle(TblCagrilar p)
        {
            var cagri = db.TblCagrilar.Find(p.ID);
            cagri.Konu = p.Konu;
            cagri.Aciklama = p.Aciklama;
            db.SaveChanges();
            return RedirectToAction("Actifcagiri");
        }
        [HttpGet]
        public ActionResult ProfilimiDuzenle()
        {
            
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var profil = db.TblFirma.Where(x => x.ID == id).FirstOrDefault(); 
            return View(profil);
        }
        public ActionResult AnaSayfa()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var toplamcagiri = db.TblCagrilar.Where(x => x.CagriFirma == id).Count();
            var aktiv = db.TblCagrilar.Where(x => x.CagriFirma == id && x.Durum == true).Count();
            var passiv = db.TblCagrilar.Where(x => x.CagriFirma == id && x.Durum == false).Count();
            var yetkili = db.TblFirma.Where(x => x.ID == id).Select(y => y.Yetkili).FirstOrDefault();
            var sektor = db.TblFirma.Where(x => x.ID == id).Select(y => y.Sektor).FirstOrDefault();
            var firmaadi = db.TblFirma.Where(x => x.ID == id).Select(y => y.Ad).FirstOrDefault();
            var gorsel = db.TblFirma.Where(x => x.ID == id).Select(y => y.Gorsel).FirstOrDefault();
            ViewBag.p1 = passiv;
            ViewBag.a1 = aktiv;
            ViewBag.c1 = toplamcagiri;
            ViewBag.y1 = yetkili;
            ViewBag.s1 = sektor;
            ViewBag.ad = firmaadi;
            ViewBag.a2 = gorsel;

            return View();
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var mesajlar = db.TblMesajlar.Where(x => x.Alan == id && x.Durum == true).ToList();
            var mesajsay = db.TblMesajlar.Where(x => x.Alan == id && x.Durum == true).Count();
            ViewBag.m1 = mesajsay;
            return PartialView(mesajlar);
        }
        public PartialViewResult Partial2()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var cagrilar = db.TblCagrilar.Where(x => x.CagriFirma == id && x.Durum == true).ToList();
            var cagrisay = db.TblCagrilar.Where(x => x.CagriFirma == id && x.Durum == true).Count();
            ViewBag.cagrisay = cagrisay;
            return PartialView(cagrilar);

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial3()
        {
            return PartialView();
        }
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            db.SaveChanges();
            return RedirectToAction("YeniMesaj");
        }
        public ActionResult gonderilenmesaj()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirma.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var cagri = db.TblMesajlar.Find(id);
            return View();
        }
    }
}

