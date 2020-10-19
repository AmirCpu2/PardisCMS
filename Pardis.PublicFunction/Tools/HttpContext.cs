using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pardis.PublicFunction.Tools
{
    public partial class HttpTools
    {
        public static bool PathRequestComparetor(ViewContext context,string action, string controller=null, string areas=null)
        {
            //GetRequiredString("action")
            string actionName = context.RouteData.Values["action"].ToString().ToLower();
            string controllerName = context.RouteData.Values["controller"].ToString().ToLower();
            string areasName = context?.RouteData?.DataTokens["area"]?.ToString().ToLower();

            if (action == null && controller.ToLower().Equals(controllerName) && areas.ToLower().Equals(areasName))
                return true;

            if (action == null && controller == null && areas.ToLower().Equals(areasName))
                return true;

            if (action == null)
                return false;

            if (actionName.Equals(action.ToLower()) && controller == null && areas == null)
                return true;
            
            if (actionName.Equals(action.ToLower()) && controller.ToLower().Equals(controllerName) && areas == null)
                return true;
            
            if (actionName.Equals(action.ToLower()) && controller.ToLower().Equals(controllerName) && areas.ToLower().Equals(areasName))
                return true;

            return false;
        }
    }
}
