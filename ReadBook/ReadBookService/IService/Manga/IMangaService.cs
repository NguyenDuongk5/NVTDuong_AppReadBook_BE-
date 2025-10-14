using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;
using ReadBookService.Base;
///Đây là interface service, nó định nghĩa những gì MangaService cần làm.
/// chỉ là giao diện (nói rằng Service phải có GetAll()).
namespace ReadBookService.IService.Home
{
    public interface IMangaService : IBaseService<MangaEntity, MangaDto>
    {
        /// <summary>
        /// Lấy danh sách manga theo thể loại.
        /// </summary>
        //Task<List<MangaDto>> GetByCategory(Guid categoryId);

        /// <summary>
        /// Lấy danh sách manga nổi bật (featured).
        /// </summary>
        //Task<List<MangaDto>> GetFeaturedManga();
    }
}
