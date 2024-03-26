using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden {
    internal class Location {
        public double latitude { get; }
        public double longitude { get; }

        public Location(double latitude, double longitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double DistanceTo(Location otherLocation) {
            const double earthRadius = 6371;

            double lat1 = DegreeToRadian(latitude);
            double lon1 = DegreeToRadian(longitude);
            double lat2 = DegreeToRadian(otherLocation.latitude);
            double lon2 = DegreeToRadian(otherLocation.longitude);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadius * c;
            return distance;
        }

        private double DegreeToRadian(double angle) {
            return Math.PI * angle / 180.0;
        }

        public override string ToString() {
            return $"Latitude: {latitude}, Longitude: {longitude}";
        }
    }
}
