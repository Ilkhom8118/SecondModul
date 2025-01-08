using Music_1_Variant.DataAccess.Entity;
using System.Text.Json;

namespace Music_1_Variant.Repository;

public class MusicRepo : IMusicRepo
{
    private string Path;
    private List<Music> musics;
    public MusicRepo()
    {
        musics = new List<Music>();
        Path = "../../../DataAccess/Data/Music.json";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
    }
    private void SaveIformation(List<Music> obj)
    {
        var json = JsonSerializer.Serialize(musics);
        File.WriteAllText(Path, json);
    }
    private List<Music> GetAll()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<Music>>(json);
        return file;
    }
    public Music AddMusic(Music obj)
    {
        musics.Add(obj);
        SaveIformation(musics);
        return obj;
    }

    public void DeleteMsuic(Guid id)
    {
        var guId = GetById(id);
        musics.Remove(guId);
        SaveIformation(musics);
    }

    public List<Music> GetAllMusics()
    {
        return GetAll();
    }

    public Music GetById(Guid id)
    {
        foreach (var music in musics)
        {
            if (music.Id == id)
            {
                return music;
            }
        }
        throw new Exception("Not Find!");
    }

    public void UpdatedMusic(Music obj)
    {
        var id = GetById(obj.Id);
        musics[musics.IndexOf(id)] = obj;
    }
}
