﻿using BeitragRdr.Models.BaseModels;
using BeitragRdr.Models.ImageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models.SubModels
{
    public class BeitragPintr : FullBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        //public int ImageModelPinteresId { get; set; }
        public ImageModelPintr Image { get; set; }
    }
}
