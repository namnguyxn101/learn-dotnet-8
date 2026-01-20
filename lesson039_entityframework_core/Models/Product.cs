using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProviderName { get; set; }

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {ProviderName}");
    }
}