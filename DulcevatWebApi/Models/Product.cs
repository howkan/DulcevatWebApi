using System.ComponentModel.DataAnnotations;

namespace DulcevatWebApi.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public int ProductPrice { get; set; }
    }
}
