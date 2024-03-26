using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden {
    internal class Program {
        public static GardenMap gardenMap = new GardenMap();

        static void Main(string[] args) {
            List<Person> people = new List<Person>() {
                new Person("Jirka Novotný", 55),
                new Person("Ondra Očenáš", 19),
                new Person("Jakub Dlouhý", 23)
            };

            gardenMap.AddGarden(new Garden(
                new Location(50.633951, 13.805134),
                "ev.95",
                people[0]
            ));
            gardenMap.AddGarden(new Garden(
                new Location(50.633889, 13.805773),
                "ev.73",
                people[1]
            ));
            gardenMap.AddGarden(new Garden(
                new Location(50.633815, 13.807034),
                "ev.33",
                people[2]
            ));

            List<Garden> closest = gardenMap.GetGardensClosestToLocation(new Location(50.633465, 13.806579));

            foreach (Garden garden in closest) {
                Console.WriteLine(garden.name);
            }
        }
    }
}
