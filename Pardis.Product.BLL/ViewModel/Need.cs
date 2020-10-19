using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class Need : Content
    {
        public Need()
        {
            Profile = new Profile();
            
        }

        public override int Id { get; set; }
        
        public string title { get; set; }
        
        public bool? factorneed { get; set; }
        
        public DateTime? factordate { get; set; }
        
        public string factorip { get; set; }
        
        public string factorby { get; set; }
        
        public int profileid { get; set; }
        
        public int? catid { get; set; }
        
        public string subcatid { get; set; }
        
        public int? sectorid { get; set; }
        
        public string description { get; set; }
        
        public string status { get; set; }
        
        public string confirmby { get; set; }
        
        public string confirmip { get; set; }
        
        public DateTime? confirmdate { get; set; }
        
        public int? progress { get; set; }
        
        public bool? iscampaign { get; set; }
        
        public int? nexttime { get; set; }
        
        public int? nextdates { get; set; }
        
        public string laststatusdesc { get; set; }
        
        public DateTime? laststatusdescdates { get; set; }
        
        public string laststatusdescby { get; set; }
        
        public DateTime? toclnd { get; set; }
        
        public double? price { get; set; }
        
        public int? csproviderid { get; set; }
        
        public string editedby { get; set; }
        
        public string editedip { get; set; }
        
        public DateTime? editeddate { get; set; }
        
        public int? userid { get; set; }
        
        public string assignby { get; set; }
        
        public DateTime? assigndate { get; set; }

        public int? departmentid { get; set; }

        public virtual Profile Profile { get; set; }


        //Just For DropDownLost
        public string NameFa { get; set; }
    }

    public partial class Mapper
    {
        public static Need MiniMap(MM.Need entity)
        {
            var result = new Need
            {
                Id = entity.Id,
                NameFa = entity.title
            };

            return result;
        }

        public static Need Map(MM.Need entity)
        {
            var result = new Need
            {
                Id = entity.Id,
                title = entity.title,
                profileid = entity.profileid
            };

            return result;
        }

        public static MM.Need Map(Need entity)
        {
            var result = new MM.Need
            {
                Id = entity.Id,
                title = entity.title,
                profileid = entity.profileid
            };

            return result;
        }
    }

}
