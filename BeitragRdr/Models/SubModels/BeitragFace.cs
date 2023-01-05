using BeitragRdr.Models.BaseModels;
using BeitragRdr.Models.ImageModels;
using System.ComponentModel.DataAnnotations;

namespace BeitragRdr.Models.SubModels;

public class BeitragFace : FullBaseModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    //public int ImageModelFacebookId { get; set; }
    public ImageModelFacebook Image { get; set; }
}
