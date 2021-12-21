using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private MyMusicDBContext MyMusicDBContext
        {
            get
            {
                return Context as MyMusicDBContext;
            }
        }
        public MusicRepository(MyMusicDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await MyMusicDBContext.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await MyMusicDBContext.Musics
                .Include(m => m.Artist)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await MyMusicDBContext.Musics
                .Include(m => m.Artist)
                .Where(m => m.ArtistId == artistId)
                .ToListAsync();
        }
        
         async Task<IEnumerable<Music>> IMusicRepository.GetAllWithArtistAsync()
         {
            return await MyMusicDBContext.Musics
              .Include(m => m.Artist)
              .ToListAsync();
         }

        async Task<Music> IMusicRepository.GetWithArtistByIdAsync(int id)
        {
            return await MyMusicDBContext.Musics
               .Include(m => m.Artist)
               .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        async Task<IEnumerable<Music>> IMusicRepository.GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await MyMusicDBContext.Musics
               .Include(m => m.Artist)
               .Where(m => m.ArtistId == artistId)
               .ToListAsync();
        }
        
    }

}
