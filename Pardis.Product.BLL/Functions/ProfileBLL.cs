using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pardis.Product.BLL.ViewModel;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.Functions
{
    public class ProfileBLL : BaseBLL<Profile,MM.Profile>
    {
        public static ProfileBLL Instance { get; } = new ProfileBLL();

        public IEnumerable<Profile> FillProfileCustommers()
        {
            var result = GetAll_asQuery(q => q.isProvider == 1);

            return result.AsEnumerable().Select(Mapper.Map).ToList();
        }

    }
}
