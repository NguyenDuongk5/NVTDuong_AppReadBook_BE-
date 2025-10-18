using ReadBookRepo.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBookRepo.Entity.Category
{
    [Table("category")]
    public class CategoryEntity
    {
        [Key]
        public Guid category_id { get; set; }
        public string category_name { get; set; }
        public string list_manga_id { get; set; }
    }
}
