using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Model
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public int DurationInMonths { get; set; }

    }
}
