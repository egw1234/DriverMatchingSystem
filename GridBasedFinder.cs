using System;
using System.Collections.Generic;
using System.Linq;
using DriverMatching.Core.Models;

namespace DriverMatching.Algorithms.Models
{
    public class GridBasedFinder : INearestDriversFinder
    {
        public List<NearbyDriver> FindNearest(Order order, List<Driver> drivers, int count = 5)
        {
            var results = new List<NearbyDriver>();

            foreach (var driver in drivers)
            {
                var distance = DistanceCalculator.CalculateDistance(driver, order);
                results.Add(new NearbyDriver(driver, distance));
            }

            results.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            return results.Take(count).ToList();
        }
    }
}