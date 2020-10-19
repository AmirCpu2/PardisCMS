using Newtonsoft.Json.Linq;
using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.WebApp.Areas.Public.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class ItemsController : Controller
    {
        // GET: Public/Items
        public virtual JsonResult FillItemsByTypeNameEn(string TypeNameEn)
        {
            if (String.IsNullOrWhiteSpace(TypeNameEn))
                return null;

            var result = ItemBLL.Instance.FillItemsByTypeNameEn(TypeNameEn);

            return PardisJson(result.ToList());
        }

        public virtual JsonResult FillItemsByTypeId(int TypeId)
        {
            if (TypeId == 0)
                return null;

            var result = ItemBLL.Instance.FillItemsByTypeId(TypeId);

            return PardisJson(result.ToList());
        }

        public virtual JsonResult PardisJson(object item)
        {
            return Json(item, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}