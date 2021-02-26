using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public string SessionYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public ICollection<PaymentType> PaymentTypes { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
