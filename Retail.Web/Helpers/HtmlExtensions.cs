using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web.Helpers {
    public static class HtmlExtensions {
        public static IEnumerable<SelectListItem> SetSelected(this IEnumerable<SelectListItem> selectList, object selectedValue) {
            selectList = selectList ?? new List<SelectListItem>();
            if (selectedValue == null)
                return selectList;
            var vlaue = selectedValue.ToString();
            return selectList
                .Select(m => new SelectListItem {
                    Selected = string.Equals(vlaue, m.Value),
                    Text = m.Text,
                    Value = m.Value
                });
        }
    }

}