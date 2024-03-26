using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden {
    internal class Person {
        public static List<ulong> ids = new List<ulong>();
        public string name { get; }
        public byte age { get; }
        public ulong id { get; }

        public Person(string name, byte age) {
            this.name = name;
            this.age = age;
            id = NextId();
            ids.Add(id);
        }

        private ulong NextId() {
            ids.Sort();

            for (int i = 1; i < ids.Count; i++) {
                if (ids[i] - ids[i - 1] > 1) {
                    return ids[i - 1] + 1;
                }
            }

            return 0;
        }

        public void Death() {
            ids.Remove(id);
        }
}
}
