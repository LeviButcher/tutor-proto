using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorPrototype.Models
{
    public class Reason
    {
        [Key]
        [InverseProperty(nameof(SignInReason.Reason))]
        public int ID { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }
    }
}
