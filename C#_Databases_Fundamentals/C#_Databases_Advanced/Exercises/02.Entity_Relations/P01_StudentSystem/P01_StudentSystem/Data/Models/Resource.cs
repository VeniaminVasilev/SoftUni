using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
