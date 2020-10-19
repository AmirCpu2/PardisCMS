using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;
using Pardis.Product.BLL.ViewModel;

namespace Pardis.Product.BLL.Functions
{
    public class NeedBLL : ContentBLL<Need,MM.Need>
    {
        public static NeedBLL Instance { get; } = new NeedBLL();

        public virtual List<Need> GetAllNeedsByProfileId(int id)
        {
            var entity = new List<Need>();
            try
            {
                if (id == 0)
                    return null;

                entity.AddRange( GetAll_asQuery(q => q.profileid.Equals(id)).Select(Mapper.MiniMap) );

                return entity;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);

                return entity;
            }
        }

    }
}
