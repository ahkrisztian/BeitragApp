using System.ComponentModel.DataAnnotations;

namespace BeitragRdr.Models.BaseModels;

public class FullBaseModel : IIdentityModel, IBaseModel
{
    [Key]
    public int Id { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
