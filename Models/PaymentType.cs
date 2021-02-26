using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class PaymentType
    {
        public int PaymentTypeID { get; set; }
        public string TypeName { get; set; }
        public int Amount { get; set; }
        public int SClassID { get; set; }
        public int SessionID { get; set; }

        public virtual Session Session { get; set; }

        public virtual SClass SClass { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
