
using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Entity.Manga;
using ReadBookRepo.Entity.Manga.Dto;


namespace ReadBookRepo.Repo
{
    public interface IMangaRepo : IMySqlBaseRepo<MangaEntity, MangaDto>
    {

    }
}
