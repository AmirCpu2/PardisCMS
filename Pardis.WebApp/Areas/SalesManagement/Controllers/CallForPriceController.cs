using Newtonsoft.Json;
using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.WebApp.Areas.SalesManagement.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class CallForPriceController : Controller
    {
        // GET: SalesManagement/CallForPrice
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
        public virtual ActionResult AddOrUpdate(string entity)
        {
            var entityModel = JsonConvert.DeserializeObject<VM.CallForPriceVM>(entity);

            if (entityModel == null)
                return null;

            var folder = SalesFolderBLL.Instance.GetOneById(entityModel.SalesFolderId);

            folder.ProcessStepId = (short)Enums.ProcessStep.AcceptPriceAnnouncement;

            SalesFolderBLL.Instance.AddOrUpdate(folder);

            //var result = CallForPriceBLL.Instance.AddOrUpdate(entityModel);

            TempData["Message"] = folder != null ? "عملیات با موفقیت انجام شد" : "عملیات با موفقیت انجام نشد";

            //if (result == null)
            //    return 0;

            return Content(entityModel.SalesFolderId.ToString());
        }
    }
}