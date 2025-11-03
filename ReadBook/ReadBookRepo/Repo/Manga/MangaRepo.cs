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
        
    }
}
