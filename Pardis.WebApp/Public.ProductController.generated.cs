// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Pardis.WebApp.Areas.Public.Controllers
{
    public partial class ProductController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProductController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult FillProductByFolderId()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.FillProductByFolderId);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult PardisJson()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.PardisJson);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductController Actions { get { return MVC.Public.Product; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Public";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Product";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Product";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string FillProductSearching = "FillProductSearching";
            public readonly string FillProductByFolderId = "FillProductByFolderId";
            public readonly string PardisJson = "PardisJson";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string FillProductSearching = "FillProductSearching";
            public const string FillProductByFolderId = "FillProductByFolderId";
            public const string PardisJson = "PardisJson";
        }


        static readonly ActionParamsClass_FillProductSearching s_params_FillProductSearching = new ActionParamsClass_FillProductSearching();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_FillProductSearching FillProductSearchingParams { get { return s_params_FillProductSearching; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_FillProductSearching
        {
            public readonly string term = "term";
        }
        static readonly ActionParamsClass_FillProductByFolderId s_params_FillProductByFolderId = new ActionParamsClass_FillProductByFolderId();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_FillProductByFolderId FillProductByFolderIdParams { get { return s_params_FillProductByFolderId; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_FillProductByFolderId
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_PardisJson s_params_PardisJson = new ActionParamsClass_PardisJson();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PardisJson PardisJsonParams { get { return s_params_PardisJson; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PardisJson
        {
            public readonly string item = "item";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ProductController : Pardis.WebApp.Areas.Public.Controllers.ProductController
    {
        public T4MVC_ProductController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void FillProductSearchingOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string term);

        [NonAction]
        public override System.Web.Mvc.JsonResult FillProductSearching(string term)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.FillProductSearching);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "term", term);
            FillProductSearchingOverride(callInfo, term);
            return callInfo;
        }

        [NonAction]
        partial void FillProductByFolderIdOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.JsonResult FillProductByFolderId(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.FillProductByFolderId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            FillProductByFolderIdOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void PardisJsonOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, object item);

        [NonAction]
        public override System.Web.Mvc.JsonResult PardisJson(object item)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.PardisJson);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "item", item);
            PardisJsonOverride(callInfo, item);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
