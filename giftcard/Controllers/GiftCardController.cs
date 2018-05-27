using AllTrustUs.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YZOpenSDK;

namespace AllTrustUs.giftcard.Controllers
{
    public class GiftCardController : BaseController
    {
        // GET: GiftCard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CardGenerate(string id)
        {
            @ViewBag.Title = "礼品码管理";
            Auth auth = new Token(getToken(id)); // Auth auth = new Sign("app_id", "app_secret");
            YZClient yzClient = new DefaultYZClient(auth);
            Dictionary<string, object> dict;
            dict = new System.Collections.Generic.Dictionary<string, object>();
            dict.Add("page_no", 1);
            dict.Add("page_size", 100);
            //dict.Add("status", "ON");
            dict.Add("group_type", "PROMOCODE");
            var result = yzClient.Invoke("youzan.ump.coupon.search", "3.0.0", "POST", dict, null);

            ViewBag.result = result;
            return View();
        }


        public JsonResult getgiftcard(String PromoId)
        {
            string getsql = "select * from v_giftcard where PromoId='" + PromoId + "'";
            giftcardEntities db = new giftcardEntities();
            object[] obj = new object[1];
            var cards = db.Database.SqlQuery<v_giftcard>(getsql, obj).ToList();

            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"验证成功!\",\"giftcardlist\":" + JsonConvert.SerializeObject(cards) + "}}";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult cardactive(String ids)
        {
            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"激活成功!\"}}";
            string updatesql = "update giftcard set enabled=1 where id in (" + ids + ")and isused = 0";
            giftcardEntities db = new giftcardEntities();
            db.Database.ExecuteSqlCommand(updatesql);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult cardinactive(String ids)
        {
            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"禁用成功!\"}}";
            string updatesql = "update giftcard set enabled=0 where id in (" + ids + ")and isused = 0";
            giftcardEntities db = new giftcardEntities();
            db.Database.ExecuteSqlCommand(updatesql);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}