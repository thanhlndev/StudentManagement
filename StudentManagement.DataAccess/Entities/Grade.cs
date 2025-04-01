using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    public class Grade
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int GradeCode { get; set; }
        public string StudentCode { get; set; }
        public string CourseCode { get; set; }
        public string ClassCode { get; set; }
        public decimal Grade0 { get; set; }
        public decimal Grade1 { get; set; }
        public string EmployeeCode { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Class Class { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
