using TunaPiano.Models;

namespace TunaPiano.Data
{
    public class SongData
    {
        public static List<Song> Songs = new List<Song>
        {
            new Song {
                Id = 200,
                Title = "Red Wine Supernova",
                ArtistId = 2,
                Album = "The Rise and Fall of a Midwest Princess",
                Length = 192,
            },

            new Song {
                Id = 201,
                Title = "Super Graphic Ultra Modern Girl",
                ArtistId = 2,
                Album = "The Rise and Fall of a Midwest Princess",
                Length = 183,
            },

            new Song {
                Id = 202,
                Title = "Control",
                ArtistId = 3,
                Album = "Badlands",
                Length = 214,
            },

            new Song {
                Id = 203,
                Title = "Bad At Love",
                ArtistId = 3,
                Album = "hopeless fountain kingdom",
                Length = 181,
            },

            new Song {
                Id = 204,
                Title = "Moves",
                ArtistId = 1,
                Album = "I Can't Let Go",
                Length = 193,
            },

            new Song {
                Id = 205,
                Title = "My Fun",
                ArtistId = 1,
                Album = "Blackout Drunk",
                Length = 162,
            },

            new Song {
                Id = 206,
                Title = "whatthehellishappening?",
                ArtistId = 5,
                Album = "I Love You So F***ing Much",
                Length = 224,
            },

            new Song {
                Id = 207,
                Title = "Heat Waves",
                ArtistId = 5,
                Album = "Dreamland",
                Length = 238,
            },

            new Song {
                Id = 208,
                Title = "Cigarette Daydreams",
                ArtistId = 4,
                Album = "Melophobia",
                Length = 208,
            },

            new Song {
                Id = 209,
                Title = "Sweetie Little Jean",
                ArtistId = 4,
                Album = "Tell Me I'm Pretty",
                Length = 224,
            },

            new Song {
                Id = 210,
                Title = "Ain't No Rest for the Wicked",
                ArtistId = 4,
                Album = "Cage the Elephant",
                Length = 175,
            },
        };
    }
}
