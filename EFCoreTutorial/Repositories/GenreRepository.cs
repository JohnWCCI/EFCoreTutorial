using EFCoreTutorial.Context;
using EFCoreTutorial.Models;
using EFCoreTutorial.Repositories.Interfaces;

namespace EFCoreTutorial.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MusicContext context) : base(context)
        {
        }
    }
}
