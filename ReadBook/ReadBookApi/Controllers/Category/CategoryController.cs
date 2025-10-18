using Microsoft.AspNetCore.Mvc;
using ReadBookRepo.Entity.Category;
using ReadBookRepo.Entity.Category.Dto;
using ReadBookService.IService.Category;

namespace ReadBookApi.Controllers.Category
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController<CategoryEntity, CategoryDto>
    {
        private readonly ICategoryService _repo;

        public CategoryController(ICategoryService baseRepo)
            : base(baseRepo)
        {
            _repo = baseRepo;
        }


    }
}
