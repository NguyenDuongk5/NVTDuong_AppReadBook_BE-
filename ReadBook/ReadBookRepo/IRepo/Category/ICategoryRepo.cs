using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Entity.Category;
using ReadBookRepo.Entity.Category.Dto;

namespace ReadBookRepo.IRepo.Category
{
    public interface ICategoryRepo : IMySqlBaseRepo<CategoryEntity, CategoryDto>
    {
    }
}
