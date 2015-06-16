using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class PatientController : ApiController
    {
        private List<Patients> patients;

        public class Patients
        {
            public int Id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string HospitalName { get; set; }
            public string DoctorName { get; set; }
        }

        public PatientController()
        {
            patients = new List<Patients>()
            {
                new Patients() {Id = 1, Fname = "John", Lname = "Doe", HospitalName = "St.Mary", DoctorName = "Paul"},
                new Patients() {Id = 2, Fname = "John", Lname = "Doe 1", HospitalName = "St.Mary", DoctorName = "Paul"},
                new Patients() {Id = 3, Fname = "John", Lname = "Doe 2", HospitalName = "St.Mary", DoctorName = "Paul"},
                new Patients() {Id = 4, Fname = "John", Lname = "Doe 3", HospitalName = "St.Mary", DoctorName = "Paul"},
                new Patients() {Id = 5, Fname = "John", Lname = "Doe 4", HospitalName = "St.Mary", DoctorName = "Amy"},
                new Patients() {Id = 6, Fname = "John", Lname = "Doe 5", HospitalName = "St.Mary", DoctorName = "Amy"}
            };
        }
        public IEnumerable<Patients> Get()
        {
           return patients;            
        }

        public Patients Get(int id)
        {
            return patients.SingleOrDefault(_ => _.Id == id);
        }

        [Route(template: "api/patient/{doctorName}")]
        public List<Patients> Get(string doctorName)
        {
            return patients.Where(_ => _.DoctorName.ToLower().Equals(doctorName.ToLower())).ToList();
        }

        [Route(template:"api/patient/{doctorName}/{id}")]
        public List<Patients> Get(string doctorName, int id)
        {
            return patients.Where(_ =>            
                _.DoctorName.ToLower().Equals(doctorName.ToLower()) && _.Id == id
            ).ToList();
        }

    }
}
