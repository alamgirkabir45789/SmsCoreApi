using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int StudentRegistrationID { get; set; }
        public int PaymentTypeID { get; set; }
        public int Total { get; set; }
        public int Paid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Due { get { return (Total - Paid); } }

        public DateTime PaymentDate { get; set; }

        public virtual StudentRegistration StudentRegistration { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
