using System.Web;
using System.Web.Mvc;

namespace ACCIST.Despesas.ApplicationWebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
