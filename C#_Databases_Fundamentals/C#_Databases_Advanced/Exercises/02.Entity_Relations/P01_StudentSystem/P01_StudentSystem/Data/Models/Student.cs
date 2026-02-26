using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10), Column(TypeName = "char(10)")]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}
