using global::ReadBookRepo.Entity.Manga.Dto;
///Đây là wrapper object cho kết quả phân trang.
///Giúp FE dễ dàng hiển thị list manga kèm số trang.
namespace ReadBookRepo.Entity.Manga
{
    public class MangaPagingResult
    {

        /// <summary>
        /// danh sách manga (theo trang hiện tại).
        /// </summary>
        public List<MangaDto> data { get; set; }

        /// <summary>
        /// tổng số bản ghi trong DB.
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// số trang hiện tại.
        /// </summary>
        public int page { get; set; }
    }
}
