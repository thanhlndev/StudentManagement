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
    public class Student
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(10)]
        public string StudentCode { get; set; }

        [Required, Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string FullName { get; set; }

        [Required, Column(TypeName = "NVARCHAR"), StringLength(10)]
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "NVARCHAR"), StringLength(200)]
        public string Address { get; set; }

        [Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string Hometown { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Phone, StringLength(15)]
        public string PhoneNumber { get; set; }

        public int EnrollmentYear { get; set; }

        [Required, StringLength(10)]
        public string ClassCode { get; set; }

        [Required, StringLength(10)]
        public string ProgramCode { get; set; }

        public virtual Class Class { get; set; }
        public virtual TrainingProgram Program { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
