using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int? GroupID { get; set; } = 0;

        public virtual Group Group { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
