using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.ViewModel
{
    public class WorkFlow
    {
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameFa { get; set; }

        public int CurentStepId { get; set; }

        public virtual List<WorkFlowStep> Steps { get; set; }
    }

    public class WorkFlowStep
    {
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameFa { get; set; }

        public int StatusId { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Area { get; set; }

        public Enums.WorkFlowStatus Status { get; set; }
    }
}
