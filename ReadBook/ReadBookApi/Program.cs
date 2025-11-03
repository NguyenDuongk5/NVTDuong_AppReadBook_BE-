using Microsoft.Extensions.DependencyInjection;
using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Base.Repo;
using ReadBookRepo.IRepo.Category;
using ReadBookRepo.IRepo.Chapters;
using ReadBookRepo.Repo;
using ReadBookRepo.Repo.Category;
using ReadBookRepo.Repo.Chapters;
using ReadBookService.Base;
using ReadBookService.IService.Category;
using ReadBookService.IService.Chapters;
using ReadBookService.IService.Home;
using ReadBookService.Service.Base;
using ReadBookService.Service.Category;
using ReadBookService.Service.Chapters;
using ReadBookService.Service.Home;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IMySqlBaseRepo<,>), typeof(MySqlBaseRepo<,>));
builder.Services.AddScoped<IMangaRepo, MysqlMangaRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IChapterRepo, ChapterRepo>();

builder.Services.AddScoped (typeof(IBaseService<,>), typeof(BaseService<,>));
builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IChapterService, ChapterService>();


// Cho phép CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173") // cho phép app Vue
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

try
{
    var app = builder.Build();

    app.UseStaticFiles();
    app.UseCors("AllowAll");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("🔥 Application startup error: " + ex.Message);
    throw;
}

//var app = builder.Build();

//app.UseStaticFiles();


//// Sử dụng CORS
//app.UseCors("AllowAll");
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
