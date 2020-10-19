using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp.Areas.SalesManagement.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class NeedController : Controller
    {
        public virtual JsonResult GetAllNeedsByProfileId(int id)
        {

            var result = NeedBLL.Instance.GetAllNeedsByProfileId(id);

            return PardisJson(result.ToList());
        }

        public virtual JsonResult PardisJson(object item)
        {
            return Json(item, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}