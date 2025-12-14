using MySqlX.XDevAPI.Common;
using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Base.Param;
using ReadBookRepo.Base.Repo;
using ReadBookRepo.Base.Result;
using ReadBookService.Base;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ReadBookService.Service.Base
{
    /// Service base cho phép gọi chung các hàm từ Repo dùng cho MySQL.
    /// Mục đích:
    /// - Cung cấp các phương thức CRUD cơ bản (Insert, Update, Delete) mà nhiều Service khác có thể tái sử dụng.
    public class BaseService<Entity, Dto> : IBaseService<Entity, Dto>
    {
        private readonly IMySqlBaseRepo<Entity, Dto> _baseRepo;

        /// <summary>
        /// Lấy hết dữ liệu
        /// </summary>
        /// <param name="baseRepo"></param>
        public BaseService(IMySqlBaseRepo<Entity, Dto> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<List<Dto>> GetAll()
        {
            var result = await _baseRepo.GetAll();

            result = await AfterGetAllData(result);

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual async Task<List<Dto>> AfterGetAllData(List<Dto> data)
        {
            return data;
        }

        /// <summary>
        /// Thêm mới một dữ liệu vào database
        /// </summary>
        /// <param name="entity">Dữ liệu cần lưu</param>
        /// Author: NVTDuong 27.09.2025
        public async Task<MysqlBaseResult> InsertAsync(Entity entity)
        {
            var inserted = await _baseRepo.InsertAsync(entity);

            return new MysqlBaseResult()
            {
                is_sucsess = inserted > 0,
                status_code = inserted > 0
                                ? (int)StatusCodes.Status201Created
                                : (int)StatusCodes.Status400BadRequest,
                message = inserted > 0 ? "Thêm mới thành công" : "Thêm mới thất bại",
                data = null
            };
        }


        /// <summary>
        /// Cập nhật thông tin một entity trong database
        /// </summary>
        /// <param name="entity"></param>
        /// Author: NVTDuong 27.09.2025
        public async Task<MysqlBaseResult> UpdateAsync(Entity entity)
        {
            // Validate
            var result = new MysqlBaseResult();

            /// Tìm property được đánh dấu [Key] (khóa chính)
            var keyProp = typeof(Entity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                           .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));
            ///Nếu Entity không có [Key] → ném exception, vì không biết update bản ghi nào.
            if (keyProp == null || keyProp.GetValue(entity) == null || keyProp.GetValue(entity).ToString() == Guid.Empty.ToString())
            {
                return new MysqlBaseResult()
                {
                    is_sucsess = false,
                    status_code = (int)StatusCodes.Status422UnprocessableEntity,
                    message = "Không có giá trị khóa chính",
                    data = null
                };
            }

            var resultRepo = await _baseRepo.UpdateAsync(entity);

            return new MysqlBaseResult()
            {
                is_sucsess = resultRepo,
                status_code = (int)StatusCodes.Status200OK,
                message = resultRepo ? "Lưu thành công" : "Lưu thất bại",
                data = null
            };

        }

        /// <summary>
        /// Xóa một entity khỏi database.
        /// </summary>
        /// <param name="pkId"></param>
        /// Author: NVTDuong 27.09.2025
        public async Task<MysqlBaseResult> DeleteAsync(Guid pkId)
        {
            var deleted = await _baseRepo.DeleteAsync(pkId);

            return new MysqlBaseResult()
            {
                is_sucsess = deleted > 0,
                status_code = deleted > 0
                                ? (int)StatusCodes.Status200OK
                                : (int)StatusCodes.Status404NotFound,
                message = deleted > 0 ? "Xóa thành công" : "Không tìm thấy bản ghi cần xóa",
                data = null
            };
        }

        /// <summary>
        /// Lấy dữ liệu có phân trang.
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về (thường là Dto)</typeparam>
        /// <param name="paramPagingBase">Thông tin phân trang (page, take, điều kiện where)</param>
        /// <returns>Kết quả phân trang (data + tổng số bản ghi)</returns>
        public async Task<MysqlResultPagingBase<T>> GetPagingAsync<T>(MysqlParamPagingBase paramPagingBase)
        {
            // Gọi xuống repo để lấy dữ liệu
            return await _baseRepo.GetDataPagingAsync<T>(paramPagingBase);
        }

        public async Task<int> CountAsync()
        {
            return await _baseRepo.CountAsync();
        }

        public async Task<int> CountTodayAsync()
        {
            return await _baseRepo.CountTodayAsync();
        }

        public async Task<List<Dto>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Dto>();

            var result = await _baseRepo.SearchAsync(keyword);
            return await AfterGetAllData(result);
        }
        public async Task<Dto?> GetByIdAsync(Guid id)
        {
            return await _baseRepo.GetByIdAsync(id);
        }


    }
}
