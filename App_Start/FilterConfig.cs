using System.Web;
using System.Web.Mvc;

namespace LKS_Laundry_Prov_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
