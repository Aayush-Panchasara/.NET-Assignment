using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Model
{
    internal class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Location  { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
