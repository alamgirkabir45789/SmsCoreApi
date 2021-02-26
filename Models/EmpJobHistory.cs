using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class EmpJobHistory
    {
        public int EmpJobHistoryID { get; set; }
        public int EmployeeID { get; set; }
        public int DesignationID { get; set; }
        public int BranchID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
