﻿using AllTrustUs.Data;
using AllTrustUs.SquirrelPocket.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Demo
    {
        public int result { get; set; }
        public string errMsg { get; set; }
        public string ext { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 请根据实际 appid 和 appkey 进行开发，以下只作为演示 sdk 使用
            // appid,appkey,templId申请方式可参考接入指南 https://www.qcloud.com/document/product/382/3785#5-.E7.9F.AD.E4.BF.A1.E5.86.85.E5.AE.B9.E9.85.8D.E7.BD.AE
            int sdkappid = 1400096240;
            string appkey = "409fa0923289125b7b12025b0b281535";
            string phoneNumber1 = "15221336036";
            string phoneNumber2 = "15221336036";
            string phoneNumber3 = "15221336036";
            int tmplId = 128733;

            try
            {
                //SmsSingleSenderResult singleResult;
                //SmsSingleSender singleSender = new SmsSingleSender(sdkappid, appkey);

                //singleResult = singleSender.Send(0, "86", phoneNumber2, "测试短信，普通单发，深圳，小明，上学。", "", "");
                //Console.WriteLine(singleResult);


                List<string> templParams = new List<string>();
                templParams.Add("7876");
                //// 指定模板单发
                //// 假设短信模板内容为：测试短信，{1}，{2}，{3}，上学。
                //singleResult = singleSender.SendWithParam("86", phoneNumber2, tmplId, templParams, "", "", "");
                //Console.WriteLine(singleResult);
                //return;
                SmsMultiSenderResult multiResult;
                SmsMultiSender multiSender = new SmsMultiSender(sdkappid, appkey);
                List<string> phoneNumbers = new List<string>();
                //phoneNumbers.Add(phoneNumber1);
                //phoneNumbers.Add(phoneNumber2);
                //phoneNumbers.Add(phoneNumber3);
                DataTable dt = MySqlHelp.ExecuteDataTable("select * from t_customers");
                foreach (DataRow dr in dt.Rows)
                {
                    phoneNumbers.Add(dr["CellNumber"].ToString());
                }
                // 普通群发
                // 下面是 3 个假设的号码
                multiResult = multiSender.Send(0, "86", phoneNumbers, "测试短信，普通群发，深圳，小明，上学。", "", "");
                Console.WriteLine(multiResult);
                return;
                // 指定模板群发
                // 假设短信模板内容为：测试短信，{1}，{2}，{3}，上学。
                templParams.Clear();
                templParams.Add("指定模板群发");
                templParams.Add("深圳");
                templParams.Add("小明");
                multiResult = multiSender.SendWithParam("86", phoneNumbers, tmplId, templParams, "", "", "");
                Console.WriteLine(multiResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Read();
        }
    }
}
