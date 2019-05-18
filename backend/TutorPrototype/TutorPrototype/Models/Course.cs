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
        [InverseProperty(nameof(SignInCourses.Course))]
        public int CRN { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public Department Department { get; set; }
        public string CourseName { get; set; }
        public string ShortName { get; set; }
    }
}
