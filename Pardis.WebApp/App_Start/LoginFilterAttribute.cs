using Pardis.Product.BLL.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pardis.WebApp
{
    internal class LoginFilterAttribute : ActionFilterAttribute
    {
        public Enums.AccountPermisionInheritedType InheritedType { get; set; }
        private List<Enums.Role> RolesAccess { set; get; }
        private List<Enums.Role> RolesAccessDenied { set; get; }

        public LoginFilterAttribute(Enums.AccountPermisionInheritedType inheritedType)
        {
            this.InheritedType = inheritedType;
        }

        public LoginFilterAttribute(List<Enums.Role> rolesAccess = null, List<Enums.Role> rolesAccessDenied = null, Enums.AccountPermisionInheritedType inheritedType = Enums.AccountPermisionInheritedType.Inherited)
        {
            RolesAccess = rolesAccess;
            RolesAccessDenied = rolesAccessDenied;
            InheritedType = inheritedType;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //EveryOne
            if (InheritedType == Enums.AccountPermisionInheritedType.EveryOne)
            { base.OnActionExecuting(filterContext); return; }

            //Login Check
            if (SSO.CurrentAccount == null || SSO.CurrentAccount.UserName == null)
            {
                filterContext.Controller.TempData["ErrorMessage"] = "شما می بایست دوباره وارد شوید!";
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"area", ""},
                        {"controller", "Home"},
                        {"action", "Login"}
                    });

                SSO.CurrentAccount = null;

                base.OnActionExecuting(filterContext); return;
            }

            //So User By Logined
            if (InheritedType == Enums.AccountPermisionInheritedType.Logined)
            { base.OnActionExecuting(filterContext); return; }


            //Role Permission Check
            if (SSO.CurrentAccount.Roles.Count(q => RolesAccess.Contains(q)) == 0 ||
                    SSO.CurrentAccount.Roles.Count(q => RolesAccessDenied.Contains(q)) > 0)
            {
                filterContext.Controller.TempData["Warning"] = "شما مجوز دسترسی به آن صفحه را نداشتید!";

                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "area",""},
                        { "controller", "Home" },
                        { "action", "Index" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

    }

}