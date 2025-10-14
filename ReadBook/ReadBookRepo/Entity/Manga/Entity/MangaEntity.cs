using ReadBookRepo.Base;
using ReadBookRepo.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBookRepo.Entity.Manga
{
    /// <summary>
    /// Model ánh xạ bảng manga trong DB
    /// </summary>
    [Table("manga")]
    public class MangaEntity : CRUDEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Key]
        public Guid manga_id { get; set; }

        /// <summary>
        /// Tên manga
        /// </summary>
        public string manga_title { get; set; }

        /// <summary>
        /// Tác giả
        /// </summary>
        public string manga_author { get; set; }

        /// <summary>
        /// Trạng thái (enum MangaStatusEnum)
        /// </summary>
        public MangaStatusEnum manga_status { get; set; }

        /// <summary>
        /// Mô tả ngắn
        /// </summary>
        public string manga_description { get; set; }

        /// <summary>
        /// Ảnh bìa
        /// </summary>
        public string manga_image { get; set; }

        /// <summary>
        /// Danh sách thể loại (JSON string)
        /// </summary>
        public string list_category_id { get; set; }

        /// <summary>
        /// Năm phát hành
        /// </summary>
        public DateTime manga_release_year { get; set; }
    }
}
