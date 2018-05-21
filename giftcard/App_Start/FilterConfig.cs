using System.Web;
using System.Web.Mvc;

namespace AllTrustUs.giftcard
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
