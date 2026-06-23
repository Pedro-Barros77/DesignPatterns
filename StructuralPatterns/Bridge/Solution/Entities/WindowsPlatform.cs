using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Solution.Entities
{
    public class WindowsPlatform : IPlatform
    {
        private int WindowsVolume { get; set; }
        private bool WindowsPlaybackState { get; set; }
        private int WindowsCurrentTrackId { get; set; }
        
        public int Volume => WindowsVolume;
        public bool PlaybackState => WindowsPlaybackState;
        public int CurrentTrackId => WindowsCurrentTrackId;

        public WindowsPlatform()
        {
            WindowsVolume = 80;
            WindowsPlaybackState = true;
            WindowsCurrentTrackId = 1;
        }

        public void SetVolume(int value)
        {
            WindowsVolume = Math.Clamp(value, 0, 100);
        }

        public void NextSong()
        {
            WindowsCurrentTrackId += 1;
        }

        public void PreviousSong()
        {
            WindowsCurrentTrackId = Math.Max(WindowsCurrentTrackId - 1, 1);
        }

        public void Pause()
        {
            WindowsPlaybackState = false;
        }

        public void Resume()
        {
            WindowsPlaybackState = true;
        }
    }
}
