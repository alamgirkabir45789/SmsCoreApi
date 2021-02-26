using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
