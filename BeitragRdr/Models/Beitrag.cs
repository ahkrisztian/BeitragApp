﻿using BeitragRdr.Models.BaseModels;
using BeitragRdr.Models.CompanyModel;
using BeitragRdr.Models.SubModels;
using BeitragRdr.Models.UserModel;
using System.ComponentModel.DataAnnotations;

namespace BeitragRdr.Models;

public class Beitrag : IBaseModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    public virtual BeitragInsta beitragInsta { get; set; }

    public virtual BeitragFace beitragFace { get; set; }
    public virtual BeitragPintr beitragPintr { get; set; }
    public virtual Company company { get; set; }
    public virtual List<Tags> tags { get; set; } = new List<Tags>();
    public string CreatedByUserId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
