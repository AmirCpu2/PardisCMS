using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pardis.Product.BLL.ViewModel;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.Functions
{
    public class ItemBLL : BaseBLL<Item, MM.Item>
    {
        public static ItemBLL Instance { get; } = new ItemBLL();
        
        public IEnumerable<Item> FillItemsByTypeNameEn(string name)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(name))
                    return null;
                var itemTypeId = ItemTypeBLL.Instance.GetByListNameEn(name).Select(q => q.Id).ToList();

                return GetListByListTypeId(itemTypeId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private IEnumerable<Item> GetListByListTypeId(List<int> itemTypeId)
        {
            try
            {
                if (itemTypeId == null)
                    return null;

                var result = GetAll_asQuery(q => itemTypeId.Contains(q.ItemTypeId)).Select(Mapper.Map).OrderBy(q => q.NameFa);
                
                return result.DistinctBy(q => new { q.NameFa, q.ItemTypeId }).OrderBy(q => q.NameFa).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<Item> FillItemsByTypeId(int id)
        {
            try
            {
                if (id < 1)
                    return null;

               return GetAll_asQuery(q => q.ItemTypeId.Equals(id)).Select(Mapper.Map).DistinctBy(q => q.NameFa).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
