using AllTrustUs.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace AllTrustUs.giftcard.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public JsonResult doRegister(String mobile, String passowrd, String CompanyName)
        {

            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"注册成功!\"}}";
            giftcardEntities db = new giftcardEntities();
            var u = db.Database.SqlQuery<t_user>("select * from t_user where mobile='" + mobile + "'").ToList();
            var _message = "";
            if (u.Count > 0)
            {
                _message= "手机号已存在！";
               
            }
            var c = db.Database.SqlQuery<t_user>("select * from t_user where CompanyName='" + CompanyName + "'").ToList();
            if (c.Count > 0)
            {
                _message = "公司已存在！";
            }
            if(string.IsNullOrEmpty(_message))
            {
                var isql = @"INSERT INTO t_user(username,password,mobile,registerdate,companyid,CompanyName)
VALUES ('" + mobile + "', '" + MD5Encrypt(passowrd) + "', '" + mobile + "', '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "', null, '" + CompanyName + "');";
                db.Database.ExecuteSqlCommand(isql);
            }
            else
            {
                result = "{\"response\": {\"issuccess\": \"0\",\"msg\": \""+ _message + "\"}}";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult dologin(String mobile, String passowrd)
        {
            var result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"注册成功!\"}}";
            giftcardEntities db = new giftcardEntities();
            var u = db.Database.SqlQuery<t_user>(@"select * from t_user where mobile='" + mobile + "' and " +
                " password='" + MD5Encrypt(passowrd) + "'").ToList();

            if (u.Count > 0)
            {
                CurrentUser = u[0];
            }
            else
            {
                result = "{\"response\": {\"issuccess\": \"0\",\"msg\": \"用户名或密码错误！\"}}";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void logout()
        {
            System.Web.HttpContext.Current.Session["User"] = null;
        }
    }
}