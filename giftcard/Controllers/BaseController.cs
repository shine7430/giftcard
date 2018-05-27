using System.Web.Mvc;
using System.Web;
using System;
using AllTrustUs.WXPayAPILib;
using AllTrustUs.giftcard.Utility;
using System.Collections.Generic;
using AllTrustUs.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AllTrustUs.giftcard.Controllers
{
    public class BaseController : Controller
    {
        public static t_user CurrentUser
        {
            get
            {
                var context = System.Web.HttpContext.Current;
                if (context.Session["User"] != null)
                {
                    return (t_user)context.Session["User"];
                }
                else
                {
                    //context.Response.Redirect("/Home", true);
                    return null;
                }
            }
            set
            {
                var context = System.Web.HttpContext.Current;
                context.Session["User"] = value;
                context.Session.Timeout = 24 * 60;
            }
        }

        public static bool islogin
        {
            get
            {
                var context = System.Web.HttpContext.Current;
                if (context.Session["User"] != null)
                {
                    return true;
                }
                return false;
            }
        }
        public WeXUser CurrentWeXUser
        {
            get
            {
                if (Session["CurrentWeXUser"] is WeXUser)
                {
                    return (WeXUser)Session["CurrentWeXUser"];
                }
                else
                {
                    Log.Info("Get CurrentWeXUser", "=========" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    //Response.Redirect("~/login.aspx?flag=timeout&ActionPage=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
                    //Response.Redirect("~/login.aspx");
                    return null;
                }
            }
            set
            {
                Session["CurrentWeXUser"] = value;
            }
        }


        public string getToken(string appcode)
        {
            string _kdt_id = "";
            string _client_id = "";
            string _client_secret = "";
            giftcardEntities db = new giftcardEntities();
            object[] obj = new object[1];
            t_apps app = db.Database.SqlQuery<t_apps>("select * from t_apps where appcode='" + appcode + "'", obj).FirstOrDefaultAsync().Result;
            _kdt_id = app.kdt_id;
            _client_id = app.client_id;
            _client_secret = app.client_secret;
            if (System.Web.HttpContext.Current.Cache["AccessToken_"+ _kdt_id] != null)
            {
                return (string)System.Web.HttpContext.Current.Cache["AccessToken_" + _kdt_id];
            }
            else
            {
                string url = string.Format("https://open.youzan.com/oauth/token?client_id="+ _client_id + "&client_secret="+ _client_secret + "&grant_type=silent&kdt_id="+ _kdt_id);
                AccessToken curToken = AccessTokenRequest(url);
                if (curToken.access_token == null)
                {
                    throw new Exception("token 获取异常！");
                }
                var ms = Convert.ToDouble(curToken.expires_in) - 1000;
                System.Web.HttpContext.Current.Cache.Insert("AccessToken_" + _kdt_id, curToken.access_token, null,
                                                 DateTime.Now.Add(System.TimeSpan.FromSeconds(ms)),
                                                 System.TimeSpan.Zero);

                return curToken.access_token;
            }

            //if (System.Web.HttpContext.Current.Cache["AccessToken_40161714"] != null)
            //{
            //    return (string)System.Web.HttpContext.Current.Cache["AccessToken_40161714"];
            //}
            //else
            //{
            //    string url = string.Format("https://open.youzan.com/oauth/token?client_id=2e6259a7d6e91d6875&client_secret=7dc62b1091aff300d4bf6153e7e84b84&grant_type=silent&kdt_id=40161714");
            //    AccessToken curToken = AccessTokenRequest(url);
            //    var ms = Convert.ToDouble(curToken.expires_in) - 1000;
            //    System.Web.HttpContext.Current.Cache.Insert("AccessToken_40161714", curToken.access_token, null,
            //                                     DateTime.Now.Add(System.TimeSpan.FromSeconds(ms)),
            //                                     System.TimeSpan.Zero);

            //    return curToken.access_token;
            //}
        }

        private AccessToken AccessTokenRequest(string queryString)
        {
            var jsonResult = string.Empty;
            try
            {
                jsonResult = HttpService.Get(queryString);
                return JsonUtility.Deserialize<AccessToken>(jsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + jsonResult + "\n" + queryString);
            }
        }

        public class AccessToken
        {
            public string access_token { set; get; }
            public int expires_in { set; get; }
            public string scope { set; get; }


        }

        public class WeXUser
        {
            public string openid { get; set; }
            public string nickname { get; set; }

            private string _sex;
            public string sex
            {
                get
                {
                    return this._sex == "1" ? "Male" : "famale";
                }
                set
                {
                    this._sex = value;
                }
            }
            public string sexCN
            {
                get
                {
                    return this._sex == "1" ? "男" : "女";
                }
            }
            public string language { get; set; }
            public string city { get; set; }
            public string province { get; set; }
            public string country { get; set; }
            public string headimgurl { get; set; }
            public string MP { get; set; }
            public string createdate { get; set; }
            public string agencylevel { get; set; }
            public string discount { get; set; }
        }

        public class JsonMessage
        {
            public static JsonMessage Build(bool _state, string _message, dynamic _callbackData)
            {
                JsonMessage jMessage = new JsonMessage
                {
                    state = _state,
                    message = _message,
                    callbackData = _callbackData
                };
                return jMessage;
            }
            private JsonMessage()
            {
            }
            public bool state { get; protected set; }
            public string message { get; protected set; }
            public dynamic callbackData { get; protected set; }
        }

        public class InvokeResponse
        {
            public Response response
            {
                get;
                set;
            }
            public error_response error_response
            {
                get;
                set;
            }
        }


        public class Response
        {
            public string coupon_type
            {
                get;
                set;
            }

            public List<promocard> promocard
            {
                get;
                set;

            }
        }
        public class promocard
        {
            public string promocard_id
            {
                get;
                set;
            }
            public string title
            {
                get;
                set;
            }
            public string value
            {
                get;
                set;
            }
            //  "promocard_id": "10422654",
            //"title": "华宇测试0722",
            //"value": "1.00",
            //"condition": "无限制",
            //"start_at": "2016-07-22 17:35:03",
            //"end_at": "2016-07-30 17:34:23",
            //"is_used": "0",
            //"is_invalid": "0",
            //"is_expired": 0,
            //"background_color": "#55bd47",
            //"detail_url": "https://wap.koudaitong.com/v2/showcase/coupon/detail?alias=1359928&id=10422654",
            //"verify_code": "792873936041"
        }

        public class error_response
        {
            public string code
            {
                get;
                set;
            }

            public string msg
            {
                get;
                set;

            }

        }

        public static string MD5Encrypt(string strText,int i = 16)
        {
            //获取要加密的字段，并转化为Byte[]数组
            byte[] data = System.Text.Encoding.Unicode.GetBytes(strText.ToCharArray());
            //建立加密服务
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //加密Byte[]数组
            byte[] result = md5.ComputeHash(data);
            //将加密后的数组转化为字段
            if (i == 16 && strText != string.Empty)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToLower().Substring(8, 16);
            }
            else if (i == 32 && strText != string.Empty)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToLower();
            }
            else
            {
                switch (i)
                {
                    case 16: return "000000000000000";
                    case 32: return "000000000000000000000000000000";
                    default: return "请确保调用函数时第二个参数为16或32";
                }

            }
        }

        public string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        public string formatstring(string str)
        {
            return string.IsNullOrEmpty(str) ? "null" : "'" + str.Replace("'", "''").Replace("\\", "\\\\") + "'";
        }
        public string formatJson(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '/': sb.Append("\\/"); break;
                    case '\b': sb.Append("\\b"); break;
                    case '\f': sb.Append("\\f"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default: sb.Append(c); break;
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// unicode转中文（符合js规则的）
        /// </summary>
        /// <returns></returns>
        public string UnicodeToString(string str)
        {
            string outStr = "";
            Regex reg = new Regex(@"(?i)\\u([0-9a-f]{4})");
            outStr = reg.Replace(str, delegate (Match m1)
            {
                return ((char)Convert.ToInt32(m1.Groups[1].Value, 16)).ToString();
            });
            return outStr;
        }
    }
}