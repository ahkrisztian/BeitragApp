using BeitragRdr.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models.Address
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        public virtual Company Company { get; set; }

    }
}
