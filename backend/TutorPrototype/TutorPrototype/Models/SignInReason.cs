using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorPrototype.Models
{
    public class SignInReason
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(SignInID))]
        public int SignInID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey(nameof(ReasonID))]
        public int ReasonID { get; set; }
    }
}
