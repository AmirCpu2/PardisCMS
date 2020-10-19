using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pardis.WebApp.Areas.Admin.Controllers
{
    public partial class HomeAdminisController : Controller
    {
        // GET: Admin/HomeAdminis
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}