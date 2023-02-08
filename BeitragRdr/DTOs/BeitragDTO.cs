using System.ComponentModel.DataAnnotations;
using BeitragRdr.DTOs.SubModelsDTOs;

namespace BeitragRdr.DTOs;

public enum BeitragStatus
{
    Entwurf = 0,
    Freigabe = 1,
    Geplant = 2,
    Veröffentlicht = 3
}
public class BeitragDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    public virtual BeitragInstaDTO? beitragInsta { get; set; }

    public virtual BeitragFaceDTO? beitragFace { get; set; }
    public virtual BeitragPintrDTO? beitragPintr { get; set; }

    //public virtual CompanyReadDTO Company { get; set; } 
    public virtual List<TagsDTO> tags { get; set; } = new List<TagsDTO>();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a Company")]
    public int CompanyId { get; set; }

    public DateTime? PostDate { get; set; }

    public DateTime? PostedDate { get; set; }
    public BeitragStatus? BeitragStatus { get; set; }
}
