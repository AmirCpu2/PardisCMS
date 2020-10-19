using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.PublicFunction
{
    public class ExpressionBuilder
    {

    }
}

//Public Tools
namespace Pardis
{
    [AttributeUsage(AttributeTargets.All)]
    public class CustomPropertyAttribute : Attribute
    {
        public Enums.Role Roles { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PersianName { get; set; }
    }

}
