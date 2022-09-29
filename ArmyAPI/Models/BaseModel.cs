using System.ComponentModel.DataAnnotations;

public class BaseModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

}
