using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AllTrustUs.giftcard.Controllers
{
    public class CardTakeController : BaseController
    {
        // GET: CardTake
        public ActionResult Index()
        {
            string appcode = RouteData.Values["id"].ToString();
            return View();
        }
    }
}