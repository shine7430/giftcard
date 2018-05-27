using AllTrustUs.Data;
using AllTrustUs.giftcard.Utility;
using AllTrustUs.WXPayAPILib;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YZOpenSDK;

namespace AllTrustUs.giftcard.Controllers
{
    public class CardTakeController : BaseController
    {
        // GET: CardTake
        public ActionResult Index(string id)
        {

            //if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            //{
            //    //获取code码，以获取openid和access_token
            //    string code = Request.QueryString["code"];
            //    Log.Debug(this.GetType().ToString(), "Get code : " + code);
            //    GetOpenidAndAccessTokenFromCode(code);
            //}
            //else
            //{
            //    //构造网页授权获取code的URL
            //    string host = Request.Url.Host;
            //    string path = Request.Path;
            //    string redirect_uri = HttpUtility.UrlEncode("http://" + host + path);
            //    WxPayData data = new WxPayData();
            //    data.SetValue("appid", WxPayConfig.APPID);
            //    data.SetValue("redirect_uri", redirect_uri);
            //    data.SetValue("response_type", "code");
            //    data.SetValue("scope", "snsapi_userinfo");
            //    data.SetValue("state", "STATE" + "#wechat_redirect");
            //    string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" + data.ToUrl();
            //    Log.Debug(this.GetType().ToString(), "Will Redirect to URL : " + url);
            //    try
            //    {
            //        //触发微信返回code码         
            //        Response.Redirect(url);//Redirect函数会抛出ThreadAbortException异常，不用处理这个异常
            //    }
            //    catch (System.Threading.ThreadAbortException ex)
            //    {
            //    }
            //}

            ViewBag.openid = "okou5v0jwgn_KHa85arH08pt5gtI";
            
            ViewBag.headimgurl = "http://wx.qlogo.cn/mmopen/vi_32/UicBUoZxmWeEy4PoxibVSTCWg2coTaG4bjoNFQKdF8ylI98bzHiaZVB0NEJbZyj0mBPibWUbXFQMJc9NibQicmdDAAoQ/0";
           
            ViewBag.nickname = "蜜岛果源";

            //ViewBag.openid = this.CurrentWeXUser.openid;
            //ViewBag.headimgurl = this.CurrentWeXUser.headimgurl;
            //ViewBag.nickname = this.CurrentWeXUser.nickname;
            ViewBag.appcode = id;
            return View();
        }

        public void GetOpenidAndAccessTokenFromCode(string code)
        {
            try
            {
                //构造获取openid及access_token的url
                WxPayData data = new WxPayData();
                data.SetValue("appid", WxPayConfig.APPID);
                data.SetValue("secret", WxPayConfig.APPSECRET);
                data.SetValue("code", code);
                data.SetValue("grant_type", "authorization_code");
                string url = "https://api.weixin.qq.com/sns/oauth2/access_token?" + data.ToUrl();
                //string url = "https://api.weixin.qq.com/sns/oauth2/userinfo?" + data.ToUrl();
                Log.Debug(this.GetType().ToString(), "GetOpenidAndAccessTokenFromCode url : " + url);
                //请求url以获取数据
                string result = HttpService.Get(url);

                Log.Debug(this.GetType().ToString(), "GetOpenidAndAccessTokenFromCode response : " + result);

                //保存access_token，用于收货地址获取
                JsonData jd = JsonMapper.ToObject(result);
                var access_token = (string)jd["access_token"];
                //Response.Write(result);

                //获取用户openid
                var openid = (string)jd["openid"];
                WxPayData dataUserInfo = new WxPayData();
                dataUserInfo.SetValue("access_token", access_token);
                dataUserInfo.SetValue("openid", openid);
                dataUserInfo.SetValue("lang", "zh_CN");

                url = "https://api.weixin.qq.com/sns/userinfo?" + dataUserInfo.ToUrl();
                result = HttpService.Get(url);
                FormatWeXUser(result);
                Log.Info("Successful login", "=========" + result);

                Log.Info("Successful login", "=========" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                //Response.Redirect("GifCardTake.aspx?Openid='" + openid + "'", false);
                //Response.Write(result);

                //Log.Debug(this.GetType().ToString(), "Get openid : " + openid);
                //Log.Debug(this.GetType().ToString(), "Get access_token : " + access_token);
            }
            catch (Exception ex)
            {
                Log.Error(this.GetType().ToString(), ex.ToString());
                throw new WxPayException(ex.ToString());
            }
        }
        private void FormatWeXUser(string JsonData)
        {
            var WeXUserDic = JsonUtility.ToDictionary(JsonData);


            WeXUser WU = new WeXUser();
            WU.sex = WeXUserDic["sex"].ToString();
            WU.openid = WeXUserDic["openid"].ToString();
            WU.nickname = WeXUserDic["nickname"].ToString();
            WU.headimgurl = WeXUserDic["headimgurl"].ToString();
            WU.country = WeXUserDic["country"].ToString();
            WU.province = WeXUserDic["province"].ToString();
            WU.city = WeXUserDic["city"].ToString();
            WU.agencylevel = "L-1";
            WU.discount = "1";
            this.CurrentWeXUser = WU;
        }

        public JsonResult giftcardtake(String appcode,String openid,String mobile ,String name,String cardcode)
        {
            string result = "{\"result\":\"failed\"}";
            int _PROMOCODEid;
            string getsql = "select * from giftcard where giftcardcode = '" + cardcode + "'";
            Auth auth = new Token(getToken(appcode)); // Auth auth = new Sign("app_id", "app_secret");
            YZClient yzClient = new DefaultYZClient(auth);
            Dictionary<string, object> dict;

            giftcardEntities db = new giftcardEntities();
            
            object[] obj = new object[1];
            var cards = db.Database.SqlQuery<AllTrustUs.Data.giftcard>(getsql, obj).ToList();

            if (cards.Count > 0)
            {
                if (cards[0].enabled == "0")
                {
                    result = "{\"response\": {\"issuccess\": 0,\"msg\": \"该礼品卡暂不可用，请联系公司负责人!\"}}";
                }
                else if (cards[0].isused == "1")
                {
                    result = "{\"response\": {\"issuccess\": 0,\"msg\": \"该礼品卡已被领用，不能重复注册!\"}}";
                }
                else
                {
                    try
                    {
                        _PROMOCODEid = Convert.ToInt32(cards[0].PromoId);

                        dict = new System.Collections.Generic.Dictionary<string, object>();
                        dict.Add("mobile", mobile);
                        dict.Add("coupon_group_id", _PROMOCODEid);

                        result = yzClient.Invoke("youzan.ump.coupon.take", "3.0.0", "POST", dict, null);

                        InvokeResponse Response = JsonUtility.Deserialize<InvokeResponse>(result);
                        if (Response.error_response == null && Response.response != null && Response.response.coupon_type == "PROMOCODE")
                        {


                            var updatecard = "update giftcard set isused='1',useddate='" + DateTime.Now.ToString("yyyy-MM-dd") + "',usedmobile='" + mobile + "',usedopenid='" + openid + "',usedname='" + name + "' where giftcardcode='" + cardcode.Replace("-", "") + "'";

                            db.Database.ExecuteSqlCommand(updatecard);

                            //MySqlHelp.ExecuteNonQuery(updatecard);
                            //string _sql="select jumpurl from giftcard where giftcardcode='" + cardcode.Replace("-", "") + "'";

                            //var returncards =  db.Database.SqlQuery<giftcard>(_sql, obj).ToList();
                            result = "{\"response\": {\"issuccess\": \"1\",\"msg\": \"验证成功!\",\"jumpurl\":\"" + cards[0].jumpurl + "\"}}";
                        }
                        else
                        {
                            result = "{\"response\": {\"issuccess\": \"0\",\"msg\": \"" + Response.error_response.msg + "\"}}";
                        }

                    }
                    catch (Exception ex)
                    {
                        result = "{\"response\": {\"issuccess\": 0,\"msg\": \"" + ex.Message + "!\"}}";
                    }
                }



            }
            else
            {
                result = "{\"response\": {\"issuccess\": 0,\"msg\": \"礼品卷不存在，请验证礼品卷码是否填写正确!\"}}";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
    }
}