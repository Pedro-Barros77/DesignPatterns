using Adapter.Solution.Models;
using DesignPatterns.StructuralPatterns.Adapter.Solution.Models;

namespace Adapter.Solution
{
    public class ImperialToMetricAdapter : IDistanceTracker
    {
        private readonly DistanceTracker _tracker = new();

        public int TotalDistanceInMeters => _tracker.TotalDistanceInMeters;

        public void AddDistanceInMeters(int distanceInFt)
        {
            int convertedValue = ConvertFeetToMeters(distanceInFt);
            _tracker.AddDistanceInMeters(convertedValue);
        }

        public void AddDistanceInKilometers(float distanceInMi)
        {
            float convertedValue = ConvertMilesToKilometers(distanceInMi);
            _tracker.AddDistanceInKilometers(convertedValue);
        }

        public void Reset()
        {
            _tracker.Reset();
        }

        private static int ConvertFeetToMeters(int distanceInFeet)
        {
            return (int)(distanceInFeet * 0.3048);
        }

        private static float ConvertMilesToKilometers(float distanceInMiles)
        {
            return distanceInMiles * 1.60934f;
        }
    }
}
