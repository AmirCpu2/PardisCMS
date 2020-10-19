using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VM = Pardis.Product.BLL.ViewModel;
using MM = Pardis.Product.DAL.Models;
using Pardis.Product.BLL.Functions;
using System.Web.Mvc;

namespace Pardis.WebApp
{
    //the variables
    public class PublicController<TvModel, TmModel> : CustomController where TvModel : VM.Content, new() where TmModel : class, MM.IContent
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(TvModel entity)
        {
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Archive(TvModel entity)
        {
            return null;
        }

        public virtual ActionResult Index(int? id)
        {
            return null;
        }

        [HttpPost]
        public virtual ActionResult Details(int? id)
        {
            return null;
        }

        [HttpPost]
        public virtual JsonResult ShowGrid(string model)
        {
            return null;
        }

        public virtual ActionResult AddOrUpdate(int? id)
        {
            return null;
        }

    }
}