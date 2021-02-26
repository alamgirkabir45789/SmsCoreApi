using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public DateTime AttendDate { get; set; }
        public bool Status { get; set; }
        public int StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}
