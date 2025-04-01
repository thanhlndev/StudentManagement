using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    public class TrainingProgram
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(10)]
        public string ProgramCode { get; set; }

        [Required, Column(TypeName = "NVARCHAR"), StringLength(50)]
        public string ProgramType { get; set; }

        public int CreditCount { get; set; }
        public int TrainingYear { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
