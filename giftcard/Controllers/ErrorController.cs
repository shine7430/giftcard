using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllTrustUs.giftcard.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.ErrorMsg = System.Web.HttpContext.Current.Session["SystemError"];
            return View();
        }
    }
}