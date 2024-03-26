using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden {
    internal class Garden {
        public Location location { get; }
        public string name { get; }
        public Person owner { get; }
        private List<Plant> plants = new List<Plant>();

        public Garden(Location location, string name, Person owner) {
            this.location = location;
            this.name = name;
            this.owner = owner;
        }

    }
}
