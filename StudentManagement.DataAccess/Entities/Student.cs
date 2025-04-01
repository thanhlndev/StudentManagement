using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Hometown { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int EnrollmentYear { get; set; }
        public string ClassID { get; set; }
        public string ProgramID { get; set; }

        // Navigation properties
        public virtual Class Class { get; set; }
        public virtual TrainingProgram Program { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
