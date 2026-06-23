
namespace Bridge.Solution.Entities
{
    public interface IPlatform
    {
        int Volume { get; }
        bool PlaybackState { get; }
        int CurrentTrackId { get; }

        void SetVolume(int value);
        void Pause();
        void Resume();
        void NextSong();
        void PreviousSong();
    }
}
