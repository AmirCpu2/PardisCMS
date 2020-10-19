using Pardis.Product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.ViewModel
{
    public partial class Mapper
    {
        public static OutModel Map<InModel, OutModel>(InModel q, string MapperName) where InModel : class where OutModel : class
        {
            if (q == null)
                return null;

            MethodInfo methodInfo = typeof(Mapper).GetMethod(MapperName, new Type[] { q.GetType() });

            if (methodInfo == null)
                throw new Exception($"MapperError: mapper not defined for {q.GetType().Name}");

            if (methodInfo?.ReturnType.Name != typeof(OutModel).Name || methodInfo?.ReturnType.Namespace != typeof(OutModel).Namespace)
                throw new Exception($"MapperError: mapper output type not equal with OutModel type");

            var mapped = methodInfo.Invoke(null, new object[] { q }) as OutModel;

            return mapped;



        }

        public static OutModel Map<InModel, OutModel>(InModel q) where InModel : class where OutModel : class
        {
            return Map<InModel, OutModel>(q, "Map");
        }

        public static void MapContentField<Tv>(ref Tv vModel, IContent model) where Tv : Content
        {
            if (model?.Content == null)
                return;

            vModel.IsArchive = model.Content.IsArchive ?? false;
            vModel.IsDelete = model.Content.IsDelete ?? false;
            vModel.CreatorId = model.Content.CreatorId ?? 0;
            vModel.RegisterDate = model.Content.RegisterDate;
            vModel.StateKindeId = model.Content.StateKinde;
            vModel.StateKindeGroupId = model.Content.StateKindeGroup;
            vModel.StateKindeGroup = (Enums.ContentStateKindGroup)(model.Content?.StateKindeGroup ?? 0);
            vModel.StateKinde = (Enums.ContentStateKind)(model.Content?.StateKinde ?? 0);
        }

    }
}
