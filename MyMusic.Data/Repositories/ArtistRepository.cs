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
    public  class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private MyMusicDBContext MyMusicDBContext
        {
            get
            {
                return Context as MyMusicDBContext;
            }
        }
        public ArtistRepository(MyMusicDBContext context) : base(context) { }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await MyMusicDBContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return MyMusicDBContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        async Task<IEnumerable<Artist>> IArtistRepository.GetAllWithMusicsAsync()
        {
            return await MyMusicDBContext.Artists
              .Include(a => a.Musics)
              .ToListAsync();
        }

        Task<Artist> IArtistRepository.GetWithMusicsByIdAsync(int id)
        {
            return MyMusicDBContext.Artists
          .Include(a => a.Musics)
         .SingleOrDefaultAsync(a => a.Id == id);
        }


    }
}

