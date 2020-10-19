using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp.Areas.Public.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class ProductController : Controller
    {
        // GET: Public/Product
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult FillProductSearching(string term = "")
        {
            var result = ProductBLL.Instance.FillProductSearching(term);

            return PardisJson(result.ToList());
        }

        public virtual JsonResult FillProductByFolderId(int id)
        {
            var result = ProductBLL.Instance.FillProductByFolderId(id);

            return PardisJson(result.ToList());
        }

        public virtual JsonResult PardisJson(object item)
        {
            return Json(item, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}