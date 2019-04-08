using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorPrototype.Models
{
    public class SignInCourses
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(CourseID))]
        public int CourseID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey(nameof(SignInID))]
        public int SignInID { get; set; }
    }
}
