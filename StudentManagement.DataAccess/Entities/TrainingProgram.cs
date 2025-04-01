using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    [Table("TrainingPrograms")]
    public class TrainingProgram
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProgramID { get; set; }
        public string ProgramType { get; set; }
        public int CreditCount { get; set; }
        public int TrainingYear { get; set; }

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
