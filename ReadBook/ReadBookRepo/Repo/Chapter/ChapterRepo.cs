using ReadBookRepo.Base.Repo;
using ReadBookRepo.Entity.Chapter.Dto;
using ReadBookRepo.Entity.Chapters.Entity;
using ReadBookRepo.IRepo.Chapters;

namespace ReadBookRepo.Repo.Chapters
{
    public class ChapterRepo : MySqlBaseRepo<ChapterEntity, ChapterDto>, IChapterRepo
    {

    }
}
