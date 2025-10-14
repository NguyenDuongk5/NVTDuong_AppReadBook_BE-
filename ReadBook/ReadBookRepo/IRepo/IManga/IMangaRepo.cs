
using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;


namespace ReadBookRepo.Repo
{
    public interface IMangaRepo : IMySqlBaseRepo<MangaEntity, MangaDto>
    {
        ///// <summary>
        ///// Đây là interface cho Repository layer.
        ///// Định nghĩa những gì Repo cần làm(ở đây mới chỉ có GetAll).
        ///// </summary>
        //Task<List<MangaDto>> GetAll();

        ///// <summary>
        ///// Thêm 1 bản ghi manga mới vào DB.
        ///// Trả về true nếu thêm thành công, false nếu thất bại.
        ///// </summary>
        //Task<bool> InsertAsync(MangaEntity entity);

        ///// Cập nhật thông tin 1 bản ghi manga.
        ///// Trả về true nếu update thành công, false nếu thất bại.
        //Task<bool> UpdateAsync(MangaEntity entity);

        ///// <summary>
        ///// Xóa 1 bản ghi manga theo ID.
        ///// Trả về true nếu xóa thành công, false nếu thất bại.
        ///// </returns>
        //Task<bool> DeleteAsync(Guid pkId);

    }
}
