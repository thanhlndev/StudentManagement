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
   public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required, StringLength(10)]
        public string EmployeeCode { get; set; }
        
        [Required, Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string EmployeeName { get; set; }
        
        [Required, Column(TypeName = "NVARCHAR"), StringLength(50)]
        public string EmployeeType { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        [Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string Hometown { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
