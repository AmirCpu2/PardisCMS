using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pardis.Product.BLL.ViewModel;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.Functions
{
    public class ItemTypeBLL : BaseBLL<ItemType,MM.ItemType>
    {
        public static ItemTypeBLL Instance { get; } = new ItemTypeBLL();

        public List<ItemType> GetByListNameEn(string name)
        {
            var result = GetAll_asQuery(q => name.Equals(q.NameEn));

            return result.AsEnumerable().Select(Mapper.Map).ToList();
        }
    }
}
