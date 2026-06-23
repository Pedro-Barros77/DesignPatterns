
namespace Bridge.Solution.Entities
{
    public interface IEarphone
    {
        int GetVolume();
        void IncreaseVolume();
        void DecreaseVolume();
        int GetCurrentTrackId();
        void NextSong();
        void PreviousSong();
        void TogglePlayback();
        bool GetPlaybackState();
        void SwitchPlatform(IPlatform platform);
    }
}
