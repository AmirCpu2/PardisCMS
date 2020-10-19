using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.Functions
{
    public class BaseBLL<TVModel, TMModel> : GenericBLL<TVModel, TMModel> where TMModel : class where TVModel : class, new()
    {
        protected static BaseBLL<TVModel, TMModel> InstanceBase { get; } = new BaseBLL<TVModel, TMModel>();
    }
}
