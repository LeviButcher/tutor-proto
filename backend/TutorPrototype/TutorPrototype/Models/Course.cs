using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TutorPrototype.Models
{
    public class Course
    {
        [Key]
        public int CRN { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public int DepartmentID { get; set; }
        public string CourseName { get; set; }
        public string ShortName { get; set; }
    }
}
