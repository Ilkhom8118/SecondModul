using Music_1_Variant.Service;
using Music_1_Variant.Service.DTOs;

namespace Music_1_Variant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMusicService service = new MusicService();
            var obj = new MusicDto()
            {
                AuthorName = "Ilkhom"
            };
            service.AddMusic(obj);
        }
    }
}
