using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Model
{
    internal class Enrollment
    {
        public int EmployeeId { get; set; }
        public int TrainerProgramId { get; set; }

        public DateTime EnrollDate { get; set; }

        public int PerformanceScore { get; set; }
        public Employee Employee { get; set; }
        public TrainingProgram TrainerProgram { get; set; }
    }
}
