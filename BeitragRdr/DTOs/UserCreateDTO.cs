using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.DTOs
{
    public class UserCreateDTO
    {
        public string ObjectIdentifier { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
