using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace Bridge.Solution.Entities
{
    public class Earbud : IEarphone
    {
        private IPlatform _platform;
        public Earbud(IPlatform platform)
        {
            _platform = platform;
        }

        public int GetVolume() => _platform.Volume;

        public void IncreaseVolume()
        {
            int oldVolume = _platform.Volume;
            _platform.SetVolume(_platform.Volume + 5);
            int newVolume = _platform.Volume;
            WriteColored(new TextItem("- Usuário deslizou para cima: Volume "), new($"{oldVolume}", ConsoleColor.Yellow), new(" => "), new($"{newVolume}", ConsoleColor.Green, 1));
        }

        public void DecreaseVolume()
        {
            int oldVolume = _platform.Volume;
            _platform.SetVolume(_platform.Volume - 5);
            int newVolume = _platform.Volume;
            WriteColored(new TextItem("- Usuário deslizou para baixo: Volume "), new($"{oldVolume}", ConsoleColor.Yellow), new(" => "), new($"{newVolume}", ConsoleColor.Green, 1));
        }

        public int GetCurrentTrackId() => _platform.CurrentTrackId;

        public void NextSong()
        {
            int oldTrackId = _platform.CurrentTrackId;
            _platform.NextSong();
            int newTrackId = _platform.CurrentTrackId;
            WriteColored(new TextItem("- Usuário realizou um toque duplo: Música atual "), new($"{oldTrackId}", ConsoleColor.Yellow), new(" => "), new($"{newTrackId}", ConsoleColor.Green, 1));
        }

        public void PreviousSong()
        {
            int oldTrackId = _platform.CurrentTrackId;
            _platform.PreviousSong();
            int newTrackId = _platform.CurrentTrackId;
            WriteColored(new TextItem("- Usuário realizou um toque triplo: Música atual "), new($"{oldTrackId}", ConsoleColor.Yellow), new(" => "), new($"{newTrackId}", ConsoleColor.Green, 1));
        }

        public void TogglePlayback()
        {
            bool oldState = _platform.PlaybackState;
            bool newState = !_platform.PlaybackState;

            WriteColored(new TextItem("- Usuário tocou no Earbud: "), new(oldState ? "Play" : "Pause", ConsoleColor.Yellow), new(" => "), new(newState ? "Play" : "Pause", ConsoleColor.Green, 1));

            if (_platform.PlaybackState)
                _platform.Pause();
            else
                _platform.Resume();
        }

        public bool GetPlaybackState() => _platform.PlaybackState;

        public void SwitchPlatform(IPlatform platform)
        {
            _platform = platform;
        }
    }
}
