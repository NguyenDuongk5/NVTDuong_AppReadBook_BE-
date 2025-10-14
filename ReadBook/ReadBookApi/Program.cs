///4. Ðãng k? DI trong Program.cs
///Ðãng k? ð? ASP.NET Core t? inject repo khi c?n 
///(ví d? vào controller).

using Microsoft.Extensions.DependencyInjection;
//using ReadBookRepo.Base.IRepo;
//using ReadBookRepo.Base.Repo;
//using ReadBookRepo.IRepo.Category;
//using ReadBookRepo.IRepo.Chapters;


//using ReadBookRepo.Repo;
//using ReadBookRepo.Repo.Category;
//using ReadBookRepo.Repo.Chapters;
//using ReadBookService.Base;
//using ReadBookService.IService.Category;
//using ReadBookService.IService.Chapters;
//using ReadBookService.IService.Home;
//using ReadBookService.Service.Base;
//using ReadBookService.Service.Category;
//using ReadBookService.Service.Chapters;
//using ReadBookService.Service.Home;
//using Weding.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ðãng k? service v?i scope ? ðây
//builder.Services.AddScoped(typeof(IMySqlBaseRepo<,>), typeof(MySqlBaseRepo<,>));
//builder.Services.AddScoped<IMangaService, MangaService>();
//builder.Services.AddScoped<IChapterService, ChapterService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();

//// Ðãng k? Repo (fake ho?c MySQL)
//builder.Services.AddScoped<IMangaRepo, MysqlMangaRepo>();
//builder.Services.AddScoped<IChapterRepo, MysqlChapterRepo>();
//builder.Services.AddScoped<ICategoryRepo, MysqlCategoryRepo>();
//builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
