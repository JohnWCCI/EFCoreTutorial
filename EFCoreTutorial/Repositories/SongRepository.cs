using EFCoreTutorial.Context;
using EFCoreTutorial.Models;
using EFCoreTutorial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EFCoreTutorial.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(MusicContext context) 
            : base(context)
        {        
        }
    }
}
