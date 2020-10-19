using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class ItemType
    {

        public ItemType()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameFa { get; set; }

        public bool? FlagCustom { get; set; }

        public virtual List<Item> Items { get; set; }

    }

    public partial class Mapper
    {
        public static MM.ItemType Map(ItemType entity)
        {
            if (entity == null)
                return null;

            var response = new MM.ItemType
            {
                Id = entity.Id,
                FlagCustom = entity.FlagCustom,
                NameEn = entity.NameEn,
                NameFa = entity.NameFa
            };

            return response;

        }

        public static ItemType Map(MM.ItemType entity)
        {
            if (entity == null)
                return null;

            var response = new ItemType
            {
                Id = entity.Id,
                FlagCustom = entity.FlagCustom,
                NameEn = entity.NameEn,
                NameFa = entity.NameFa
            };

            return response;

        }

        public static ItemType MapFull(MM.ItemType entity)
        {
            if (entity == null)
                return null;

            var response = new ItemType
            {
                Id = entity.Id,
                FlagCustom = entity.FlagCustom,
                NameEn = entity.NameEn,
                NameFa = entity.NameFa,
                Items = entity.Items.Select(q => Mapper.Map(q)).ToList()
            };

            return response;

        }
    }
}
