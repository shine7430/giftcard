﻿using AllTrustUs.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            ViewBag.Title = "礼品码管理";
            ViewBag.appcode = id;
            return View();
        }

        public JsonResult GetYouZanCards(string id)
        {
            giftcardEntities db = new giftcardEntities();
            var app = db.Database.SqlQuery<t_apps>("select * from t_apps where appcode='" + id + "'").FirstOrDefault();
            ViewBag.apphormurl = app.homeurl;
            

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
            var result1 = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"验证成功!\",\"giftcardlist\":" + result + "}}";

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GenerateGiftCode(String count, String amount, String expireddate, String forcompany, String PromoId, String jumpurl)
        {
            giftcardEntities db = new giftcardEntities();
            object[] obj = new object[1];
            //var cards = db.Database.SqlQuery<v_giftcard>(getsql, obj).ToList();

            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"验证成功!\"}}";
            var allcards = "";
            try
            {
                for (int i = 0; i < Convert.ToInt32(count); i++)
                {

                    string code = GetRandomString(12, true, false, false, false, "");
                    string insof = @"insert into giftcard(giftcardcode,amount,expireddate,forcompany,generatedate,PromoId,jumpurl) 
                                    values({0},{1},{2},{3},{4},{5},{6});
";

                    insof = string.Format(insof,
                    this.formatstring(code),
                    this.formatstring(amount),
                    this.formatstring(expireddate),
                    this.formatstring(""),
                    this.formatstring(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    this.formatstring(PromoId),
                    this.formatstring(jumpurl)
                    );
                    allcards += insof;
                }
                db.Database.ExecuteSqlCommand(allcards);
            }
            catch (Exception ex)
            {
                result = "{\"response\": {\"issuccess\": \"0\",\"msg\": \"" + ex.Message + "\"}}";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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


        public ActionResult CustomerManage(string id)
        {
            ViewBag.Title = "礼品码管理";
            ViewBag.appcode = id;
            return View();
        }

        public JsonResult GetCustomer(string id)
        {
            giftcardEntities db = new giftcardEntities();
            var app = db.Database.SqlQuery<t_apps>("select * from t_apps where appcode='" + id + "'").FirstOrDefault();
            ViewBag.apphormurl = app.homeurl;


            Auth auth = new Token(getToken(id)); // Auth auth = new Sign("app_id", "app_secret");
            YZClient yzClient = new DefaultYZClient(auth);
            Dictionary<string, object> dict = new System.Collections.Generic.Dictionary<string, object>();
            
            dict.Add("page_no", 1);
            dict.Add("page_size", 50);
            var result = yzClient.Invoke("youzan.scrm.customer.search", "3.1.0", "POST", dict, null);

            JObject obj = (JObject)JsonConvert.DeserializeObject(result);
            string recordlist = "";
            int total = Convert.ToInt32(((Newtonsoft.Json.Linq.JValue)obj["response"]["total"]).Value);
            recordlist = obj["response"]["record_list"].ToString().Replace("[", "").Replace("]", "");
            int pagecount = total / 50 + 1;

            for(var i = 2; i <= pagecount; i++)
            {
                Dictionary<string, object> dict1 = new System.Collections.Generic.Dictionary<string, object>();

                dict1.Add("page_no", i);
                dict1.Add("page_size", 50);
                string result1 = yzClient.Invoke("youzan.scrm.customer.search", "3.1.0", "POST", dict1, null);
                JObject obj1 = (JObject)JsonConvert.DeserializeObject(result1);
                recordlist += "," + obj1["response"]["record_list"].ToString().Replace("[", "").Replace("]", "");
            }
            ViewBag.result = recordlist;
            var resultreturn = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"验证成功!\",\"record_list\":[" + recordlist + "]}}";

            return Json(resultreturn, JsonRequestBehavior.AllowGet);
        }

    }
}