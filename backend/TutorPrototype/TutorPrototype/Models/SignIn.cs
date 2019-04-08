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
        [ForeignKey(nameof(PersonId))]
        public int PersonId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public int SemesterId { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public bool Tutoring { get; set; }
    }
}
