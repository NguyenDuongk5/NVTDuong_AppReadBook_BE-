using Microsoft.AspNetCore.Mvc;
using ReadBookRepo.Entity.Chapter.Dto;
using ReadBookRepo.Entity.Chapters.Entity;
using ReadBookService.IService.Chapters;
using System;
using System.Linq;

namespace ReadBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChapterController : BaseController<ChapterEntity, ChapterDto>
    {
        private readonly IChapterService _service;

        public ChapterController(IChapterService service) : base(service)
        {
            _service = service;
        }        
    }
}
