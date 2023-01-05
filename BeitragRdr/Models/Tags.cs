using BeitragRdr.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models
{
    public class Tags : IIdentityModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Tag { get; set; }

        public virtual List<BeitragTags> Beitrags { get; set; } = new List<BeitragTags>();
    }
}
