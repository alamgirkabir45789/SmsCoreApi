using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Designation
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }


        public ICollection<Employee> Employees { get; set; }
        public ICollection<EmpJobHistory> EmpJobHistories { get; set; }

    }
}
