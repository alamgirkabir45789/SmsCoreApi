using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
