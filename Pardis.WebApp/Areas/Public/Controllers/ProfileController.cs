using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp.Areas.Public.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class ProfileController : Controller
    {
        // GET: Public/Items
        public virtual JsonResult FillProfileCustommers()
        {
            var result = ProfileBLL.Instance.FillProfileCustommers();

            return PardisJson(result.ToList());
        }

        public virtual JsonResult PardisJson(object item)
        {
            return Json(item, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}