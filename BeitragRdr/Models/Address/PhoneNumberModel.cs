using BeitragRdr.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models.Address
{
    public class PhoneNumberModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
