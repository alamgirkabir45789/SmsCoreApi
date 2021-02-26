using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public int EmployeeID { get; set; }
        public int SubjectID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
