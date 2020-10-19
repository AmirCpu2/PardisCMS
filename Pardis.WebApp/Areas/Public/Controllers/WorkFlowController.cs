using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.WebApp.Areas.Public.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class WorkFlowController : Controller
    {
        // GET: Public/WorkFlow
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult ShowWorFlowByContentId(int contentId)
        {
            //Fake Engine
            var Folder = SalesFolderBLL.InstanceContent.GetOneById(contentId);

            var workFlow = new VM.WorkFlow
            {
                Id = 1,
                CurentStepId = Folder.ProcessStepId ?? 1,
                NameEn = "",
                NameFa = "تامین",
                Steps = new List<VM.WorkFlowStep>()
            };

            string[] stepColaction = { "ثبت درخواست" , "بررسی LOM" , "استعلام قیمت", "بررسی قیمت", "تایید مدیر تامین" };
            
            int i = 0;
            
            //Setup Step
            foreach(var item in stepColaction)
            {
                var step = Enums.WorkFlowStatus.disable;

                if (Folder.ProcessStepId-1 > i)
                    step = Enums.WorkFlowStatus.done;

                if (Folder.ProcessStepId-1 == i)
                    step = Enums.WorkFlowStatus.current;

                workFlow.Steps.Add(new VM.WorkFlowStep {
                    Id = i++,
                    NameFa = item,
                    Status = step
                });
            }


            return View("_SetepWorkFlow",workFlow);
        }

        public virtual ActionResult RouteAction(int id)
        {
            //Fake Engine
            var folder = SalesFolderBLL.InstanceContent.GetOneById(id);

            if (folder == null)
                return null ;

            switch(folder?.ProcessStepId ?? 1)
            {
                case 2:
                    return RedirectToAction(MVC.SalesManagement.ProductRelated.AddOrUpdate(id));
                case 3:
                    return RedirectToAction(MVC.SalesManagement.CallForPrice.AddOrUpdate(id));
            }

            TempData["Message"] = "شما به این بخش دسترسی ندارید.";
            return RedirectToAction(MVC.SalesManagement.SalesFolder.Index(id));
        }
    }
}