using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;
using ReadBookService.Base;
using ReadBookService.IService.Home;
using ReadBookService.Service.Base;

namespace ReadBookService.Service.Home
{
    /// <summary>
    /// Service chuyên xử lý nghiệp vụ cho Manga.
    /// Kế thừa từ BaseService để tái sử dụng CRUD cơ bản.
    /// </summary>
    public class MangaService : BaseService<MangaEntity, MangaDto>, IMangaService
    {
        private readonly IMySqlBaseRepo<MangaEntity, MangaDto> _repo;

        public MangaService(IMySqlBaseRepo<MangaEntity, MangaDto> baseRepo)
            : base(baseRepo)
        {
            _repo = baseRepo;
        }

        ///// <summary>
        ///// Nếu có thêm logic riêng cho Manga thì viết ở đây.
        ///// Ví dụ: Lấy danh sách manga theo thể loại.
        ///// </summary>
        //public async Task<List<MangaDto>> GetByCategory(Guid categoryId)
        //{
        //    var sql = "SELECT * FROM manga WHERE CategoryId = @CategoryId";
        //    var param = new { CategoryId = categoryId };
        //    return await _repo.GetDataAsync<MangaDto>(sql, param);
        //}

        ///// <summary>
        ///// Ví dụ: Lấy danh sách manga nổi bật.
        ///// </summary>
        //public async Task<List<MangaDto>> GetFeaturedManga()
        //{
        //    var sql = "SELECT * FROM manga WHERE IsFeatured = 1 ORDER BY UpdatedDate DESC LIMIT 10";
        //    return await _repo.GetDataAsync<MangaDto>(sql);
        //}
    }
}
