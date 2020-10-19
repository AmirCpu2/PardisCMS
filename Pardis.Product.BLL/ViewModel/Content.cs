using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class Content
    {
        public Content()
        {

        }

        public virtual int Id { get; set; }
        
        public virtual int ContentType { get; set; }
        
        public virtual int CreatorId { get; set; }
        
        public virtual DateTime RegisterDate { get; set; }
        
        public virtual bool IsDelete { get; set; }

        public virtual string IsDeleteFa => IsDelete ? "ناموجود" : "موجود";

        public virtual bool IsArchive { get; set; }
        
        public virtual string IsArchiveFa => IsArchive ? "آرشیو شده" : "در جریان";

        public virtual string Files { get; set; }

        [AllowHtml]
        public virtual string Description { get; set; }
        
        public Enums.ContentStateKindGroup? StateKindeGroup { get; set; }
        
        public int? StateKindeGroupId { get; internal set; }

        public Enums.ContentStateKind? StateKinde { get; set; }

        public int? StateKindeId { get; set; }
    }

    public static partial class Mapper
    {
        public static MM.Content Map(Content entity)
        {
            if (entity == null)
                return null;

            var response = new MM.Content
            {
                Id = entity.Id,
                ContentType = entity.ContentType,
                CreatorId = entity.CreatorId,
                Description = entity.Description,
                IsArchive = entity.IsArchive,
                IsDelete = entity.IsDelete,
                RegisterDate = entity.RegisterDate,
                StateKinde = entity.StateKindeId,
                StateKindeGroup = entity.StateKindeGroupId
            };

            return response;

        }

        public static Content Map(MM.Content entity)
        {
            if (entity == null)
                return null;

            var response = new Content
            {
                Id = entity.Id,
                ContentType = entity?.ContentType ?? 0,
                CreatorId = entity.CreatorId ?? 0,
                Description = entity?.Description ?? "",
                IsArchive = entity.IsArchive ?? false,
                IsDelete = entity.IsDelete ?? false,
                RegisterDate = entity.RegisterDate,
                StateKindeId = entity?.StateKinde ?? 0,
                StateKinde = (Enums.ContentStateKind) (entity?.StateKinde ?? 0),
                StateKindeGroupId = entity?.StateKindeGroup ?? 0,
                StateKindeGroup = (Enums.ContentStateKindGroup) (entity?.StateKindeGroup ??0)
            };

            return response;

        }


    }
}
