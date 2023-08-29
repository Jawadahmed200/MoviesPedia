using AutoMapper;
using MoviePedia.DTOs;
using MoviesPediaDataAccessLibrary.Entities;

namespace MoviePedia.Utilities
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(ent => ent.Genres, 
                dto => dto.MapFrom(field => field.Genres.Select(id => new Genre() { Id = id })));
            CreateMap<MovieActorCreationDTO, MovieActor>();
            CreateMap<CommentCreationDTO, Comment>();

        }

    }
}
