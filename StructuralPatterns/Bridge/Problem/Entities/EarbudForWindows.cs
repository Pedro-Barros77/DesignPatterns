using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace Bridge.Problem.Entities
{
    public class EarbudForWindows : Earphone
    {
        private int WindowsVolume { get; set; }
        private bool WindowsPlaybackState { get; set; }
        private int WindowsCurrentTrackId { get; set; }
        public EarbudForWindows()
        {
            WindowsVolume = 80;
            WindowsPlaybackState = true;
            WindowsCurrentTrackId = 1;
        }

        public void OnGestureSlideUp()
        {
            int oldVolume = WindowsVolume;
            IncreaseVolume(5);
            int newVolume = WindowsVolume;
            WriteColored(new TextItem("- Usuário deslizou para cima: Volume "), new($"{oldVolume}", ConsoleColor.Yellow), new(" => "), new($"{newVolume}", ConsoleColor.Green, 1));
        }
        public void OnGestureSlideDown()
        {
            int oldVolume = WindowsVolume;
            DecreaseVolume(5);
            int newVolume = WindowsVolume;
            WriteColored(new TextItem("- Usuário deslizou para baixo: Volume "), new($"{oldVolume}", ConsoleColor.Yellow), new(" => "), new($"{newVolume}", ConsoleColor.Green, 1));
        }
        public void OnTouch()
        {
            bool oldState = WindowsPlaybackState;
            bool newState = !WindowsPlaybackState;

            WriteColored(new TextItem("- Usuário tocou no Earbud: "), new(oldState ? "Play" : "Pause", ConsoleColor.Yellow), new(" => "), new(newState ? "Play" : "Pause", ConsoleColor.Green, 1));

            if (WindowsPlaybackState)
                Pause();
            else
                Resume();
        }
        public void OnDoubleTap()
        {
            int oldTrackId = WindowsCurrentTrackId;
            NextSong();
            int newTrackId = WindowsCurrentTrackId;
            WriteColored(new TextItem("- Usuário realizou um toque duplo: Música atual "), new($"{oldTrackId}", ConsoleColor.Yellow), new(" => "), new($"{newTrackId}", ConsoleColor.Green, 1));
        }
        public void OnTripleTap()
        {
            int oldTrackId = WindowsCurrentTrackId;
            PreviousSong();
            int newTrackId = WindowsCurrentTrackId;
            WriteColored(new TextItem("- Usuário realizou um toque triplo: Música atual "), new($"{oldTrackId}", ConsoleColor.Yellow), new(" => "), new($"{newTrackId}", ConsoleColor.Green, 1));
        }

        protected override void IncreaseVolume(int value)
        {
            WindowsVolume = Math.Clamp(WindowsVolume + value, 0, 100);
        }
        protected override void DecreaseVolume(int value)
        {
            WindowsVolume = Math.Clamp(WindowsVolume - value, 0, 100);
        }
        protected override int GetVolume() => WindowsVolume;
        protected override bool GetPlaybackState() => WindowsPlaybackState;
        protected override void Pause()
        {
            WindowsPlaybackState = false;
        }
        protected override void Resume()
        {
            WindowsPlaybackState = true;
        }
        protected override void NextSong()
        {
            WindowsCurrentTrackId += 1;
        }
        protected override void PreviousSong()
        {
            WindowsCurrentTrackId = Math.Max(WindowsCurrentTrackId - 1, 1);
        }
    }
}
