using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using ReadBookRepo.Base.Param;
using ReadBookRepo.Base.Repo;
using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

/// Đây là nơi làm việc trực tiếp với database
namespace ReadBookRepo.Repo
{
    /// <summary>
    /// Kế thừa MySqlBaseRepo<MangaEntity> → tức là có sẵn các hàm base để query MySQL bằng Dapper.
    /// </summary>
    public class MysqlMangaRepo : MySqlBaseRepo<MangaEntity, MangaDto>, IMangaRepo
    {
        /// <summary>
        /// lấy toàn bộ manga từ bảng manga và trả về dạng List<MangaDto>.
        /// </summary>
        //public async Task<List<MangaDto>> GetAll()
        //{
        //    var mangas = await GetDataAsync<MangaDto>();
        //    return mangas;
        //}

        ///// <summary>
        ///// thực hiện query phân trang với param (limit, offset), sau đó trả về MangaPagingResult.
        ///// </summary>
        //public async Task<MangaPagingResult> GetPaging()
        //{

        //    var param = new MysqlParamPagingBase
        //    {

        //    };
        //    var mangas = await GetDataPagingAsync<MangaDto>(param);
        //    return new MangaPagingResult
        //    {
        //        data = mangas.data,
        //        total = mangas.total_record,
        //        page = param.page
        //    };
        //}


        ///// <summary>
        ///// Thêm bản ghi
        ///// </summary>
        ///// <returns></returns>
        //public async Task<bool> InsertAsync(MangaEntity entity)
        //{
        //    var result = await base.InsertAsync(entity);
        //    return result > 0;
        //}

        ///// <summary>
        ///// Update bản ghi
        ///// </summary>

        //public async Task<bool> UpdateAsync(MangaEntity entity)
        //{
        //    var result = await base.UpdateAsync(entity);  // base trả int
        //    return result;                            // convert sang bool
        //}

        ///// <summary>
        ///// Xóa bản ghi
        ///// </summary>
        //public async Task<bool> DeleteAsync(Guid pkId)
        //{
        //    var result = await base.DeleteAsync(pkId);  // base trả int
        //    return result > 0;                            // convert sang bool
        //}

        //public static string ToMySqlDateTimeString(DateTime value)
        //{
        //    return value.ToString("yyyy-MM-dd HH:mm:ss");
        //}
    }
}
