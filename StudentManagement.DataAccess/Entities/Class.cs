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
