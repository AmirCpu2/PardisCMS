using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.ViewModel
{

    interface IJqgridModel
    {

    }

    public class Jqgrid : IJqgridModel
    {
        public Jqgrid()
        {
            ShowDelete = ShowDeleted.HiddenDeleted;
            ShowArchive = ShowArchive.HiddenArchive;
            ContainIdList = new List<long>();
            ModelType = JqGridModelType.NotDefind;
        }
        public string sidx { get; set; }
        public string sord { get; set; }
        public int? page { get; set; }
        public int? rows { get; set; }
        public bool _search { get; set; }
        public string searchField { get; set; }
        public string searchString { get; set; }
        public string searchOper { get; set; }
        public string filters { get; set; }
        public NameValueCollection form { get; set; }
        public int? MasterContentId { get; set; }
        public ShowDeleted ShowDelete { get; set; }
        public ShowArchive ShowArchive { get; set; }
        public string CustomSearch { get; set; }
        public JqGridModelType ModelType { get; set; }
        public List<long> ContainIdList { get; set; }
        public List<long> PersonId { get; set; }
        public int CurrentRowId { get; set; }
        public object InitialToDoListResults { get; set; }
    }

    public class JqgridModel<TMModel> : Jqgrid where TMModel : class, Pardis.Product.DAL.Models.IContent
    {
        public List<Expression<Func<TMModel, object>>> IncludeList { get; set; }
        public Expression<Func<TMModel, object>> OrderBy { get; set; }

    }
    public enum JqGridModelType
    {
        //تعریف نشده
        NotDefind = 0,
        //مستقل
        Independent = 1,
        //وابسته
        Dependent = 2
    }

    public enum ShowArchive
    {
        HiddenArchive = 0,
        JustArchive = 1,
        ShowAll = 2
    }
    public enum ShowDeleted
    {
        HiddenDeleted = 0,
        JustDeleted = 1,
        ShowAll = 2
    }
}
