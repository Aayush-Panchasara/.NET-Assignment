using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Core_Day1.Model
{
    internal class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public DateOnly CreatedDate { get; set; }

        public List<Course> Courses { get; set; } = new();

    }
}
