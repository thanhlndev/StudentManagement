<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> 66bfcaf46f3979474ca67107b217457cb3fc45cf
