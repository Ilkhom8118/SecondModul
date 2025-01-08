using Music_1_Variant.DataAccess.Entity;

namespace Music_1_Variant.Repository;

public interface IMusicRepo
{
    Music AddMusic(Music obj);
    void DeleteMsuic(Guid id);
    void UpdatedMusic(Music obj);
    List<Music> GetAllMusics();
    Music GetById(Guid id);
}