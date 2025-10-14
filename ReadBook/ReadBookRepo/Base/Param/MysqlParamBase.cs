namespace ReadBookRepo.Base.Param
{
    public class MysqlParamBase
    {
        /// <summary>
        /// Danh sách cột cần select (mặc định: "*").
        /// </summary>
        public string column { get; set; } = "*";

        /// <summary>
        /// Đối tượng chứa giá trị parameter (WHERE).
        /// </summary>
        public object param { get; set; }

    }

    /// <summary>
    /// Tham số phân trang.
    /// </summary>
    public class MysqlParamPagingBase : MysqlParamBase
    {
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Số bản ghi mỗi trang
        /// </summary>
        public int take { get; set; }
    }

    /// <summary>
    /// Kết quả trả về khi phân trang.
    /// </summary>
    public class MysqlResultPagingBase<T>
    {
        /// <summary>
        /// Danh sách kết quả (list object)
        /// </summary>
        public List<T> data { get; set; }

        /// <summary>
        /// Tổng số bản ghi thỏa điều kiện.
        /// </summary>
        public int total_record { get; set; }
    }

    /// <summary>
    /// Tham số cho thao tác thêm/sửa/xóa (Modify).
    /// </summary>
    public class MysqlModifyParamBase<TDto>
    {
        /// <summary>
        /// Danh sách thêm mới.
        /// </summary>
        public List<TDto> InsertList { get; set; }

        /// <summary>
        /// Danh sách cập nhật.
        /// </summary>
        public List<TDto> UpdateList { get; set; }

        /// <summary>
        /// Các trường cần update.
        /// </summary>
        public List<string> UpdateFields { get; set; }

        /// <summary>
        /// Danh sách id cần xóa.
        /// </summary>
        public List<string> DeleteIds { get; set; }
    }
}
