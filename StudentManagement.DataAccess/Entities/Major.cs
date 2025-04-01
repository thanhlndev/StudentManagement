using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Entities
{
    public class Major
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(10)]
        public string MajorCode { get; set; }

        [Required, Column(TypeName = "NVARCHAR"), StringLength(100)]
        public string MajorName { get; set; }

        [Required, StringLength(10)]
        public string FacultyCode { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }

}
