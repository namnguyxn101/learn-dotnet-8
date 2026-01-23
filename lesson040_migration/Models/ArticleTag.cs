// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace MigrationDemo
// {
//     public class ArticleTag
//     {
//         [Key]
//         public int ArticleTagID { get; set; }

//         public int TagID { get; set; }

//         [ForeignKey("TagID")]
//         public Tag? Tag { get; set; }

//         public int ArticleID { get; set; }

//         [ForeignKey("ArticleID")]
//         public Article? Article { get; set; }
//     }
// }