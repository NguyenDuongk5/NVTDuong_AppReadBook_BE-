using ReadBookRepo.Base.Param;
using ReadBookRepo.Base.Result;

namespace ReadBookService.Base
{
    /// <summary>
    /// Interface base cho tất cả Service
    /// Entity (bảng DB)
    /// </summary>
    public interface IBaseService<Entity, Dto>
    {
        /// <summary>
        /// Hàm Insert bất đồng bộ 
        /// Truyền vào 1 entity để thêm vào DB
        /// Số dòng bị ảnh hưởng trong DB
        /// </summary>
        Task<List<Dto>> GetAll();


        /// <summary>
        /// Thêm mới 1 entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<MysqlBaseResult> InsertAsync(Entity entity);

        /// <summary>
        /// Cập nhật 1 entity
        /// </summary>
        /// <param name="entity"></param>
        Task<MysqlBaseResult> UpdateAsync(Entity entity);

        /// <summary>
        /// Xóa 1 entity theo khóa chính
        /// </summary>
        /// <param name="pkId"></param>
        Task<MysqlBaseResult> DeleteAsync(Guid pkId);

        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramPagingBase"></param>
        Task<MysqlResultPagingBase<T>> GetPagingAsync<T>(MysqlParamPagingBase paramPagingBase);

        Task<int> CountAsync();

        Task<int> CountTodayAsync();

    }
}
