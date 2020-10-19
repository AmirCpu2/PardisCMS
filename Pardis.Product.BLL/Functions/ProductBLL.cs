using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.Product.BLL.Functions
{
    public class ProductBLL : ContentBLL<VM.Product,MM.Product>
    {
        public static ProductBLL Instance { get; } = new ProductBLL();

        /// <summary>
        /// Fill Product Search By title
        /// </summary>
        /// <param name="title">string</param>
        /// <returns>Take 10 Products contains by title</returns>
        public IEnumerable<VM.Product> FillProductSearching(string title)
        {
            IQueryable<MM.Product> result;

            if (title.Length > 0)
                result = GetAll_asQuery(q => q.Title.Contains(title)).Take(10);
            else
                result = GetAll_asQuery().Take(10);

            return result.AsEnumerable().Select(VM.Mapper.MapMini).ToList();
        }
        
        /// <summary>
        /// Fill Product Search By title
        /// </summary>
        /// <param name="id">FolderId</param>
        /// <returns>all Product Related by folderId</returns>
        public IEnumerable<VM.Product> FillProductByFolderId(int id)
        {
            IQueryable<MM.Product> result;

            //Get folder Product
            var productListId = ProductListRelatedBLL.Instance.GetAll_asQuery(q => q.SalesFolderId == id).Select(q=>q.ProductId);

            if (productListId.Count() == 0)
                return null;

            result = GetAll_asQuery(q => productListId.Contains(q.Id));

            return result.AsEnumerable().Select(VM.Mapper.MapMini).ToList();
        }


    }
}
