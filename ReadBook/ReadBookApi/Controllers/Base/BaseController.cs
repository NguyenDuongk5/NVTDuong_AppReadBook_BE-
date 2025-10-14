using Microsoft.AspNetCore.Mvc;
using ReadBookRepo.Base.Param;
using ReadBookRepo.Entity.Manga;
using ReadBookService.Base;
using ReadBookService.IService.Home;
using ReadBookService.Service.Home;

/// <summary>
/// Controller nhận request từ FE, gọi service xử lý logic nghiệp vụ 
/// </summary>
namespace ReadBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<Entity, Dto> : ControllerBase
    {
        /// Khai báo interface service để gọi các hàm xử lý dữ liệu Manga
        private readonly IBaseService<Entity, Dto> _baseService;

        /// <summary>
        /// Hàm khởi tạo controller, nhận service qua Dependency Injection.
        /// DI Container sẽ tự động inject service tương ứng khi khởi chạy.
        /// </summary>
        /// <param name="service">Service xử lý logic nghiệp vụ</param>
        public BaseController(IBaseService<Entity, Dto> service)
        {
            _baseService = service;
        }

        /// <summary>
        /// API lấy toàn bộ danh sách entity.
        /// GET: /[Controller]/all
        /// </summary>
        /// <returns>Danh sách entity (List&lt;Dto&gt;)</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _baseService.GetAll();
            return Ok(result);
        }


        /// <summary>
        /// API thêm mới một entity.
        /// POST: /[Controller]/insert
        /// </summary>
        /// <param name="entity">Thông tin entity cần thêm mới</param>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecord([FromBody] Entity entity)
        {
            /// Gọi service thêm bản ghi mới
            var success = await _baseService.InsertAsync(entity);
            return Ok(success);
        }

        /// <summary>
        /// API cập nhật một entity.
        /// PUT: /[Controller]/update
        /// </summary>
        /// <param name="entity">Entity cần cập nhật (bao gồm khóa chính)</param>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecord([FromBody] Entity entity)
        {
            var success = await _baseService.UpdateAsync(entity);
            return Ok(success);
        }

        /// <summary>
        /// API xóa entity theo Id.
        /// DELETE: /[Controller]/delete
        /// </summary>
        /// <param name="pkId">Id (khóa chính) của entity cần xóa</param>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRecord([FromBody] Guid pkId)
        {
            var result = await _baseService.DeleteAsync(pkId);
            return Ok(result);
        }
        /// <summary>
        /// API trả ra danh sách phân trang
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("paging")]
        public async Task<IActionResult> GetPaging([FromBody] MysqlParamPagingBase param)
        {
            var result = await _baseService.GetPagingAsync<Dto>(param);
            return Ok(result);
        }

    }
}
