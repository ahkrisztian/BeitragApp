using BeitragRdr.DTOs.ImageModelsDTOs;
using System.ComponentModel.DataAnnotations;

namespace BeitragRdr.DTOs.SubModelsDTOs;

public class BeitragInstaDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
    public ImageModelInstagramDTO? Image { get; set; }
}
