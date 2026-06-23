using Bridge.Problem.Entities;
using static DesignPatterns.ConsoleUtils;

namespace Bridge.Problem
{
    public static class MusicPlayerService
    {
        public async static Task HandleMusic()
        {
            WriteSeparator();

            WriteColored(new TextItem("Iniciando música no sistema android", 2));

            await Task.Delay(1000);

            WriteColored(new TextItem("Headphone: ", ConsoleColor.Blue, 2));
            await Task.Delay(500);
            var androidHeadphone = new HeadphoneForAndroid();
            androidHeadphone.OnScrollWheelDown();
            await Task.Delay(500);
            androidHeadphone.OnArrowRightButtonPress();
            await Task.Delay(500);
            androidHeadphone.OnScrollWheelUp();
            await Task.Delay(500);
            androidHeadphone.OnOkButtonPress();

            WriteColored("", 1);
            WriteSeparator();

            await Task.Delay(1000);

            WriteColored(new TextItem("Earbud: ", ConsoleColor.Cyan, 2));
            await Task.Delay(500);
            var androidEarbud = new EarbudForAndroid();
            androidEarbud.OnGestureSlideDown();
            await Task.Delay(500);
            androidEarbud.OnDoubleTap();
            await Task.Delay(500);
            androidEarbud.OnGestureSlideUp();
            await Task.Delay(500);
            androidEarbud.OnTouch();

            WriteColored("", 1);
            WriteSeparator();

            await Task.Delay(1000);

            WriteColored(new TextItem("Iniciando música no sistema windows", 2));

            await Task.Delay(1000);

            WriteColored(new TextItem("Headphone: ", ConsoleColor.Blue, 2));
            await Task.Delay(500);
            var windowsHeadphone = new HeadphoneForWindows();
            windowsHeadphone.OnScrollWheelDown();
            await Task.Delay(500);
            windowsHeadphone.OnArrowRightButtonPress();
            await Task.Delay(500);
            windowsHeadphone.OnScrollWheelUp();
            await Task.Delay(500);
            windowsHeadphone.OnOkButtonPress();

            WriteColored("", 1);
            WriteSeparator();

            await Task.Delay(1000);

            WriteColored(new TextItem("Earbud: ", ConsoleColor.Cyan, 2));
            await Task.Delay(500);
            var windowsEarbud = new EarbudForWindows();
            windowsEarbud.OnGestureSlideDown();
            await Task.Delay(500);
            windowsEarbud.OnDoubleTap();
            await Task.Delay(500);
            windowsEarbud.OnGestureSlideUp();
            await Task.Delay(500);
            windowsEarbud.OnTouch();
        }
    }
}
