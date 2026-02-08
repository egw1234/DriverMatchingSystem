using System;
using System.Collections.Generic;
using System.Linq;
using DriverMatching.Core.Models;

namespace DriverMatching.Algorithms.Models
{
    public class PriorityQueueFinder : INearestDriversFinder
    {
        public List<NearbyDriver> FindNearest(Order order, List<Driver> drivers, int count = 5)
        {
            var queue = new SortedSet<(double Distance, int DriverId, Driver Driver)>(
                Comparer<(double Distance, int DriverId, Driver Driver)>.Create(
                    (a, b) =>
                    {
                        int result = a.Distance.CompareTo(b.Distance);
                        if (result == 0)
                            result = a.DriverId.CompareTo(b.DriverId);
                        return result;
                    }));

            foreach (var driver in drivers)
            {
                var distance = DistanceCalculator.CalculateDistance(driver, order);

                if (queue.Count < count)
                {
                    queue.Add((distance, driver.Id, driver));
                }
                else if (distance < queue.Max.Distance)
                {
                    queue.Remove(queue.Max);
                    queue.Add((distance, driver.Id, driver));
                }
            }

            return queue.Select(item => new NearbyDriver(item.Driver, item.Distance)).ToList();
        }
    }
}