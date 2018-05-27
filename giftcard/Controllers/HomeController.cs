using AllTrustUs.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllTrustUs.giftcard.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Company()
        {
            ViewBag.Message = "Your contact page.";
            if (CurrentUser == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Home");
            }
            ViewBag.userid = CurrentUser.id;
            return View();
        }

        public ActionResult Apps()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CardGeneration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CardTakelogs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult doAppCreate(String AppName, String kdt_id, String client_id, String client_secret)
        {

            giftcardEntities db = new giftcardEntities();

            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"创建成功！\"}}";
            var isql = @"INSERT INTO t_apps(client_id,client_secret,kdt_id,appname,expireddate,status,appcode)
VALUES ('" + client_id + "', '" + client_secret + "', '" + kdt_id + "','" + AppName + "', '" + DateTime.Now.AddMonths(1).ToString("yyyy/MM/dd") + " 23:59:59" + "', 'active', '" + Guid.NewGuid().ToString().Replace("-", "") + "');";
            db.Database.ExecuteSqlCommand(isql);

            var tp = db.Database.SqlQuery<t_apps>("select * from t_apps where client_id='" + client_id + "'").FirstOrDefault();
            db.Database.ExecuteSqlCommand("insert into t_user2app(appid,userid) VALUES ('" + tp.id + "','" + CurrentUser.id + "')");
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult doAppUpdate(String id, String AppName, String kdt_id, String client_id, String client_secret)
        {
            giftcardEntities db = new giftcardEntities();

            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"更新成功！\"}}";
            var isql = @"update t_apps set client_id='" + client_id + "',client_secret='" + client_secret + "',kdt_id='" + kdt_id + "',appname='" + AppName + "' where id=" + id;

            db.Database.ExecuteSqlCommand(isql);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult doAppDelete(String id)
        {
            giftcardEntities db = new giftcardEntities();

            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"更新成功！\"}}";
            var isql = @"delete from t_user2app where appid='" + id + "'; " +
                "delete from t_apps where id='" + id+"';";

            db.Database.ExecuteSqlCommand(isql);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult doAppLoad(String userid)
        {

            giftcardEntities db = new giftcardEntities();

            var isql = @"select * from v_userapps where userid='" + userid + "'";
            var apps = db.Database.SqlQuery<v_userapps>(isql).ToList();
            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"验证成功!\",\"userapplist\":" + JsonConvert.SerializeObject(apps) + "}}";
            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}