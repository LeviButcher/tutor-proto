using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorPrototype.Models
{
    public class SignIn
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
        [Required]
        public int SemesterId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public Semester Semester { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public bool Tutoring { get; set; }
        [InverseProperty(nameof(SignInCourses.SignIn))]
        public List<SignInCourses> Courses { get; set; } = new List<SignInCourses>();
        [InverseProperty(nameof(SignInReason.SignIn))]
        public List<SignInReason> Reasons { get; set; } = new List<SignInReason>();
    }
}
