using BeitragRdr.DTOs.SubModelsDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.DTOs
{
    public class UpdateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public virtual BeitragInstaDTO? beitragInsta { get; set; }

        public virtual BeitragFaceDTO? beitragFace { get; set; }
        public virtual BeitragPintrDTO? beitragPintr { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Company")]
        public int CompanyId { get; set; }
        public virtual List<TagsDTO> tags { get; set; } = new List<TagsDTO>();
    }
}
