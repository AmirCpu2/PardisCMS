using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.ViewModel
{
    public class CardBoard
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime RegisterDate { get; set; }

        public string RegisterDateFa => RegisterDate != null ? Pardis.PublicFunction.Functions.DateTimeToStringPersian(this.RegisterDate) : string.Empty;
    }
}
