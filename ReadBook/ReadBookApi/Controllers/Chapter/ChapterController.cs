using Microsoft.AspNetCore.Mvc;
using ReadBookRepo.Entity.Chapter.Dto;
using ReadBookRepo.Entity.Chapters.Entity;
using ReadBookService.IService.Chapters;

///nhiệm vụ là xử lý request từ FE và trả response JSON về.

namespace ReadBookApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class ChapterController : BaseController<ChapterEntity, ChapterDto>
    {
        private readonly IChapterService _service;
        /// <summary>
        /// _service là dependency được inject qua DI Container.
        /// IChapterService là service interface, chứa logic để gọi repo và xử lý dữ liệu.
        /// DI sẽ tự động cung cấp ChapterService khi controller chạy.
        /// </summary>
        public ChapterController(IChapterService service) : base(service)
        {
            _service = service;
        }
    }

}