using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pardis.Product.BLL.ViewModel;
using Pardis.Product.DAL.Repasitory;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.Functions
{
    public class ProductListRelatedBLL : BaseBLL<ProductListRelated, MM.ProductListRelated>
    {
        public static ProductListRelatedBLL Instance { get; } = new ProductListRelatedBLL();

        public virtual List<ProductListRelated> AddOrUpdateCustom(ProductListRelatedList entity)
        {

            try
            {
                
                if (entity.SaleFolderId == 0 || entity.VitualProductListRelated.Count == 0)
                {
                    return null;
                }

                //init value
                var result = new List<ProductListRelated>();

                //save ProductRelated
                foreach (var item in entity.VitualProductListRelated)
                {
                    item.SalesFolderId = entity.SaleFolderId;
                    result.Add(AddOrUpdate(item));
                }

                #region save Description and next step
                var folder = SalesFolderBLL.InstanceContent.GetOneById(entity.SaleFolderId);

                folder.DescriptionLom = entity.Description;
                folder.StateKindeId = (int)Enums.ContentStateKind.PriceAnnouncement;
                folder.ProcessStepId = (int)Enums.ProcessStep.PriceAnnouncement;

                SalesFolderBLL.InstanceContent.AddOrUpdate(folder);
                #endregion

                //Map And Return ViewModel
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }
}
