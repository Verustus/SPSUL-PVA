using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snowflakes {
    internal class Program {
        private static Random rnd = new Random();
        private static List<string> lines = new List<string>();
        private static int windowWidth;
        private static int windowHeight;

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;

            var cts1 = new CancellationTokenSource();
            AsyncRepeatingTask(() => updateSnowflakes(), 200, cts1.Token);

            var cts2 = new CancellationTokenSource();
            AsyncRepeatingTask(() => updateScreen(), 100, cts2.Token);

            while (true) {}
        }

        private static void updateScreen(bool size = true) {
            if (size) {
                if (Console.WindowWidth != windowWidth || Console.WindowHeight != windowHeight) {
                    windowWidth = Console.WindowWidth;
                    windowHeight = Console.WindowHeight;
                    updateSnowflakes(true);

                    for (int i = 0; i < windowHeight; i++) Console.WriteLine(lines[i]);
                }
            } else for (int i = 0; i < windowHeight; i++) Console.WriteLine(lines[i]);
        }
        private static void updateSnowflakes(bool updateAll = false) {
            if (!updateAll) lines.RemoveAt(lines.Count - 1);
            string line = "";
            for (int i = 0; i < (!updateAll ? 1 : windowHeight); i++) {
                for (int j = 0; j < windowWidth; j++) {
                    line += getSnowflake() ? '*' : ' ';
                }
                lines.Insert(0, line);
            }
            if (!updateAll) updateScreen(false);
        }
        private static bool getSnowflake() { return rnd.Next(0, 20) == 0; }

        static void AsyncRepeatingTask(Action action, int milliseconds, CancellationToken token) {
            if (action == null) return;
            Task.Run(async () => {
                while (!token.IsCancellationRequested) {
                    action();
                    await Task.Delay(TimeSpan.FromMilliseconds(milliseconds), token);
                }
            }, token);
        }
    }
}
