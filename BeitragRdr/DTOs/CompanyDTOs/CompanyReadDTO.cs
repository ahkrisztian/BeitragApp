using BeitragRdr.Models.Address;
using BeitragRdr.Models.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.DTOs.CompanyDTOs
{
    public class CompanyReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public List<AddressReadDTO> addresses { get; set; } = new List<AddressReadDTO>();

        public List<PhoneNumberReadDTO> phoneNumbers { get; set; } = new List<PhoneNumberReadDTO>();
    }
}
