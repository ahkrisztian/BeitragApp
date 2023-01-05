using BeitragRdr.Models.BaseModels;
using BeitragRdr.Models.SubModels;
using System.ComponentModel.DataAnnotations;

namespace BeitragRdr.Models;

public class Beitrag
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    public BeitragInsta beitragInsta { get; set; }

    public BeitragFace beitragFace { get; set; }
    public BeitragPintr beitragPintr { get; set; }

    public virtual List<BeitragTags> tags { get; set; } = new List<BeitragTags>();
}
