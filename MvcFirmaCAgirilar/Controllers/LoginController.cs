using MvcFirmaCAgirilar.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcFirmaCAgirilar.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbisTakipEntities db = new DbisTakipEntities();
        public ActionResult Index()
        {
            //kodlar

            return View();
        }
        [HttpPost]
        public ActionResult Index(TblFirma p) 
        {
            var bilgiler = db.TblFirma.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"]=bilgiler.Mail.ToString();
                return RedirectToAction("Actifcagiri", "Default");
            }
            else { return RedirectToAction("Index"); }
        }
    }
}