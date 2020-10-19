using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{

    public class ProductListRelatedList
    {
        public ProductListRelatedList()
        {
            VitualProductListRelated = new List<ProductListRelated>();
            ProductListRelated = new ProductListRelated();
        }

        public int SaleFolderId { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public ProductListRelated ProductListRelated { get; set; }

        [Display(Name = "لیست LOM")]
        public List<ProductListRelated> VitualProductListRelated { get; set; }

    }

    public class ProductListRelated
    {
        [Display(Name = "شناسه یکتا محصول")]
        public int ProductId { get; set; }
        
        [Display(Name = "نام محصول محصول")]
        public string ProductFa { get; set; }
        
        [Display(Name = "شناسه یکتا درخواست")]
        public int SalesFolderId { get; set; }

        [Display(Name = "موضوع درخواست")]
        public string SalesFolderFa { get; set; }

        [Display(Name = "واحد اندازه گیری")]
        public int? MeasurementUnitId { get; set; }

        [Display(Name = "واحد اندازه گیری")]
        public string MeasurementUnitFa { get; set; }

        public int ContentId { get; set; }

        public Content Content { get; set; }

        [Display(Name = "مقدار")]
        public int? Amount { get; set; }

    }

    public partial class Mapper
    {
        public static MM.ProductListRelated Map(ProductListRelated entity)
        {
            if (entity == null)
                return null;

            var response = new MM.ProductListRelated
            {
                ProductId = entity.ProductId,
                SalesFolderId = entity.SalesFolderId,
                MeasurementUnitId  = entity.MeasurementUnitId,
                Amount = entity.Amount
            };

            return response;

        }

        public static ProductListRelated Map(MM.ProductListRelated entity)
        {
            if (entity == null)
                return null;

            int measurementUnitId = entity?.MeasurementUnitId ?? 0;

            var response = new ProductListRelated
            {
                ProductId = entity.ProductId,
                SalesFolderId = entity.SalesFolderId,
                MeasurementUnitId = entity.MeasurementUnitId,
                Amount = entity.Amount,
                MeasurementUnitFa = measurementUnitId != 0 ? BaseBLL<Item, MM.Item>.InstanceGeneric.GetOne(q => q.Id == entity.MeasurementUnitId).NameFa : "",
            };

            return response;

        }
    }
}
