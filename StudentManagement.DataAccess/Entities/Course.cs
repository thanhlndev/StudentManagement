using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.DataAccess.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(10)]
        public string CourseCode { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(20)]
        public string Semester { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Số tín chỉ phải nằm trong khoảng từ 1 đến 10.")]
        public int CreditCount { get; set; }

        [Required]
        [MaxLength(10)]
        public string EmployeeCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string ProgramCode { get; set; }

        // Navigation properties
        public virtual Employee Employee { get; set; }
        public virtual TrainingProgram Program { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
