using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Solution.Entities
{
    public class AndroidPlatform : IPlatform
    {
        private int AndroidVolume { get; set; }
        private bool AndroidPlaybackState { get; set; }
        private int AndroidCurrentTrackId { get; set; }
        
        public int Volume => AndroidVolume;
        public bool PlaybackState => AndroidPlaybackState;
        public int CurrentTrackId => AndroidCurrentTrackId;

        public AndroidPlatform()
        {
            AndroidVolume = 80;
            AndroidPlaybackState = true;
            AndroidCurrentTrackId = 1;
        }

        public void SetVolume(int value)
        {
            AndroidVolume = Math.Clamp(value, 0, 100);
        }

        public void NextSong()
        {
            AndroidCurrentTrackId += 1;
        }

        public void PreviousSong()
        {
            AndroidCurrentTrackId = Math.Max(AndroidCurrentTrackId - 1, 1);
        }

        public void Pause()
        {
            AndroidPlaybackState = false;
        }

        public void Resume()
        {
            AndroidPlaybackState = true;
        }
    }
}
