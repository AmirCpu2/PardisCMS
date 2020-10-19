using Pardis.Product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.DAL.Models
{
    public interface IContent
    {
        int Id { get; set; }
        Content Content { get; set; }
    }
    public partial class Product : IContent { }
    public partial class Need : IContent { }
    public partial class SalesFolder : IContent { }
    public partial class CallForPrice : IContent { }
}
