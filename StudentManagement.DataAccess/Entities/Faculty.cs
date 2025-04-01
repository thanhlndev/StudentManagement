using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    [Table("Faculties")]
    public class Faculty
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FacultyID { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Major> Majors { get; set; }
    }
}
