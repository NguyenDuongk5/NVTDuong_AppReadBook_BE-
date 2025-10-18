using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Entity.Category;
using ReadBookRepo.Entity.Category.Dto;
using ReadBookService.IService.Category;
using ReadBookService.Service.Base;

namespace ReadBookService.Service.Category
{
    public class CategoryService : BaseService<CategoryEntity, CategoryDto>, ICategoryService
    {
        private readonly IMySqlBaseRepo<CategoryEntity, CategoryDto> _repo;

        public CategoryService(IMySqlBaseRepo<CategoryEntity, CategoryDto> baseRepo)
            : base(baseRepo)
        {
            _repo = baseRepo;
        }
    }
}
