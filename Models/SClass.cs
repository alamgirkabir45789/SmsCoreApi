using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class SClass
    {
        public int SClassID { get; set; }
        public string ClassName { get; set; }


        public ICollection<Section> Sections { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; set; }

    }
}
