using ReadBookRepo.Base.Param;
using System.Threading.Tasks;

namespace ReadBookRepo.Base.IRepo
{
    /// <summary>
    /// Interface định nghĩa các phương thức cơ bản (Base Repository)
    /// để thao tác với MySQL database theo kiểu generic.
    /// E: kiểu entity (bảng dữ liệu) mà repo sẽ thao tác.
    /// </summary>
    public interface IMySqlBaseRepo<Entity, Dto>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng.
        /// </summary>
        /// <returns>Danh sách dữ liệu dưới dạng List&lt;Dto&gt;</returns>
        /// Author: NVTDuong 27.09.2025
        Task<List<Dto>> GetAll();

        /// <summary>
        /// Thêm mới một dữ liệu vào database
        /// </summary>
        /// <param name="entity">Dữ liệu cần lưu</param>
        /// <returns></returns>
        /// Author: NVTDuong 27.09.2025
        Task<int> InsertAsync(Entity entity);

        /// <summary>
        /// Cập nhật thông tin một entity trong database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Author: NVTDuong 27.09.2025
        Task<bool> UpdateAsync(Entity entity);

        /// <summary>
        /// Xóa một entity trong database theo khóa chính.
        /// </summary>
        /// <param name="pkId">Khóa chính của entity cần xóa</param>
        /// <returns></returns>
        ///  Author: NVTDuong 27.09.2025
        Task<int> DeleteAsync(Guid pkId);

        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramPagingBase"></param>
        /// <returns></returns>
        /// Author: NVTDuong 01.10.2025
        Task<MysqlResultPagingBase<T>> GetDataPagingAsync<T>(MysqlParamPagingBase paramPagingBase);
    }

}
