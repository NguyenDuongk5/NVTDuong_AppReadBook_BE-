namespace ReadBookRepo.Enumeration
{
    /// <summary>
    /// Trạng thái xuất bản của Manga
    /// Author: NVTDuong 21.9.2025
    /// </summary>
    public enum MangaStatusEnum : int
    {
        /// <summary>
        /// Đang phát hành
        /// </summary>
        Ongoing = 1,

        /// <summary>
        /// Đã hoàn thành
        /// </summary>
        Completed = 2,

        /// <summary>
        /// Ngừng phát hành
        /// </summary>
        Stop = 3
    }

    /// <summary>
    /// Trạng thái bản ghi (CRUD State)
    /// Author: NVTDuong 21.09.2025
    /// </summary>
    public enum ModelState : int
    {
        /// <summary>
        /// Xem, không thay đổi
        /// </summary>
        View = 0,

        /// <summary>
        /// Bản ghi mới thêm
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Bản ghi cập nhật
        /// </summary>
        Update = 2,

        /// <summary>
        /// Bản ghi xóa
        /// </summary>
        Delete = 3
    }
}
