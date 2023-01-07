using BeitragRdr.Models.SubModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeitragRdr.Models.ImageModels;

public class ImageModelFacebook
{
    [Key, ForeignKey("BeitragFace")]
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string base64data { get; set; }
    public virtual BeitragFace BeitragFace { get; set; }
}
