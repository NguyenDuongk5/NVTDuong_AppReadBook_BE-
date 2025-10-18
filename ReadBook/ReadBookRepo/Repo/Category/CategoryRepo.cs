using Dapper;
using MySql.Data.MySqlClient;
using ReadBookRepo.Base.Repo;
using ReadBookRepo.Entity.Category;
using ReadBookRepo.Entity.Category.Dto;
using ReadBookRepo.IRepo.Category;
namespace ReadBookRepo.Repo.Category
{
    public class CategoryRepo : MySqlBaseRepo<CategoryEntity, CategoryDto>, ICategoryRepo
    {

    }
}
