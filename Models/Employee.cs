using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

        public int CityID { get; set; }
        public virtual City City { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        public decimal Salary { get; set; }
        public string EmployeeImage { get; set; }
        public string NID { get; set; }
        public string Qualification { get; set; }

        public int DesignationID { get; set; }
        public int BranchID { get; set; }


        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }


        public virtual Designation Designation { get; set; }
        public virtual Branch Branch { get; set; }

        public ICollection<EmpJobHistory> EmpJobHistories { get; set; }
    }
}
