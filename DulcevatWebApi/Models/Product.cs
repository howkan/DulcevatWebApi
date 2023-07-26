namespace DulcevatWebApi.Models;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid ProductID { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public int ProductPrice { get; set; }
}
