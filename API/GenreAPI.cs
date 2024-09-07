using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

namespace TunaPiano.API
{
    public class GenreAPI
    {
        public static void Map(WebApplication app)
        {
            // CREATE A GENRE
            app.MapPost("/genres", (TunaPianaDBContext db, Genre genre) =>
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return Results.Created($"/api/genres/{genre.Id}", genre);
            });

            // DELETE A GENRE
            app.MapDelete("/genres/{id}", (TunaPianaDBContext db, int id) =>
            {
                Genre genre = db.Genres.FirstOrDefault(g => g.Id == id);
                if (genre == null)
                {
                    return Results.NotFound();
                }
                db.Genres.Remove(genre);
                db.SaveChanges();
                return Results.NoContent();
            });

            // UPDATE A GENRE
            app.MapPut("/genres/{id}", (TunaPianaDBContext db, int id, Genre genre) =>
            {
                Genre genreToUpdate = db.Genres.SingleOrDefault(g => g.Id == id);
                if (genreToUpdate == null)
                {
                    return Results.NotFound();
                }
                genreToUpdate.Description = genre.Description;

                db.SaveChanges();
                return Results.Ok(genreToUpdate);
            });

            // GET ALL GENRES
            app.MapGet("/genres", (TunaPianaDBContext db) =>
            {
                return db.Genres.ToList();
            });

            // GET GENRE BY ID WITH ASSOCIATED SONGS
            app.MapGet("/genres/{id}", async (TunaPianaDBContext db, int id) =>
            {
                Genre genre = await db.Genres
                .Include(g => g.SongGenres)
                    .ThenInclude(g => g.Song)
                .FirstOrDefaultAsync(g => g.Id == id);

                if (genre == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(genre);
            });
        }
    }
}
