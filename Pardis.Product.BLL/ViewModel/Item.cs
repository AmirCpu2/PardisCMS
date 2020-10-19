using Pardis.Product.BLL.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class Item
    {

        public Item()
        {
            ItemType = new ItemType();
        }

        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameFa { get; set; }

        public int ItemTypeId { get; set; }

        public virtual ItemType ItemType { get; set; }
    }

    public partial class Mapper
    {
        public static MM.Item Map(Item entity)
        {
            if (entity == null)
                return null;

            var response = new MM.Item
            {
                Id = entity.Id,
                ItemTypeId = entity.ItemTypeId,
                NameEn = entity.NameEn,
                NameFa = entity.NameFa
            };

            return response;

        }

        public static Item Map(MM.Item entity)
        {
            if (entity == null)
                return null;

            var response = new Item
            {
                Id = entity.Id,
                ItemType = BaseBLL<ItemType, MM.ItemType>.InstanceGeneric.GetOne(q => q.Id == entity.ItemTypeId),
                ItemTypeId = entity.ItemTypeId,
                NameEn = entity.NameEn,
                NameFa = entity.NameFa
            };

            return response;

        }
    }
}
