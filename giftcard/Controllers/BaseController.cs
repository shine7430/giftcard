using System.Web.Mvc;
using System.Web;
using System;
using AllTrustUs.WXPayAPILib;
using AllTrustUs.giftcard.Utility;

namespace AllTrustUs.giftcard.Controllers
{
    public class BaseController : Controller
    {
        public t_user CurrentUser
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

        public string getToken(string appcode)
        {
            string _kdt_id = "";
            string _client_id = "";
            string _client_secret = "";
            if (System.Web.HttpContext.Current.Cache["AccessToken_"+ _kdt_id] != null)
            {
                return (string)System.Web.HttpContext.Current.Cache["AccessToken_" + _kdt_id];
            }
            else
            {
                string url = string.Format("https://open.youzan.com/oauth/token?client_id="+ _client_id + "&client_secret="+ _client_secret + "&grant_type=silent&kdt_id="+ _kdt_id);
                AccessToken curToken = AccessTokenRequest(url);
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
    }
}