using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.MovieService
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDBContext _context;
        public MovieService(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async new Task AddAsync(Movie data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.Actor_Movies)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId.ActorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        //public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        //{
        //    var response = new NewMovieDropdownsVM()
        //    {
        //        Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
        //        Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
        //        Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
        //    };

        //    return response;
        //}

        //public async Task UpdateMovieAsync(NewMovieVM data)
        //{
        //    var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

        //    if (dbMovie != null)
        //    {
        //        dbMovie.Name = data.Name;
        //        dbMovie.Description = data.Description;
        //        dbMovie.Price = data.Price;
        //        dbMovie.ImageURL = data.ImageURL;
        //        dbMovie.CinemaId = data.CinemaId;
        //        dbMovie.StartDate = data.StartDate;
        //        dbMovie.EndDate = data.EndDate;
        //        dbMovie.MovieCategory = data.MovieCategory;
        //        dbMovie.ProducerId = data.ProducerId;
        //        await _context.SaveChangesAsync();
        //    }

        //    //Remove existing actors
        //    var existingActorsDb = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
        //    _context.Actor_Movies.RemoveRange(existingActorsDb);
        //    await _context.SaveChangesAsync();

        //    //Add Movie Actors
        //    foreach (var actorId in data.Actor_Movies)
        //    {
        //        var newActorMovie = new Actor_Movie()
        //        {
        //            MovieId = data.Id,
        //            ActorId = actorId.ActorId
        //        };
        //        await _context.Actor_Movies.AddAsync(newActorMovie);
        //    }
        //    await _context.SaveChangesAsync();
        //}
    }
}
