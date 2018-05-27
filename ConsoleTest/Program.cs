using AllTrustUs.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            giftcardEntities db = new giftcardEntities();
            var us1= db.Database.SqlQuery<t_user>("select * from t_user").ToList();

            var us = db.t_user.Where(u => u.mobile == "15221336036").ToList();
            var ConnectionString = db.Database.Connection.ConnectionString;
            //foreach(t_user u in us)
            //{
            //    Console.WriteLine(u.mobile);
            //}
        }
    }
}
