using System.ComponentModel.DataAnnotations;
using BeitragRdr.DTOs.ImageModelsDTOs;

namespace BeitragRdr.DTOs.SubModelsDTOs;

public class BeitragFaceDTO
{

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(2000)]
    public string Description { get; set; }

    public virtual ImageModelFacebookDTO? Image { get; set; }
}
