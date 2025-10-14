namespace ReadBookRepo.Base
{
    /// Lớp cơ sở (Base Class) dùng để lưu thông tin
    /// về lịch sử tạo & chỉnh sửa của một entity.
    public class CRUDEntity
    {
        /// <summary>
        /// Thời điểm bản ghi được tạo (Create Date).
        /// </summary>
        public DateTime created_date { get; set; }

        /// <summary>
        /// Người tạo bản ghi (Create By).
        /// Có thể lưu username hoặc user_id.
        /// </summary>
        public string created_by { get; set; }

        /// <summary>
        /// Thời điểm bản ghi được chỉnh sửa lần cuối (Modified Date).
        /// </summary>
        public DateTime modified_date { get; set; }

        /// <summary>
        /// Người chỉnh sửa bản ghi lần cuối (Modified By).
        /// </summary>
        public string modified_by { get; set; }
    }
}
