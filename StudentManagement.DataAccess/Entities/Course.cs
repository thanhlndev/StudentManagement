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
    [Table("Courses")]
    public class Course
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public int CreditCount { get; set; }
        public string EmployeeID { get; set; }
        public string ProgramID { get; set; }

        // Navigation properties
        public virtual Employee Employee { get; set; }
        public virtual TrainingProgram Program { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
