using BeitragRdr.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.DTOs
{
    public class TagsDTO
    {
        [Required]
        [StringLength(100)]
        public string Tag { get; set; }

    }
}
