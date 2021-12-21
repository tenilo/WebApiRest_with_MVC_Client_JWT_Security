using AutoMapper;
using MyMusic.API.Resources;
using MyMusic.Core.Models;

namespace MyMusic.API.Mapping
{
    public class MappingProfile : Profile
    {
   
        public MappingProfile()
        {
            // mapping de la base de données vers resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();
            CreateMap<Music, SaveMusicResource>();
            CreateMap<Artist, SaveArtistResource>();
            CreateMap<Composer, ComposerResourse>();
            CreateMap<Composer, SaveComposerResource>();
            CreateMap<User, UserResource>();
            

            // mapping de la resource vers la base de données
            CreateMap<MusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
            CreateMap<SaveMusicResource, Music>();
            CreateMap<SaveArtistResource, Artist>();
            CreateMap<ComposerResourse, Composer>();
            CreateMap<SaveComposerResource, Composer>();
            CreateMap<UserResource, User>();
        }
    }
}
