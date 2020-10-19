using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.Product.BLL.Functions
{
    public partial class ContentBLL<TVModel, TMModel> : GenericBLL<TVModel, TMModel> where TMModel : class, MM.IContent where TVModel : VM.Content, new()
    {
        protected Enums.ContentType TvModelContentType => ConvertTvModelContentType<TVModel>();
        public static Enums.ContentType ConvertTvModelContentType<T>() where T : class
        {
            Enums.ContentType contentType;
            if (!Enum.TryParse(typeof(T)?.Name, out contentType))
                throw new NotImplementedException("Error: Content type not defined in Enums.ContentType");
            return contentType;
        }
    }
}
