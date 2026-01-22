using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    // [Table("Products")]
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Tensanpham", TypeName = "ntext")]
        public string? Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        // public int? CateID { get; set; }
        // --> CateID NULL
        // --> FK ON DELETE NO ACTION
        public int CateID { get; set; } // = Category có [Required]
        // --> CateID NOTE NULL
        // --> FK ON DELETE ON CASCADE

        // [ForeignKey("CateID")]
        // [Required]
        // [InverseProperty("Products")]
        public Category? Category { get; set; } // FK

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price} - {CateID}");
    }
}