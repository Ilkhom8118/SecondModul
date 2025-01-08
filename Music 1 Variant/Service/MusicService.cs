using Music_1_Variant.DataAccess.Entity;
using Music_1_Variant.Repository;
using Music_1_Variant.Service.DTOs;

namespace Music_1_Variant.Service;

public class MusicService : IMusicService
{
    private readonly IMusicRepo musics;
    public MusicService()
    {
        musics = new MusicRepo();
    }
    private Music ConvertToEntity(MusicBaseDto obj)
    {
        return new Music()
        {
            MB = obj.MB,
            Name = obj.Name,
            AuthorName = obj.AuthorName,
            Description = obj.Description,
            QuentityLikes = obj.QuentityLikes
        };
    }
    private Music ConvertToEntity(MusicDto obj)
    {
        return new Music()
        {
            Id = obj.Id,
            MB = obj.MB,
            Name = obj.Name,
            AuthorName = obj.AuthorName,
            Description = obj.Description,
            QuentityLikes = obj.QuentityLikes
        };
    }
    private MusicDto ConvertToDto(Music obj)
    {
        return new MusicDto()
        {
            Id = obj.Id,
            MB = obj.MB,
            Name = obj.Name,
            AuthorName = obj.AuthorName,
            Description = obj.Description,
            QuentityLikes = obj.QuentityLikes
        };
    }
    public Music AddMusic(MusicBaseDto music)
    {
        var obj = ConvertToEntity(music);
        musics.AddMusic(obj);
        return obj;
    }

    public void DeleteMusic(Guid id)
    {
        musics.DeleteMsuic(id);
    }

    public List<MusicDto> GetAllMusicAboveSize(double minSize)
    {
        var list = new List<MusicDto>();
        var aboveSize = musics.GetAllMusics();
        foreach (var music in aboveSize)
        {
            if (music.MB > minSize)
            {
                var convert = ConvertToDto(music);
                list.Add(convert);
            }
        }
        return list;
    }

    public List<MusicDto> GetAllMusicBeloveSize(double minSize)
    {
        var list = new List<MusicDto>();
        var beloveSize = musics.GetAllMusics();
        foreach (var music in beloveSize)
        {
            if (music.MB < minSize)
            {

                var convert = ConvertToDto(music);
                list.Add(convert);
            }
        }
        return list;
    }

    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        var list = new List<MusicDto>();
        var authorAllMusic = musics.GetAllMusics();
        foreach (var music in authorAllMusic)
        {
            if (music.AuthorName == name)
            {
                var convert = ConvertToDto(music);
                list.Add(convert);
            }
        }
        return list;
    }

    public List<MusicDto> GetAllMusics()
    {
        var list = new List<MusicDto>();
        var getAll = musics.GetAllMusics();
        foreach (var music in getAll)
        {
            var convert = ConvertToDto(music);
            list.Add(convert);
        }
        return list;
    }

    public List<string> GetAllUniqueAuthors()
    {
        var list = new List<string>();
        foreach (var music in GetAllMusics())
        {
            if (!list.Contains(music.AuthorName))
            {
                list.Add(music.AuthorName);
            }
        }
        return list;
    }

    public MusicDto GetMostLikedMusic()
    {
        var musicDto = new MusicDto();
        foreach (var like in GetAllMusics())
        {
            if (like.QuentityLikes > musicDto.QuentityLikes)
            {
                musicDto.QuentityLikes = like.QuentityLikes;
            }
        }
        return musicDto;
    }

    public MusicDto GetMusicById(Guid id)
    {
        var musicDto = new MusicDto();
        foreach (var music in GetAllMusics())
        {
            if (music.Id == id)
            {
                musicDto = music;
            }
            else
            {
                throw new Exception("Not Find");
            }
        }
        return musicDto;
    }

    public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        var list = new List<MusicDto>();
        foreach (var music in GetAllMusics())
        {
            if (music.Description.Contains(keyword))
            {
                list.Add(music);
            }
        }
        return list;
    }

    public MusicDto GetMusicByName(string name)
    {
        var music = new MusicDto();
        foreach (var musicName in GetAllMusics())
        {
            if (musicName.Name == name)
            {
                music.Name = musicName.Name;
            }
        }
        return music;
    }

    public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        var list = new List<MusicDto>();
        foreach (var range in GetAllMusics())
        {
            if (range.QuentityLikes > minLikes && range.QuentityLikes < maxLikes)
            {
                list.Add(range);
            }
        }
        return list;
    }

    public List<MusicDto> GetTopMostLikedMusic(int count)
    {
        var list = new List<MusicDto>();
        foreach (var like in GetAllMusics())
        {
            if (like.QuentityLikes > count)
            {
                list.Add(like);
            }
        }
        return list;
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        double total = 0;
        foreach (var name in GetAllMusics())
        {
            if (name.AuthorName == authorName)
            {
                total += name.MB;
            }
        }
        return total;
    }

    public void UpdateMusic(MusicDto music)
    {
        musics.UpdatedMusic(ConvertToEntity(music));
    }
}
