using System.ComponentModel.DataAnnotations;

namespace TallerTest.Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

}
