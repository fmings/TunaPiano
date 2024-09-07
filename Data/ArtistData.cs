using TunaPiano.Models;

namespace TunaPiano.Data
{
    public class ArtistData
    {
        public static List<Artist> Artists = new List<Artist>
        {
            new Artist {
                Id = 1,
                Name = "Suki Waterhouse",
                Age = 32,
                Bio = "Alice Suki Waterhouse is an English singer-songwriter, actress and model. The indie pop artist released her debut studio album I Can't Let Go and debut extended play Milk Teeth in 2022.",
            },

            new Artist {
                Id = 2,
                Name = "Chappell Roan",
                Age = 26,
                Bio = "Kayleigh Rose Amstutz, known professionally as Chappell Roan, is an American singer and songwriter. Working with collaborator Dan Nigro, the majority of her music is inspired by 1980s synth-pop and early 2000s pop hits.",
            },

            new Artist {
                Id = 3,
                Name = "Halsey",
                Age = 29,
                Bio = "Ashley Nicolette Frangipane, known professionally as Halsey, is an American singer, songwriter, and actress.",
            },

            new Artist {
                Id = 4,
                Name = "Cage the Elephant",
                Age = 18,
                Bio = "Cage the Elephant is an American rock band from Bowling Green, Kentucky, that formed in mid-2006. Since their formation, the band has gained a massive following in the US as well as the UK and Canada for their sound and their high-energy live performances.",
            },

            new Artist {
                Id = 5,
                Name = "Glass Animals",
                Age = 14,
                Bio = "How old are Glass Animals?\r\nGlass Animals - Wikipedia\r\nGlass Animals are an English indie rock band formed in Oxford in 2010. The band's line-up consists of Dave Bayley (vocals, guitar, keyboards, drums, songwriting), Drew MacFarlane (guitar, keyboards, backing vocals), Edmund Irwin-Singer (bass, keyboards, backing vocals), and Joe Seaward (drums).",
            },
        };
    }
}
