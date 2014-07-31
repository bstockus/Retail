using Retail.Web.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CompanyNameActionAttribute());
        }
    }
}
