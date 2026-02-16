using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Model
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly CreatedDate { get; set; }



    }
}
