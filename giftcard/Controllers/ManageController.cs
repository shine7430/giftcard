using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllTrustUs.giftcard.Utility;
using Newtonsoft.Json;

namespace AllTrustUs.giftcard.Controllers
{

    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        public string Upload(HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                return "文件为空";
            }
            try
            {
                //将硬盘路径转化为服务器路径的文件流
                string fileName = Path.Combine(Request.MapPath("~/SaveFile"), Path.GetFileName(fileUpload.FileName));
                //NPOI得到EXCEL的第一种方法              
                fileUpload.SaveAs(fileName);
                //DataTable dtData = ExcelHelper.ExcelToDataTable(fileName);
                ////得到EXCEL的第二种方法(第一个参数是文件流,第二个是excel标签名,第三个是第几行开始读0算第一行)
                //DataTable dtData2 = ExcelHelper.RenderDataTableFromExcel(fileName, fileUpload.FileName, 0);
                return "导入成功";
            }
            catch(Exception ex)
            {
                return "导入失败"+ ex.Message;
            }
        }

        [HttpPost]
        public JsonResult UploadByAjax()
        {
            var allinsertsql = "";
            var JsonString = "";
            try
            {
                //取得目前 HTTP 要求的 HttpRequestBase 物件
               
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // 取得的檔案是stream
                        var stream = fileContent.InputStream;
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(Request.MapPath("~/SaveFile"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        ExcelHelper excel_helper = new ExcelHelper(path);
                        DataTable dt = excel_helper.ExcelToDataTable("", true);
                        JsonString = "dt completed";

                        //List<string> tableList = GetColumnsByDataTable(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            string insertSql = @"
insert into t_orders(ImportName,ProductName,Number,Spec,Price,OrderID,OrderDetailID,OrderDate,CustomerName,CellNumber,Province,City,District,Address) 
values ("
                              + "'" + fileName + "',"
                              + "'" + dr[1].ToString() + "',"
                              + "'" + dr[2].ToString() + "',"
                              + "'" + dr[3].ToString() + "',"
                              + "'" + dr[4].ToString() + "',"
                              + "'" + dr[5].ToString() + "',"
                              + "'" + dr[6].ToString() + "',"
                              + "'" + dr[7].ToString() + "',"
                              + "'" + dr[8].ToString() + "',"
                              + "'" + dr[9].ToString() + "',"
                              + "'" + dr[10].ToString() + "',"
                              + "'" + dr[11].ToString() + "',"
                              + "'" + dr[12].ToString() + "',"
                              + "'" + dr[13].ToString() + "');";
                            allinsertsql += insertSql;
                        }
                        allinsertsql = "delete from t_orders where ImportName='" + fileName + "';" + allinsertsql;
                        JsonString = "allinsertsql completed"+ allinsertsql;
                        MySqlHelp.ExecuteNonQuery(allinsertsql);
                        string selectsql = @"set @rowno := 0;select @rowno:=@rowno + 1 AS rowno,a.* from (
select CustomerName,CellNumber,
GROUP_CONCAT(CONCAT(ProductName,Spec, CAST(Number AS char),'份',CHAR(10) )) as 'Product',
CONCAT(Province,City,District,Address ) as 'Address'
from t_orders
where ImportName='" + fileName + @"'
GROUP BY CustomerName,CellNumber,Address
) a ,(SELECT @rowno:=0) b;
select ProductName,Spec,SUM(Number) as 'SUM'
from t_orders
where ImportName='" + fileName + @"'
GROUP BY ProductName,Spec
";
                        JsonString = "selectsql completed"+ selectsql;
                        DataSet sdt = MySqlHelp.ExecuteDataSet(selectsql);
                        
                        JsonString = DataTableToJsonWithJsonNet(sdt);
                    }
                }

                return Json(JsonString);
            }
            catch(Exception ex)
            {
                return Json(ex.Message + JsonString);
            }
        }

        public string DataTableToJsonWithJsonNet(DataSet table)
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(table);
            return JsonString;
        }
    }
}