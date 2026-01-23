using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationDemo
{
    [Table("Tags")]
    public class Tag
    {
        // [Key]
        // [StringLength(20)]
        // public string TagId { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string? Content { get; set; }

        [Key]
        public int TagID { get; set; }
    }
}