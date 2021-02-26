using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }

        public int CityID { get; set; }
        public virtual City City { get; set; }

        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<EmpJobHistory> EmpJobHistories { get; set; }



    }
}
