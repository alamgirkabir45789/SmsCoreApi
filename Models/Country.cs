using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
