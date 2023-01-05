using BeitragRdr.Models.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models.ImageModels
{
    public class ImageModelFacebook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string base64data { get; set; }
        public int BeitragFaceId { get; set; }
        public BeitragFace BeitragFace { get; set; }
    }
}
