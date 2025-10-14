using Microsoft.AspNetCore.Mvc;
using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;
using ReadBookService.IService.Home;
using ReadBookService.Service.Home;
namespace ReadBookApi.Controllers
{
    /// <summary>
    /// Kế thừa từ BaseController nên controller này tự động có sẵn các API CRUD:
    /// - GET    /Manga/all      → Lấy danh sách Manga
    /// - POST   /Manga/insert   → Thêm mới Manga
    /// - PUT    /Manga/update   → Cập nhật Manga
    /// - DELETE /Manga/delete   → Xóa Manga
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MangaController : BaseController<MangaEntity, MangaDto>
    {
        /// Khai báo interface service để gọi các hàm xử lý dữ liệu Manga
        private readonly IMangaService _service;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="service"></param>
        public MangaController(IMangaService service) : base(service)
        {
            _service = service;
        }
    }
}
