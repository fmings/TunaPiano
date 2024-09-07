using TunaPiano.Migrations;
using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;

namespace TunaPiano.API
{
    public class SongAPI
    {
        public static void Map(WebApplication app)
        {
            // CREATE A SONG
            app.MapPost("/songs", (TunaPianaDBContext db, Song song) =>
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return Results.Created($"/api/song/{song.Id}", song);
            });

            // DELETE A SONG
            app.MapDelete("/song/{id}", (TunaPianaDBContext db, int id) =>
            {
                Song song = db.Songs.FirstOrDefault(s => s.Id == id);
                if (song == null)
                {
                    return Results.NotFound();
                }
                db.Songs.Remove(song);
                db.SaveChanges();
                return Results.NoContent();
            });

            // UPDATE A SONG
            app.MapPut("/songs/{id}", (TunaPianaDBContext db, int id, Song song) =>
            {
                Song songToUpdate = db.Songs.SingleOrDefault(s => s.Id == id);
                if (songToUpdate == null)
                {
                    return Results.NotFound();
                }
                songToUpdate.Title = song.Title;
                songToUpdate.ArtistId = song.ArtistId;
                songToUpdate.Album = song.Album;
                songToUpdate.Length = song.Length;

                db.SaveChanges();
                return Results.Ok(songToUpdate);
            });

            // GET ALL SONGS
            app.MapGet("/songs", (TunaPianaDBContext db) =>
            {
                return db.Songs.ToList();
            });

            // GET SONG BY ID WITH GENRE AND ARTIST DETAILS
            app.MapGet("/song/{id}", async (TunaPianaDBContext db, int id) =>
            {
                Song song = await db.Songs
                .Include(s => s.Artist)
                .Include(s => s.SongGenres)
                    .ThenInclude(sg => sg.Genre)
                .FirstOrDefaultAsync(s => s.Id == id);

                if (song == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(song);
            });

        }
    }
}
