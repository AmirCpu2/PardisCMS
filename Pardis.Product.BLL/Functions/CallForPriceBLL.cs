using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pardis.Product.BLL.ViewModel;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.Functions
{
    public class CallForPriceBLL : ContentBLL<CallForPrice, MM.CallForPrice>
    {
        public static CallForPriceBLL Instance { get; } = new CallForPriceBLL();


    }
}
