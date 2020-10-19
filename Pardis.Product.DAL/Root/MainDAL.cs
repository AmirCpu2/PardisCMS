using Pardis.Product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pardis.Product.DAL
{
    public class MainDAL
    {
        private PardisDemoEntities _db;

        public PardisDemoEntities DB
        {
            get
            {
                //Web application
                var context = HttpContext.Current.Items["ObjectContextDBFirst"];
                if (context == null)
                {
                    context = new PardisDemoEntities();
                    HttpContext.Current.Items.Add("ObjectContextDBFirst", context);
                }

                return context as PardisDemoEntities;
            }
        }
    }
}
