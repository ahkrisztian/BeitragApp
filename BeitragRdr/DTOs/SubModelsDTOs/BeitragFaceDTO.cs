using System.ComponentModel.DataAnnotations;
using BeitragRdr.DTOs.ImageModelsDTOs;

namespace BeitragRdr.DTOs.SubModelsDTOs;

public class BeitragFaceDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    public virtual ImageModelFacebookDTO? Image { get; set; }
}
