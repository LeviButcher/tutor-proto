using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorPrototype.Models
{
    public class Department
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
