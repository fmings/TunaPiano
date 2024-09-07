using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

namespace TunaPiano.API
{
    public class ArtistAPI
    {
        public static void Map(WebApplication app)
        {
            // CREATE AN ARTIST
            app.MapPost("/artists", (TunaPianaDBContext db, Artist artist) =>
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return Results.Created($"/api/artist/{artist.Id}", artist);
            });

            // DELETE AN ARTIST
            app.MapDelete("/artists/{id}", (TunaPianaDBContext db, int id) =>
            {
                Artist artist = db.Artists.FirstOrDefault(a => a.Id == id);
                if (artist == null)
                {
                    return Results.NotFound();
                }
                db.Artists.Remove(artist);
                db.SaveChanges();
                return Results.NoContent();
            });

            // UPDATE AN ARTIST
            app.MapPut("/artists/{id}", (TunaPianaDBContext db, int id, Artist artist) =>
            {
                Artist artistToUpdate = db.Artists.SingleOrDefault(a => a.Id == id);
                if (artistToUpdate == null)
                {
                    return Results.NotFound();
                }
                artistToUpdate.Name = artist.Name;
                artistToUpdate.Age = artist.Age;
                artistToUpdate.Bio = artist.Bio;

                db.SaveChanges();
                return Results.Ok(artistToUpdate);
            });

            // GET ALL ARTISTS
            app.MapGet("/artists", (TunaPianaDBContext db) =>
            {
                return db.Artists.ToList();
            });

            // GET ARTIST BY ID WITH ASSOCIATED SONGS
            app.MapGet("/artist/{id}", async (TunaPianaDBContext db, int id) =>
            {
                Artist artist = await db.Artists
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(s => s.Id == id);

                if (artist == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(artist);
            });
        }
    }
}
