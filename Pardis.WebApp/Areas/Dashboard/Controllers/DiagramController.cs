using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp.Areas.Dashboard.Controllers
{
    public partial class DiagramController : Controller
    {
        // GET: Dashboard/Diagram
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}