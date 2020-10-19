using Pardis.Product.BLL.Functions;
using Pardis.Product.BLL.ViewModel;
using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp
{
    internal class CustomerSettingClass
    {
        internal bool IsValid_Repeat { get; set; }
        internal bool IsValid_Required { get; set; }
        internal string WrongItem { get; set; }
        internal string WrongValue { get; set; }
    }

    //the codes
    public abstract partial class CustomController : Controller
    {

        [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
        protected ActionResult NotAccessContent()
        {
            if (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
            {
                Response.StatusCode = 403;
                var result = new ContentResult()
                {
                    Content = "<div class='alert alert-danger'>" +
                              "<i class='fa fa-exclamation-triangle'></i> مجوز دسترسی وجود ندارد!! " +
                              "</div>",
                    ContentType = "text/html"
                };
                return result;
            }

            TempData["Warning"] = $@"شما مجوز دسترسی به محتویات آن صفحه را نداشتید!";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        //======================================

        private ActionResult BaseRedirect(string messageTemplate, string tempDataName, string actionName, string redirectController, object routeValues = null, object model = null, string customMessage = "")
        {
            var message = (string.IsNullOrEmpty(customMessage)) ? "" : customMessage;
            if (routeValues.GetPropertyFromModel<int>("resultId") > 0)
            {
                string str = $"<input type=\"hidden\" id=\"ReturnData\" value=\"{routeValues.GetPropertyFromModel<int>("resultId")}\" />";
                message += str;
            }
            if (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
                return Content(message);
            TempData[tempDataName] = message;

            if (string.IsNullOrEmpty(actionName))
                actionName = "Index";

            if (string.IsNullOrEmpty(redirectController))
                return RedirectToAction(actionName, routeValues);

            return RedirectToAction(actionName, redirectController, routeValues);
        }

        protected ActionResult RedirectToNotFound(string actionName = null, string redirectController = null, string redirectArea = null)
        {
            var message = "notFoundMessage";
            var tempDataName = "Failed";
            return BaseRedirect(message, tempDataName, actionName, redirectController, new { area = redirectArea });
        }
        protected ActionResult RedirectToFailed(string actionName = null, string redirectController = null, string redirectArea = null)
        {
            var message = "notFoundMessage";
            var tempDataName = "Failed";
            return BaseRedirect(message, tempDataName, actionName, redirectController, new { area = redirectArea });
        }
        protected ActionResult RedirectToFailed(string actionName, string redirectController, object routeValues, string customMessage = "")
        {
            var message = "notFoundMessage";
            var tempDataName = "Failed";
            return BaseRedirect(message, tempDataName, actionName, redirectController, routeValues, null, customMessage);
        }
        protected ActionResult RedirectToSuccessfull(string actionName, string redirectController = null, object routeValues = null, string customMessage = null)
        {
            var message = "successMessage";
            var tempDataName = "Success";
            return BaseRedirect(message, tempDataName, actionName, redirectController, routeValues);
        }
        protected ActionResult RedirectToSuccessfull(string actionName = null, object routeValues = null, string customMessage = null)
        {
            var message = "successMessage";
            var tempDataName = "Success";
            return BaseRedirect(message, tempDataName, actionName, null, routeValues);
        }

        protected ActionResult RedirectToAccessDenied(string actionName = null, string redirectController = null, string redirectArea = null)
        {
            return RedirectToAccessDenied(actionName, redirectController, new { area = redirectArea });
        }
        protected ActionResult RedirectToAccessDenied(string actionName, string redirectController, object routeObject)
        {
            var message = "AccessDenied";
            var tempDataName = "Warning";
            return BaseRedirect(message, tempDataName, actionName, redirectController, routeObject);
        }
        protected ActionResult View_SetFailedFlag(ViewResult view, string message = null, string labelType = "Failed")
        {
            if (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
                return Content(message);
            TempData[labelType] = (string.IsNullOrWhiteSpace(message)) ? "" : message;
            return view;
        }

        protected ActionResult View_SetRepeatedFlag(ViewResult view)
        {
            var message = "";
            return View_SetFailedFlag(view, message, "Warning");
        }
        protected ActionResult View_SetExceptionFlag(ViewResult view, string exceptionMessage)
        {
            var message = "" + $"<span class=\"hide\">{exceptionMessage}</span>";
            return View_SetFailedFlag(view, message, "Warning");
        }
        protected ActionResult View_SetFormNotInState(ViewResult view)
        {
            var message = "";
            return View_SetFailedFlag(view, message, "Warning");
        }
        public JsonResult PardisJson(object item)
        {
            return Json(item, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public ContentResult MessageContent(string message, string status = "info")
        {
            return Content($"<p class='bg-{status} p-5 text-sm'>{message}</p>");
        }

        protected bool ViewIsExists(string name)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
            return (result.View != null);
        }

    }

    //the var
    public abstract partial class CustomControllerVar
    {

        protected string BazPath { get; } = ConfigurationManager.AppSettings["BazRoot"];

        protected Account _user { get; } = SSO.CurrentAccount;
    }
}