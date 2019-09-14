using System.Web;
using System.Web.Mvc;

namespace Courts_Searchable_Dropdown
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}