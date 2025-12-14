using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySqlConnector; // cần package MySqlConnector
using ReadBookRepo.Base.Param;
using ReadBookRepo.Base.Repo;
using ReadBookRepo.Entity.Category;
using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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
