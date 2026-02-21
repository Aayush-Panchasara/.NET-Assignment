using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Model
{
    internal class Trainer : Employee
    {
        public int ExpertiseLevel { get; set; }

        public ICollection<TrainingProgram> TrainingPrograms { get; set; }

    }
}
