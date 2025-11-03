using Microsoft.AspNetCore.Mvc;

namespace ReadBookApi.Controllers
{
    //Khai báo model để nhận dữ liệu từ form khi upload
    public class FileUploadModel
    {
        // Thuộc tính đại diện cho file gửi lên từ form
        public IFormFile File { get; set; }
    }

    // Đánh dấu đây là một API Controller
    [ApiController]
    [Route("[controller]")] // Đường dẫn: /upload (tên controller là UploadController)
    //[Consumes("multipart/form-data")] // Có thể bật nếu chỉ nhận multipart/form-data
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        // Tiêm (inject) môi trường web để lấy đường dẫn thư mục wwwroot
        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // API upload ảnh: POST /upload/upload-image
        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm] FileUploadModel model)
        {
            // Lấy file từ model
            var file = model.File;

            // Nếu không có file thì báo lỗi
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Xác định thư mục lưu file: wwwroot/uploads
            var uploadPath = Path.Combine(
                _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"),
                "uploads"
            );

            // Nếu thư mục chưa tồn tại → tạo mới
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Tạo tên file ngẫu nhiên bằng Guid để tránh trùng
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Ghi file xuống ổ đĩa
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Tạo URL đầy đủ để truy cập ảnh
            var imageUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";

            // Trả về kết quả thành công kèm đường dẫn ảnh
            return Ok(new { url = imageUrl });
        }
    }
}
