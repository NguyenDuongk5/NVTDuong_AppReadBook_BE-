using System.ComponentModel.DataAnnotations;

namespace ReadBookRepo.Entity.Manga.Dto
{
    /// <summary>
    /// Ở đây MangaDto kế thừa MangaEntity → tức là mang toàn bộ dữ liệu của bảng manga, 
    /// nhưng có thể bổ sung thêm các field "tạm" (VD: tên category, số chapter) nếu cần
    /// </summary>
    public class MangaDto : MangaEntity
    {

    }
}
