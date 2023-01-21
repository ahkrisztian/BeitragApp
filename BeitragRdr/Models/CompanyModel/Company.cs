using BeitragRdr.Models.Address;
using BeitragRdr.Models.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models.CompanyModel
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public virtual User User { get; set; }

        public List<AddressModel> addresses { get; set; } = new List<AddressModel>();

        public List<PhoneNumberModel> phoneNumbers { get; set; } = new List<PhoneNumberModel>();
        public List<Beitrag> beitrags { get; set; } = new List<Beitrag>();
    }
}
