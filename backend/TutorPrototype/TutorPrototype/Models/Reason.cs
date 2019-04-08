using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorPrototype.Models
{
    public class Reason
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}
