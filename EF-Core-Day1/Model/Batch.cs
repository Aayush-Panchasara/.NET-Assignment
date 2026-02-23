using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Core_Day1.Model
{
    internal class Batch
    {
        public int Id { get; set; }
        public DateOnly StartDate {  get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        
        public Course Course { get; set; }

        public Trainer Trainer { get; set; }


    }
}
