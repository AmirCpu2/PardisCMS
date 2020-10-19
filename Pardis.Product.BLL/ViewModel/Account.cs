using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using MM = 

namespace Pardis.Product.BLL.ViewModel
{
    #region ViewModels
    public class AccountLogin
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "نام کاربری خود را وارد کنید")]
        public string UserName { get; set; }

        /// <summary>
        /// PassWord
        /// </summary>
        [Required(ErrorMessage = "رمز عبور خود را وارد کنید")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class Account
    {

        public Account() 
        {
            Profile = new Profile();
            Person = new Person();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="طول نام کاربری باید کمتر از 100 کارکتر باشد")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول رمزعبور باید کمتر از 100 کارکتر باشد")]
        public string Password { get; set; }

        public DateTime? RegisterDate { get; set; }

        public bool Active { get; set; }

        public int? FialedRepeat { get; set; }

        public DateTime? LastFialed { get; set; }

        public int? LoginCount { get; set; }

        public DateTime? LastLogin { get; set; }

        public long PersonID { get; set; }

        public DateTime? LastPasswordChanges { get; set; }

        public short InheritTypeID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Profile Profile { get; set; }

        public List<Enums.Role> Roles { set; get; }
    }


    #endregion

    #region Engine SSO DEMO
    public static class SSO
    {
        public static Account CurrentAccount
        {
            get
            {

                if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session != null)
                {
                    if (System.Web.HttpContext.Current.Session["CurrentAccount"] != null)
                    {
                        return (Account)System.Web.HttpContext.Current.Session["CurrentAccount"];
                    }
                }

                return null;
            }
            set
            {
                System.Web.HttpContext.Current.Session["CurrentAccount"] = value;

                System.Web.HttpContext.Current.Session["CurrentAccountForVM"] = new VMAccount { 
                    ID = CurrentAccount?.Id??0,
                    PersonFullName = CurrentAccount?.Person?.FullName??"",
                    UseName = CurrentAccount?.UserName??"",
                    PersonID = CurrentAccount?.PersonID??0
                };

            }
        }

        public static void SignOut()
        {
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.RemoveAll();
        }

        public class VMAccount
        {
            public int ID { get; set; }
            public string PersonFullName { get; set; }
            public string UseName { get; set; }
            public long PersonID { get; set; }
        }
    }
    #endregion
}
