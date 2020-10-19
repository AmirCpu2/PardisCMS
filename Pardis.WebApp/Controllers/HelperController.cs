using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp.Controllers
{
    public partial class HelperController : Controller
    {
        // GET: Helper
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}