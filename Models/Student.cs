using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int StudentRegistrationID { get; set; }
        public int SessionID { get; set; }
        public int SClassID { get; set; }
        public int SectionID { get; set; }
        public int PaymentID { get; set; }
        public string Roll { get; set; }
        public virtual StudentRegistration StudentRegistration { get; set; }
        public virtual Session Session { get; set; }
        public virtual SClass SClass { get; set; }
        public virtual Section Section { get; set; }
        public virtual Payment Payment { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
