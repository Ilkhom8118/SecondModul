using Music_1_Variant.DataAccess.Entity;
using Music_1_Variant.Service.DTOs;

namespace Music_1_Variant.Service;

public interface IMusicService
{
    Music AddMusic(MusicBaseDto music);
    void DeleteMusic(Guid id);
    void UpdateMusic(MusicDto music);
    MusicDto GetMusicById(Guid id);
    List<MusicDto> GetAllMusics();
    List<MusicDto> GetAllMusicByAuthorName(string name);
    MusicDto GetMostLikedMusic();
    MusicDto GetMusicByName(string name);
    List<MusicDto> GetAllMusicAboveSize(double minSize);
    List<MusicDto> GetAllMusicBeloveSize(double minSize);
    List<MusicDto> GetTopMostLikedMusic(int count);
    List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
    List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}