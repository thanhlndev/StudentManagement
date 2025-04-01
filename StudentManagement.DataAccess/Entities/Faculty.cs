using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    public class Faculty
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(10, MinimumLength = 2, ErrorMessage = "FacultyCode must be between 2 and 10 characters.")]
        public string FacultyCode { get; set; }

        [Required, Column(TypeName = "NVARCHAR"), StringLength(100, MinimumLength = 2)]
        public string FacultyName { get; set; }

        public virtual ICollection<Major> Majors { get; set; }
    }
}
