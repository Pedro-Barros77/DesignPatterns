using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace Bridge.Problem.Entities
{
    public class EarbudForAndroid : Earphone
    {
        private int AndroidVolume { get; set; }
        private bool AndroidPlaybackState { get; set; }
        private int AndroidCurrentTrackId { get; set; }
        public EarbudForAndroid()
        {
            AndroidVolume = 80;
            AndroidPlaybackState = true;
            AndroidCurrentTrackId = 1;
        }

        public void OnGestureSlideUp()
        {
            int oldVolume = AndroidVolume;
            IncreaseVolume(5);
            int newVolume = AndroidVolume;
            WriteColored(new TextItem("- Usuário deslizou para cima: Volume "), new($"{oldVolume}", ConsoleColor.Yellow), new(" => "), new($"{newVolume}", ConsoleColor.Green, 1));
        }
        public void OnGestureSlideDown()
        {
            int oldVolume = AndroidVolume;
            DecreaseVolume(5);
            int newVolume = AndroidVolume;
            WriteColored(new TextItem("- Usuário deslizou para baixo: Volume "), new($"{oldVolume}", ConsoleColor.Yellow), new(" => "), new($"{newVolume}", ConsoleColor.Green, 1));
        }
        public void OnTouch()
        {
            bool oldState = AndroidPlaybackState;
            bool newState = !AndroidPlaybackState;

            WriteColored(new TextItem("- Usuário tocou no Earbud: "), new(oldState ? "Play" : "Pause", ConsoleColor.Yellow), new(" => "), new(newState ? "Play" : "Pause", ConsoleColor.Green, 1));

            if (AndroidPlaybackState)
                Pause();
            else
                Resume();
        }
        public void OnDoubleTap()
        {
            int oldTrackId = AndroidCurrentTrackId;
            NextSong();
            int newTrackId = AndroidCurrentTrackId;
            WriteColored(new TextItem("- Usuário realizou um toque duplo: Música atual "), new($"{oldTrackId}", ConsoleColor.Yellow), new(" => "), new($"{newTrackId}", ConsoleColor.Green, 1));
        }
        public void OnTripleTap()
        {
            int oldTrackId = AndroidCurrentTrackId;
            PreviousSong();
            int newTrackId = AndroidCurrentTrackId;
            WriteColored(new TextItem("- Usuário realizou um toque triplo: Música atual "), new($"{oldTrackId}", ConsoleColor.Yellow), new(" => "), new($"{newTrackId}", ConsoleColor.Green, 1));
        }
        protected override void IncreaseVolume(int value)
        {
            AndroidVolume = Math.Clamp(AndroidVolume + value, 0, 100);
        }
        protected override void DecreaseVolume(int value)
        {
            AndroidVolume = Math.Clamp(AndroidVolume - value, 0, 100);
        }
        protected override int GetVolume() => AndroidVolume;
        protected override bool GetPlaybackState() => AndroidPlaybackState;
        protected override void Pause()
        {
            AndroidPlaybackState = false;
        }
        protected override void Resume()
        {
            AndroidPlaybackState = true;
        }
        protected override void NextSong()
        {
            AndroidCurrentTrackId += 1;
        }
        protected override void PreviousSong()
        {
            AndroidCurrentTrackId = Math.Max(AndroidCurrentTrackId - 1, 1);
        }
    }
}
