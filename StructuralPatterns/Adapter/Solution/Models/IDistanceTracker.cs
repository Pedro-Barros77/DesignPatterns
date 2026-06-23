using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralPatterns.Adapter.Solution.Models
{
    public interface IDistanceTracker
    {
        int TotalDistanceInMeters { get; }
        void AddDistanceInMeters(int distanceInM);
        void AddDistanceInKilometers(float distanceInKm);
        void Reset();
    }
}
