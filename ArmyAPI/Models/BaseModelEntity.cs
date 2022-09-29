using System.ComponentModel.DataAnnotations;

public class BaseModelEntity : BaseModel
{ 
    [Required]
    [MaxLength(1000)]
    public string Description { get; set; }
}
