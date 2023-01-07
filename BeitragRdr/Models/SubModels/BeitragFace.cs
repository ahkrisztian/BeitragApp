using BeitragRdr.Models.BaseModels;
using BeitragRdr.Models.ImageModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeitragRdr.Models.SubModels;

public class BeitragFace : FullBaseModel
{
    [Key,ForeignKey("Beitrag")]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    public virtual Beitrag? Beitrag { get; set; }

    public virtual ImageModelFacebook? Image { get; set; }
}
