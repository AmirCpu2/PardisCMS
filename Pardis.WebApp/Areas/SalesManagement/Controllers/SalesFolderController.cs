using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pardis.Product.BLL.ViewModel;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.WebApp.Areas.SalesManagement.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class SalesFolderController : Controller
    {
        // GET: SalesManagement/SalesFolder
        public virtual ActionResult Index(int? id)
        {
            TempData["FolderId"] = id;

            return View();
        }

        [HttpPost]
        public virtual ActionResult Detail(int id, bool onTopForm = false)
        {
            //Get Entity model when Exist item from id
            var model = SalesFolderBLL.InstanceContent.GetOneById(id);

            if (model == null)
                return null;

            if(onTopForm)
                return View("_DetailOnTopPage", model);

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult DetailOnTopPage(int folderId)
        {
            //Get Entity model when Exist item from id
            var model = SalesFolderBLL.InstanceContent.GetOneById(folderId);

            if (model == null)
                return null;

            return View("_DetailOnTopPage", model);
        }


        [HttpPost]
        public virtual JsonResult ShowGrid(string sidx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //Get Data From BLL
            var entity = SalesFolderBLL.InstanceContent.GetAll_asQuery().Select(Mapper.Map);

            int totalRecords = entity.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                entity = entity.OrderByDescending(t => t.Id).ToList();
                entity = entity.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                entity = entity.OrderBy(t => t.Id).ToList();
                entity = entity.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = entity
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual ActionResult AddOrUpdate(int? id = null)
        {
            var model = new VM.SalesFolder();

            //Get Entity model when Exist item from id
            if (id != null)
               model = SalesFolderBLL.InstanceContent.GetOneById(id);

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult AddOrUpdate(VM.SalesFolder entity)
        {
            var result = 0;

            try
            {
                entity.PriceAnnouncementDeadline = PublicFunction.Functions.ConvertPersianToGregorianDate(entity.PriceAnnouncementDeadlineFa);
                entity.DeliveryDeadline = PublicFunction.Functions.ConvertPersianToGregorianDate(entity.DeliveryDeadlineFa);
                entity.ProcessStepId = (int)Enums.ProcessStep.ScrutinyLOM;

               result = SalesFolderBLL.InstanceContent.AddOrUpdate(entity).Id;
            }
            catch(Exception ex)
            {

            }

            TempData["Message"] = result > 0 ? "عملیات با موفقیت انجام شد" : "عملیات با موفقیت انجام نشد";
            return RedirectToAction("Index", new { id = result });
        }

        [HttpGet]
        public virtual JsonResult GetAllSalesFolderByProductId(int id)
        {

            var result = SalesFolderBLL.Instance.GetAllSalesFolderByProductId(id);

            return PardisJson(result.ToList());
        }

        [HttpGet]
        public virtual JsonResult GetAllSalesFolder()
        {

            var result = SalesFolderBLL.Instance.GetAllSalesFolder();

            return PardisJson(result.ToList());
        }

        public virtual JsonResult PardisJson(object item)
        {
            return Json(item, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}