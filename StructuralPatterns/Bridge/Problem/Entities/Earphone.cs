using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Problem.Entities
{
    public abstract class Earphone
    {
        protected abstract int GetVolume();
        protected abstract void IncreaseVolume(int value);
        protected abstract void DecreaseVolume(int value);
        protected abstract void NextSong();
        protected abstract void PreviousSong();
        protected abstract void Pause();
        protected abstract void Resume();
        protected abstract bool GetPlaybackState();
    }
}
