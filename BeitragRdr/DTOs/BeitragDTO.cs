using BeitragRdr.Models.SubModels;
using BeitragRdr.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeitragRdr.DTOs.SubModelsDTOs;

namespace BeitragRdr.DTOs
{
    public class BeitragDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public virtual BeitragInstaDTO beitragInsta { get; set; }

        public virtual BeitragFaceDTO beitragFace { get; set; }
        public virtual BeitragPintrDTO beitragPintr { get; set; }

        public virtual List<TagsDTO> tags { get; set; } = new List<TagsDTO>();
    }
}
