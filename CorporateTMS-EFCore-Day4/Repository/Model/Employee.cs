using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Model
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
