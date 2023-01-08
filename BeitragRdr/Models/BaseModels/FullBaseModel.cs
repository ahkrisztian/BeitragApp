using System.ComponentModel.DataAnnotations;

namespace BeitragRdr.Models.BaseModels;

public class FullBaseModel : IIdentityModel, IBaseModel
{
    [Key]
    public int Id { get; set; }
    public string? CreatedByUserId { get; set; } = Guid.NewGuid().ToString();
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public string? LastModifiedUserId { get; set; } = Guid.NewGuid().ToString();
    public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
}
