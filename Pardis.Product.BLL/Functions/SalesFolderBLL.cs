using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;
using VM = Pardis.Product.BLL.ViewModel;

namespace Pardis.Product.BLL.Functions
{
    public class SalesFolderBLL : ContentBLL<VM.SalesFolder, MM.SalesFolder>
    {

        public static SalesFolderBLL Instance { get; } = new SalesFolderBLL();

        public virtual List<VM.SalesFolder> GetAllSalesFolderByProductId(int id)
        {
            var entity = new List<VM.SalesFolder>();
            try
            {
                if (id == 0)
                    return null;

                var folders = ProductListRelatedBLL.Instance.GetAll_asQuery(q => q.ProductId == id).Select(q=>q.SalesFolderId);

                entity.AddRange(GetAll_asQuery(q => folders.Contains(q.Id)).Select(VM.Mapper.MiniMap));

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return entity;
            }
        }

        public virtual List<VM.SalesFolder> GetAllSalesFolder()
        {
            var entity = new List<VM.SalesFolder>();
            try
            {
                var folders = ProductListRelatedBLL.Instance.GetAll_asQuery().Select(q => q.SalesFolderId);

                entity.AddRange(GetAll_asQuery(q => folders.Contains(q.Id)).Select(VM.Mapper.MiniMap));

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return entity;
            }
        }
    }
}
