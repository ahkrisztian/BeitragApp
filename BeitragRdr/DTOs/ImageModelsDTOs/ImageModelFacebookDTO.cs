using BeitragRdr.DTOs.SubModelsDTOs;
using BeitragRdr.Models.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.DTOs.ImageModelsDTOs
{
    public class ImageModelFacebookDTO
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string base64data { get; set; }
        //public virtual BeitragFaceDTO BeitragFace { get; set; }
    }
}
