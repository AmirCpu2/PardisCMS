using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class CallForPrice : Content
    {
        public override int Id { get; set; }
        
        [Display(Name ="پرونده تامین")]
        public int? SalesFolderId { get; set; }
        
        [Display(Name ="پرونده تامین")]
        public string SalesFolderFa { get; set; }

        [Display(Name = "کالا")]
        public int? ProductId { get; set; }
        [Display(Name = "کالا")]
        public string ProductFa { get; set; }
        
        [Display(Name = "نوع ارز")]
        public int? ShippingPriceTypeId { get; set; }
        [Display(Name = "نوع ارز")]
        public string ShippingPriceTypeFa { get; set; }

        [Display(Name = "هزینه حمل و نقل")]
        public string ShippingPrice { get; set; }

        [Display(Name = "تامین کننده")]
        public int? SupplierProfileId { get; set; }
        [Display(Name = "تامین کننده")]
        public string SupplierProfileFa { get; set; }

        [Display(Name = "تخمین زمان تحویل")]
        public DateTime? DeliveryTime { get; set; }
        public string DeliveryTimeFa { get; set; }
            
        [Display(Name = "تاریخ اعتبار قیمت")]
        public DateTime? ExpiryDate { get; set; }
        public string ExpiryDateFa { get; set; }

        [Display(Name = "نوع تامین")]
        public int? SupplyTypeId { get; set; }
        [Display(Name = "نوع تامین")]
        public string SupplyTypeFa { get; set; }

        [Display(Name = "قیمت هر واحد")]
        public string UnitPrice { get; set; }

        [Display(Name = "نوع ارز")]
        public int? PriceTypeId { get; set; }
        [Display(Name = "نوع ارز")]
        public string PriceTypeFa { get; set; }

        [Display(Name = "تعداد")]
        public int? Count { get; set; }

        [Display(Name = "وضعیت کالا")]
        public int? StatusProductId { get; set; }
        [Display(Name = "وضعیت کالا")]
        public string StatusProductFa { get; set; }

        [Display(Name = "توضیحات")]
        public override string Description { get; set; }
    }

    public class CallForPriceVM
    {
        public CallForPriceVM()
        {
            CallForPrice = new CallForPrice();
            CallForPrices = new List<CallForPrice>();
        }
        public List<CallForPrice>  CallForPrices { get; set; }
        public CallForPrice  CallForPrice { get; set; }
        public int SalesFolderId { get; set; }
    }

    public partial class Mapper
    {
        public static MM.CallForPrice Map(CallForPrice entity)
        {
            if (entity == null)
                return null;

            var response = new MM.CallForPrice
            {
                Id = entity.Id,
                DeliveryTime = entity.DeliveryTime,
                PriceTypeId = entity.PriceTypeId,
                SalesFolderId = entity.SalesFolderId,
                ExpiryDate = entity.ExpiryDate,
                ShippingPriceTypeId = entity.ShippingPriceTypeId,
                StatusProductId = entity.StatusProductId,
                ShippingPrice = entity.ShippingPrice,
                SupplyTypeId = entity.SupplyTypeId,
                SupplierProfileId = entity.SupplierProfileId,
                UnitPrice = entity.UnitPrice,
                ProductId = entity.ProductId,
                Count = entity.Count
            };

            return response;

        }
        public static CallForPrice Map(MM.CallForPrice entity)
        {
            if (entity == null)
                return null;

            var response = new CallForPrice
            {
                Id = entity.Id,
                
            };

            MapContentField(ref response, entity);

            return response;

        }
    }


}
