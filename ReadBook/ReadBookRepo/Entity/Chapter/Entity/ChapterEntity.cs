using ReadBookRepo.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBookRepo.Entity.Chapters.Entity
{
    [Table("chapter")]

    public class ChapterEntity : CRUDEntity
    {
        [Key]
        public Guid chapter_id { get; set; }

        public Guid manga_id { get; set; }

        public int chapter_number { get; set; }

        public string chapter_content { get; set; }

        public string chapter_title { get; set; } = string.Empty;

    }
}
