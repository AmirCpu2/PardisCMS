using Microsoft.Ajax.Utilities;
using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.WebApp.Controllers
{
    [LoginFilter(Enums.AccountPermisionInheritedType.Logined)]
    public partial class HomeController : Controller
    {

        public virtual ActionResult Index()
        {
            if (VM.SSO.CurrentAccount != null)
                return View();

            TempData["ErrorMessage"] = "شما میبایست دوباره وارد شوید";

            return View(MVC.Home.Actions.ActionNames.Login);
        }

        [HttpPost]
        public virtual JsonResult ShowGrid(string sidx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //Get Data From BLL
            var Cart = new List<VM.CardBoard> {
                new VM.CardBoard{
                    Id= 1,
                    Subject = "سفارش جدید",
                    Description = "لطفا سفارش جدید را بررسی نمایید",
                    RegisterDate = DateTime.Now
                },
                new VM.CardBoard{
                    Id= 2,
                    Subject = "سفارش جدید",
                    Description = "لطفا سفارش جدید را بررسی نمایید",
                    RegisterDate = DateTime.Now.AddDays(-1)
                },
                new VM.CardBoard{
                    Id= 3,
                    Subject = "سفارش جدید",
                    Description = "لطفا سفارش جدید را بررسی نمایید",
                    RegisterDate = DateTime.Now.AddDays(-2)
                },
            };

            int totalRecords = Cart.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                Cart = Cart.OrderByDescending(t => t.RegisterDate).ToList();
                Cart = Cart.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            else
            {
                Cart = Cart.OrderBy(t => t.RegisterDate).ToList();
                Cart = Cart.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Cart
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [LoginFilter(Enums.AccountPermisionInheritedType.EveryOne)]
        public virtual ActionResult Login()
        {
            VM.SSO.CurrentAccount = null;
            return View();
        }

        [HttpPost]
        [LoginFilter(Enums.AccountPermisionInheritedType.EveryOne)]
        public virtual ActionResult Login(VM.AccountLogin entity)
        {
            //entity.Password

            if (entity != null)
            {
                if (entity.UserName == "Admin")
                { 
                    VM.SSO.CurrentAccount = new VM.Account() {
                        UserName = entity.UserName,
                        Password = entity.Password,
                        Person = new VM.Person {
                            ImageName = "Amircpu.png",
                            Fname = "امیرمحمد",
                            Lname = "بیات",
                        },
                        Roles = new List<Enums.Role> { Enums.Role.Admin , Enums.Role.SupplyExpert }
                    };
                }
                else
                    return RedirectToAction(MVC.Home.ActionNames.Login);
            }

            return RedirectToAction(MVC.Home.ActionNames.Index);
        }
    }
}