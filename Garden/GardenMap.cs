using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden {
    internal class GardenMap {
        private List<Garden> gardens = new List<Garden>();

        public void AddGarden(Garden garden) {
            gardens.Add(garden);
        }

        public Garden GetGardenByName(string name) {
            foreach (Garden garden in gardens) {
                if (garden.name == name) {
                    return garden;
                }
            }

            return null;
        }
        public List<Garden> GetGardensClosestToLocation(Location location) {
            List<Garden> byDistance = new List<Garden>(gardens);

            byDistance.Sort((garden1, garden2) =>
                garden1.location.DistanceTo(location).CompareTo(garden2.location.DistanceTo(location))
            );

            return byDistance;
        }
        public List<Garden> GetGardensByOwner(Person person) {
            List<Garden> owned = new List<Garden>();

            foreach (Garden garden in gardens) {
                if (garden.owner == person) {
                    owned.Add(garden);
                }
            }

            return owned;
        }
    }
}
