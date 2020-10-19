using Pardis.Product.BLL.Functions;
using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MM = Pardis.Product.DAL.Models;
using Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class SalesFolder : Content
    {
        public override int Id { get; set; }

        [Display(Name = "نیاز سنجی")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public int? NeedId { get; set; }

        [Display(Name = "نیاز سنجی")]
        public string NeedFa { get; set; }

        [Display(Name = "عنوان درخواست")]
        public string Subject { get; set; }

        [Display(Name = "مهلت اعلام قیمت")]
        public DateTime? PriceAnnouncementDeadline { get; set; }

        [Display(Name = "مهلت اعلام قیمت")]
        public string PriceAnnouncementDeadlineFa { get; set; }
        
        [Display(Name = "مهلت تحویل")]
        public DateTime? DeliveryDeadline { get; set; }

        [Display(Name = "مهلت تحویل")]
        public string DeliveryDeadlineFa { get; set; }

        [Display(Name = "نوع درخواست")]
        [Required(ErrorMessage = "نوع درخواست را انتخاب نمایید")]
        public int? RequestTypeId { get; set; }

        [Display(Name = "نوع درخواست")]
        public string RequestTypeFa { get; set; }

        [Display(Name = "شرایط گارانتی")]
        [AllowHtml]
        public string WarrantyTerms { get; set; }

        [Display(Name = "توضیحات")]
        [AllowHtml]
        public override string Description { get; set; }
        
        [Display(Name = "توضیحات")]
        [AllowHtml]
        public string DescriptionLom { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public override DateTime RegisterDate { get; set; }

        [Display(Name = "وضعیت پرونده")]/*به دیتا بیس اضافه شود*/
        public int? ProcessStepId { get; set; }

        [Display(Name = "ثبت کننده")]
        public override int CreatorId { get; set; }

        [Display(Name = "وضعیت پرونده")]
        public string ProcessStepFa { get; set; }
        
        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "یک مشتری را انتخاب نمایید")]
        public int? ProfileId { get; set; }

        [Display(Name = "مشتری")]
        public string ProfileFa { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string RegisterDateFa => PublicFunction.Functions.DateTimeToStringPersian(RegisterDate);

        //JustFor DropDownList
        public string NameFa { get; set; }
    }
    public partial class Mapper
    {
        public static MM.SalesFolder Map(SalesFolder entity)
        {
            if (entity == null)
                return null;

            var response = new MM.SalesFolder
            {
                Id = entity.Id,
                DeliveryDeadline = entity.DeliveryDeadline,
                PriceAnnouncementDeadline = entity.PriceAnnouncementDeadline,
                Description = entity.Description,
                DescriptionLom = entity.DescriptionLom,
                WarrantyTerms = entity.WarrantyTerms,
                RequestTypeId = entity.RequestTypeId,
                NeedId = entity.NeedId,
                Subject = entity.Subject,
                ProfileId = entity.ProfileId,
                ProcessStepId = entity.ProcessStepId
            };

            return response;

        }
        public static SalesFolder Map(MM.SalesFolder entity)
        {
            if (entity == null)
                return null;

            int itemRequestId = (entity?.RequestTypeId ?? 0);
            int needId = (entity?.NeedId ?? 0);
            int profileId = (entity?.ProfileId ?? 0);

            var response = new SalesFolder
            {
                Id = entity.Id,
                DeliveryDeadline = entity.DeliveryDeadline,
                DeliveryDeadlineFa = PublicFunction.Functions.DateTimeToStringPersian(entity.DeliveryDeadline),
                PriceAnnouncementDeadline = entity.PriceAnnouncementDeadline,
                PriceAnnouncementDeadlineFa = PublicFunction.Functions.DateTimeToStringPersian(entity.PriceAnnouncementDeadline),
                //CreatorId = entity.Id == 0 ? SSO.CurrentAccount.Id : BaseBLL<Content, MM.Content>.InstanceGeneric.GetOne(q => q.Id == entity.Id).CreatorId,
                Description = entity.Description,
                DescriptionLom = entity.DescriptionLom,
                WarrantyTerms = entity.WarrantyTerms,
                RequestTypeId = entity.RequestTypeId,
                RequestTypeFa = itemRequestId != 0 ? ItemBLL.Instance.GetOne(q => q.Id == itemRequestId).NameFa : "",
                NeedId = entity.NeedId, 
                NeedFa = needId != 0 ? NeedBLL.Instance.GetOneById(needId).title : "",
                Subject = entity.Subject,
                ProfileId = entity.ProfileId,
                ProfileFa = profileId != 0 ? BaseBLL<Profile,MM.Profile>.InstanceGeneric.GetOne(q=>q.Id == entity.ProfileId).NameFa : "",
                ProcessStepId = entity.ProcessStepId,
                ProcessStepFa = ((Enums.ProcessStep) (entity?.ProcessStepId ?? 1)).ToPersianName()
            };

            MapContentField(ref response, entity);

            return response;

        }

        public static SalesFolder MiniMap(MM.SalesFolder entity)
        {
            var result = new SalesFolder
            {
                Id = entity.Id,
                NameFa = entity.Subject.Length > 0 ? entity.Subject :( entity.NeedId != 0 ? NeedBLL.Instance.GetOneById(entity.NeedId).title : "")
            };

            return result;
        }
    }
}
