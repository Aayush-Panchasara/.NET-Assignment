using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Model
{
    internal class TrainingProgram
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }

        public int TrainerId { get; set; }

        public Trainer Trainer {  get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } 
    }
}
