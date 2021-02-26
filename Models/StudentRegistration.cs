using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Models
{
    public class StudentRegistration
    {
        public int StudentRegistrationID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int CityID { get; set; }

        public int CountryID { get; set; }
        public string BirthCertificate { get; set; }
        public string GurdianPhone { get; set; }
        public string StudentImage { get; set; }



        public ICollection<Student> Students { get; set; }

        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
    }
}
