using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class Product : Content
    {
        public override int Id { get; set; }

        public string Title { get; set; }

        public string NameFa { get; set; }

        public int? CategoryId { get; set; }
        
        public string CategoryFa { get; set; }

        public int? BrandId { get; set; }

        public string BrandFa { get; set; }

        public override string Description { get; set; }
    }

    public partial class Mapper
    {
        public static MM.Product Map(Product entity)
        {
            if (entity == null)
                return null;

            var response = new MM.Product
            {
                Id = entity.Id,
                Title = entity.Title,
                BrandId = entity.BrandId,
                CategoryId = entity.CategoryId,
                Description = entity.Description
            };

            return response;

        }
        public static Product Map(MM.Product entity)
        {
            if (entity == null)
                return null;

            var response = new Product
            {
                Id = entity.Id,
                Title = entity.Title,
                BrandId = entity.BrandId,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                BrandFa = entity.BrandId != null && entity.BrandId != 0 ? BaseBLL<Item, MM.Item>.InstanceGeneric.GetOne(q=>q.Id == entity.BrandId).NameFa : "",
                CategoryFa = entity.BrandId != null && entity.CategoryId != 0 ? BaseBLL<Item, MM.Item>.InstanceGeneric.GetOne(q => q.Id == entity.CategoryId).NameFa : ""
            };

            return response;

        }

        public static Product MapMini(MM.Product entity)
        {
            if (entity == null)
                return null;

            var response = new Product
            {
                Id = entity.Id,
                NameFa = entity.Title
            };

            return response;

        }
    }
}
