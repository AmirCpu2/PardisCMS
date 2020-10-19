using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pardis.WebApp
{
    public class SubSystemController<TvModel, TmModel> : PublicController<TvModel, TmModel> where TvModel : Content, new() where TmModel : class, MM.IContent
    {
        public override ActionResult Index(int? id)
        {
            DestroySessions();
            if (CurrentUserLoginData.Area == "Adminis")
                HierarchyStructureBLL.Instance.LoadMenu(Enums.HierarchyStructureType.AdminisMenu);
            else
                HierarchyStructureBLL.Instance.LoadMenu(null, id);

            var viewAddress = $"~/Areas/{CurrentUserLoginData.Area}/Views/{CurrentUserLoginData.Controller}/{CurrentUserLoginData.Action}.cshtml";
            viewAddress = (string.IsNullOrEmpty(ViewBag.viewAddress)) ? viewAddress : ViewBag.ViewAddress;
            if (id > 0)
                return View(viewAddress, new Content() { Id = id.Value });
            if (Request.IsAjaxRequest())
                return View(viewAddress, masterName: "~/Views/Shared/_LayoutEmpty.cshtml");
            return View(viewAddress);
        }

        [LoginFilter("Create || Edit || AddOrUpdate")]
        public override ActionResult AddOrUpdate(int? id)
        {
            var entity = ContentBll<TvModel, TmModel>.InstanceContent.GetOneById(id) ?? new TvModel() { Id = 0, ParentId = id };
            if (entity.Id > 0)
            {
                if (!Account.CurrentAccount.HavePermissionsByUrl(CurrentUserLoginData.Area, CurrentUserLoginData.Controller, "Edit || AddOrUpdate"))
                    return RedirectToAccessDenied();

                SetSessions(PublicBLL.ConvertTvModelContentType<TvModel>(), entity.Id);
            }
            else
            {
                if (!Account.CurrentAccount.HavePermissionsByUrl(CurrentUserLoginData.Area, CurrentUserLoginData.Controller, "Create || AddOrUpdate"))
                    return RedirectToAccessDenied();
                DestroySessions();
            }

            ModelState.Clear();
            //Functions.LogToFile($"80 End AddOrUpdate {DateTime.Now.ToString("HH:mm:ss").PadLeft(25)}.{DateTime.Now.Millisecond} =>{Request?.Url?.LocalPath.PadLeft(55)} ",true, false);

            var viewAddress = $"~/Areas/{CurrentUserLoginData.Area}/Views/{CurrentUserLoginData.Controller}/{CurrentUserLoginData.Action}.cshtml";
            viewAddress = (string.IsNullOrEmpty(ViewBag.viewAddress)) ? viewAddress : ViewBag.ViewAddress;
            if (Request.IsAjaxRequest())
                return View(viewAddress, masterName: "~/Views/Shared/_LayoutEmpty.cshtml", model: entity);
            return View(viewAddress, entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoginFilter("Create || Edit || AddOrUpdate")]
        public override ActionResult AddOrUpdate(TvModel entity)
        {
            ViewBag.SubsystemContent = true;
            return base.AddOrUpdate(entity);
        }


        [LoginFilter("Index")]
        [HttpPost]
        public override JsonResult ShowGrid(JqgridModel model)
        {
            model.ModelType = (model.MasterContentId.HasValue && model.MasterContentId > 0) ? JqGridModelType.Dependent : JqGridModelType.Independent;
            return ContentBll<TvModel, TmModel>.InstanceContent.ShowJqGrid(model);
        }
    }
}