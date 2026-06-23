namespace Adapter.Problem.Models
{
    public class DistanceTracker
    {
        public int TotalDistanceInMeters { get; private set; }

        public void AddDistanceInMeters(int distanceInM)
        {
            TotalDistanceInMeters += Math.Clamp(distanceInM, 0, int.MaxValue - TotalDistanceInMeters);
        }

        public void AddDistanceInKilometers(float distanceInKm)
        {
            var meters = (int)(distanceInKm * 1000);
            TotalDistanceInMeters += Math.Clamp(meters, 0, int.MaxValue - TotalDistanceInMeters);
        }

        public void Reset()
        {
            TotalDistanceInMeters = 0;
        }
    }
}
