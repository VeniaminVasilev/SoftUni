using System.ComponentModel.DataAnnotations;


namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
        public ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
    }
}
