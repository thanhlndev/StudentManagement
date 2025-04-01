using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    [Table("Majors")]
    public class Major
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MajorID { get; set; }
        public string MajorName { get; set; }
        public string FacultyID { get; set; }

        // Navigation properties
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
