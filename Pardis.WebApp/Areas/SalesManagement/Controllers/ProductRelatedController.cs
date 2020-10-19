using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM = Pardis.Product.BLL.ViewModel;
using MM = Pardis.Product.DAL.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pardis.PublicFunction;
using Pardis.Product.BLL.Functions;
using System.ComponentModel.DataAnnotations;

namespace Pardis.WebApp.Areas.SalesManagement.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.EveryOne)]
    public partial class ProductRelatedController : Controller
    {
        // GET: SalesManagement/ProductRelated
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        /// <summary>
        /// AddOrUpdateBySalesFolderId
        /// </summary>
        /// <param name="id">SalesFolderId</param>
        /// <returns></returns>
        public virtual ActionResult AddOrUpdate(int id)
        {
            //Sel ID For Fetch WorkFlow
            ViewBag.SalsFoldeId = id;

            return View();
        }

        [HttpPost]
        /// <summary>
        /// AddOrUpdateBySalesFolderId
        /// </summary>
        /// <param name="id">SalesFolderId</param>
        /// <returns></returns>
        public virtual int AddOrUpdate(string entity)
        {

            if (entity == null || entity.Length < 1)
                return 0;

            var entityModel = JsonConvert.DeserializeObject<VM.ProductListRelatedList>(entity);

            var result = ProductListRelatedBLL.Instance.AddOrUpdateCustom(entityModel);

            TempData["Message"] = result != null ? "عملیات با موفقیت انجام شد" : "عملیات با موفقیت انجام نشد";

            if (result == null)
                return 0;
            
            return entityModel.SaleFolderId;
        }
    }
}