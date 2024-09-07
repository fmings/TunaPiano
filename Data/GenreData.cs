using TunaPiano.Models;

namespace TunaPiano.Data
{
    public class GenreData
    {
        public static List<Genre> Genres = new List<Genre> 
        {
            new Genre
            {
                Id = 100,
                Description = "Rock",
            },

            new Genre
            {
                Id = 101,
                Description = "Indie Pop",
            },

            new Genre
            {
                Id = 102,
                Description = "Alternative/Indie",
            },

            new Genre
            {
                Id = 103,
                Description = "Pop",
            }
        };
    }
}
