<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.DataAccess.Entities
{
    public class Class
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Mã lớp phải từ 3 đến 10 ký tự.")]
        [Column(TypeName = "NVARCHAR")]
        public string ClassCode { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên lớp phải từ 3 đến 100 ký tự.")]
        [Column(TypeName = "NVARCHAR")]
        public string ClassName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Mã chuyên ngành phải từ 2 đến 10 ký tự.")]
        public string MajorCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Loại hình đào tạo phải từ 5 đến 50 ký tự.")]
        [Column(TypeName = "NVARCHAR")]
        public string EducationType { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Mã phân lớp phải từ 1 đến 5 ký tự.")]
        [Column(TypeName = "NVARCHAR")]
        public string ClassSection { get; set; }

        // Navigation properties
        public virtual Major Major { get; set; }
        public virtual ICollection<Student> Students { get; set; }
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
    [Table("Classes")]
    public class Class
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ClassID { get; set; }
        public string ClassName { get; set; }
        public string MajorID { get; set; }
        public string EducationType { get; set; }
        public string Course { get; set; }

        // Navigation properties
        public virtual Major Major { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
>>>>>>> 66bfcaf46f3979474ca67107b217457cb3fc45cf
