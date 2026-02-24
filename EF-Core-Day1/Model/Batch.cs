using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Core_Day1.Model
{
    public class Batch
    {
        public int Id { get; set; }
        public DateOnly StartDate {  get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        
        public virtual Course Course { get; set; }

        public virtual Trainer Trainer { get; set; }


    }
}
