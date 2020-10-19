using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM = Pardis.Product.DAL.Models;

namespace Pardis.Product.BLL.ViewModel
{
    public class Profile
    {
        public Profile()
        {
        }

        public int Id { get; set; }
        public Nullable<int> isperson { get; set; }
        public Nullable<int> birthdate { get; set; }
        public string birthplace { get; set; }
        public Nullable<System.DateTime> registerdate { get; set; }
        public string fathername { get; set; }
        public string NameFa { get; set; }
        public string uniquename { get; set; }
        public string repname { get; set; }
        public string password { get; set; }
        public string code { get; set; }
        public string manager { get; set; }
        public string idnumber { get; set; }
        public string place { get; set; }
        public Nullable<int> edulevel { get; set; }
        public string edufield { get; set; }
        public string job { get; set; }
        public string country { get; set; }
        public string postalcode { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string comment { get; set; }
        public Nullable<int> howyouknowid { get; set; }
        public Nullable<int> usergroup { get; set; }
        public Nullable<int> isProvider { get; set; }
        public Nullable<bool> acccotactconfirm { get; set; }
        public Nullable<bool> iscampaign { get; set; }
    }

    public partial class Mapper
    {
        public static MM.Profile Map(Profile entity)
        {
            if (entity == null)
                return null;

            var response = new MM.Profile
            {
                Id = entity.Id,
                name = entity.NameFa
            };

            return response;

        }
        public static Profile Map(MM.Profile entity)
        {
            if (entity == null)
                return null;

            var response = new Profile
            {
                Id = entity.Id,
                NameFa = entity.name
            };

            return response;

        }
    }
}
