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

        protected override async Task<List<MangaDto>> AfterGetAllData(List<MangaDto> data)
        {
            data = data.OrderByDescending(x => x.modified_date).ToList();
            return data;
        }
    }
}
