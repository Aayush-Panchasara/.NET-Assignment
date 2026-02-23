using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Model
{
    internal class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ExperienceInYear {  get; set; }

        public List<Batch> Batches { get; set; } = new();
    }
}
