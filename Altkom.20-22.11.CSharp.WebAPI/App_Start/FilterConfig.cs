using System.Web;
using System.Web.Mvc;

namespace Altkom._20_22._11.CSharp.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
