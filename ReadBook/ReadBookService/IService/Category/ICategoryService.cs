using ReadBookRepo.Entity.Category;
using ReadBookRepo.Entity.Category.Dto;
using ReadBookService.Base;

namespace ReadBookService.IService.Category
{
    public interface ICategoryService : IBaseService<CategoryEntity, CategoryDto> 
    {
    }
}
