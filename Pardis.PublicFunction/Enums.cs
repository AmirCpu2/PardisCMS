using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis
{
    public class Enums
    {
        public enum AccountPermisionInheritedType 
        {
            EveryOne,
            Logined,
            Inherited
        }

        public enum CustomProperty
        {
            name,
            description,
            persianName,
        }

        public enum Role
        {
            [CustomProperty(PersianName = "مدیر سیستم")]
            Admin = 1,
            [CustomProperty(PersianName = "مدير فروش")]
            SalesManager = 2,
            [CustomProperty(PersianName = "مدير تامين")]
            SupplyManager = 3,
            [CustomProperty(PersianName = "كارشناس فروش")]
            SalesExpert = 4,
            [CustomProperty(PersianName = "كارشناس تامين")]
            SupplyExpert = 5
        }

        public enum SubSystemType
        {
            ///<summary>مدیریت فروش</summary>
            SubSetSalesManagement = 1,
            ///<summary>کالا</summary>
            SubSetProduct = 2,
        }

        public enum ContentType
        {
            [CustomProperty(PersianName = "پیش فرض")]
            None = 0,
            [CustomProperty(PersianName = "مندرج")]
            Content = 0,
            [CustomProperty(PersianName = "نیازمندی")]
            Need = 1,
            [CustomProperty(PersianName = "پرونده خرید")]
            SalesFolder = 2,
            [CustomProperty(PersianName = "محصول")]
            Product = 3,
            [CustomProperty(PersianName = "لیست محصولات مندرج")]
            ProductListRelated = 4,
            [CustomProperty(PersianName = "استعلام قیمت")]
            CallForPrice = 5
        }

        public enum ContentStateKindGroup
        {
            [CustomProperty(PersianName = "پیش فرض")]
            None = 0,
            [CustomProperty(PersianName = "پرونده خرید")]
            SalesFolder = 1,
        }

        public enum ContentStateKind
        {
            [CustomProperty(PersianName = "پیش فرض")]
            None = 0,
            /************** Begin SalesFolder (1-20) Reserved ***************/
            [CustomProperty(PersianName = "مرحله سفارش")]
            Sales = 1,
            [CustomProperty(PersianName = "ثبت درخواست")]
            Adding = 2,
            [CustomProperty(PersianName = "بررسی LOM")]
            ScrutinyLOM = 3,
            [CustomProperty(PersianName = "استعلام قیمت")]
            PriceAnnouncement = 4,
            [CustomProperty(PersianName = "تایید استعلام قیمت")]
            AcceptPriceAnnouncement = 5,
            /************** End SalesFolder ***************/
        }

        public enum DraftMode
        {
            ///<summary>اصلی</summary>
            [CustomProperty(PersianName = "اصلی")]
            None = 0,

            ///<summary>پیش نویس"</summary>
            [CustomProperty(PersianName = "پیش نویس")]
            Draft = 1,

            ///<summary>ذخیره موقت</summary>
            [CustomProperty(PersianName = "ذخیره موقت")]
            Freeze = 2,
        }

        public enum ProcessStep
        {
            [CustomProperty(PersianName = "ثبت درخواست")]
            Adding = 1,
            [CustomProperty(PersianName = "بررسی LOM")]
            ScrutinyLOM = 2,
            [CustomProperty(PersianName = "استعلام قیمت")]
            PriceAnnouncement = 3,
            [CustomProperty(PersianName = "تایید استعلام قیمت")]
            AcceptPriceAnnouncement = 4,
        }

        public enum WorkFlowStatus
        {
            done = 0,
            undone = 1,
            disable = 2,
            current = 3,
            losed = 4
        }

    }
}
