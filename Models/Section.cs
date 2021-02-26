using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Section
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public int SClassID { get; set; }
        public int TeacherID { get; set; }


        public virtual Teacher Teacher { get; set; }
        public virtual SClass SClass { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
