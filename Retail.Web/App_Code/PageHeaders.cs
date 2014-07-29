using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retail.Web {
    public class PageHeaders {

        public static ViewDataDictionary Details(string type, string types, string name, int id) {
            var vd = new ViewDataDictionary();
            vd.Add("_Type", type);
            vd.Add("_Types", types);
            vd.Add("_Name", name);
            vd.Add("Id", id);
            return vd;
        }

    }
}