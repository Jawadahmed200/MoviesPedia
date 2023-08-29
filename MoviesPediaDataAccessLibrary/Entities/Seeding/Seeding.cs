using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPediaDataAccessLibrary.Entities.Seeding
{
    public class Seeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelLJackson = new Actor()
            {
                Id = 2,
                Name = "Samuel L. Jackson",
                DateOfBirth = new DateTime(1948, 12, 21),
                Fortune = 15000
            };
            var RobertDowneyJunior = new Actor()
            {
                Id = 3,
                Name = "Robert Downey Jr.",
                DateOfBirth = new DateTime(1965, 4, 4),
                Fortune = 18000
            };

            modelBuilder.Entity<Actor>().HasData(samuelLJackson, RobertDowneyJunior);



            var avengers = new Movie()
            {
                Id = 2,
                Title = "Avengers Endgame",
                ReleaseDate = new DateTime(2019, 4, 22)
            };
            var spiderManNWH = new Movie()
            {
                Id = 3,
                Title = "Spider-Man: No Way Home",
                ReleaseDate = new DateTime(2021, 12, 13)
            };
            var spiderManSpiderVerse2 = new Movie()
            {
                Id = 4,
                Title = "Spider-Man: Across the Spider-Verse (Part One)",
                ReleaseDate = new DateTime(2022, 10, 7)
            };

            modelBuilder.Entity<Movie>().HasData(avengers, spiderManNWH, spiderManSpiderVerse2);


            var avengersComment = new Comment()
            {
                Id = 2,
                Recommend = true,
                Content = "Very good!!!",
                MovieId = avengers.Id
            };
            var avengersComment2 = new Comment()
            {
                Id = 3,
                Recommend = true,
                Content = "I love it!",
                MovieId = avengers.Id
            };
            var NWHComment = new Comment()
            {
                Id = 4,
                Recommend = false,
                Content = "They shouldn't have done that",
                MovieId = spiderManNWH.Id
            };

            modelBuilder.Entity<Comment>().HasData(avengersComment, avengersComment2, NWHComment);


            // many to many with skipping (this is a little advanced)

            var tableMovieGenre = "GenreMovie";
            var genreIdProperty = "GenresId";
            var movieIdProperty = "MoviesId";

            var scienceFiction = 5;
            var animation = 6;

            modelBuilder.Entity(tableMovieGenre).HasData(
                new Dictionary<string, object>
                {
                    [genreIdProperty] = scienceFiction,
                    [movieIdProperty] = avengers.Id
                },

                new Dictionary<string, object>
                {
                    [genreIdProperty] = scienceFiction,
                    [movieIdProperty] = spiderManNWH.Id
                },

                new Dictionary<string, object>
                {
                    [genreIdProperty] = animation,
                    [movieIdProperty] = spiderManSpiderVerse2.Id
                }

                );

            // many-to-many without skipping

            var samuelLJacksonSpiderManNWH = new MovieActor
            {
                ActorId = samuelLJackson.Id,
                MovieId = spiderManNWH.Id,
                Order = 1,
                Character = "Nick Fury"
            };

            var samuelLJacksonAvengers = new MovieActor
            {
                ActorId = samuelLJackson.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "Nick Fury"
            };

            var robertDowneyJuniorAvengers = new MovieActor
            {
                ActorId = RobertDowneyJunior.Id,
                MovieId = avengers.Id,
                Order = 1,
                Character = "Iron Man"
            };

            modelBuilder.Entity<MovieActor>().
                HasData(samuelLJacksonSpiderManNWH,
                samuelLJacksonAvengers,
                robertDowneyJuniorAvengers);

        }
    }
}
