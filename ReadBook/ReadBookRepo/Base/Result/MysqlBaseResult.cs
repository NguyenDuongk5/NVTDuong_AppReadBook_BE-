namespace ReadBookRepo.Base.Result
{
    /// <summary>
    /// Kết quả trả về từ thao tác DB
    /// </summary>
    public class MysqlBaseResult
    {
        /// <summary>
        /// Trạng thái thành công/thất bại
        /// </summary>
        public bool is_sucsess { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// Mã trạng thái (200, 400, 500…)
        /// </summary>
        public int status_code { get; set; }

        /// <summary>
        /// Thông điệp mô tả
        /// </summary>
        public string message { get; set; }
    }
}
