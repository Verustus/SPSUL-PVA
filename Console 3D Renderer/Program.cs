using System.Numerics;

namespace Console_3D_Renderer {
    internal class Program {
        private static float dir = 0.2f;

        public static void Main() {
            // krychle
            Vector3[] cube = {
                new Vector3(-2.5f, -2.5f, -2.5f),
                new Vector3(-2.5f, -2.5f,  2.5f),
                new Vector3( 2.5f, -2.5f,  2.5f),
                new Vector3( 2.5f, -2.5f, -2.5f),
                new Vector3(-2.5f,  2.5f, -2.5f),
                new Vector3(-2.5f,  2.5f,  2.5f),
                new Vector3( 2.5f,  2.5f,  2.5f),
                new Vector3( 2.5f,  2.5f, -2.5f)
            };
            
            // jehlan
            Vector3[] pyramid = {
                new Vector3(-2.5f, -2.5f, -2.5f),
                new Vector3(-2.5f, -2.5f,  2.5f),
                new Vector3( 2.5f, -2.5f,  2.5f),
                new Vector3( 2.5f, -2.5f, -2.5f),
                new Vector3(   0f,  2.5f,    0f)
            };

            Camera camera = new Camera(5f, 16f/9f, new Vector3(0, 0, -12), Quaternion.CreateFromYawPitchRoll(0, 0, 0), new Vector2(5, 5));

            ConsoleDisplay display = new ConsoleDisplay();
            while (true) {
                Frame frame = new Frame(Console.WindowHeight, Console.WindowWidth/2);
                
                camera.aspectRatio = (float) frame.width/(float) frame.height;

                // krychle
                camera.DrawLineToFrame(ref frame, cube[0], cube[4], ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, cube[1], cube[5], ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, cube[2], cube[6], ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, cube[3], cube[7], ConsoleColor.Green);

                camera.DrawLineToFrame(ref frame, cube[0], cube[1], ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, cube[1], cube[2], ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, cube[2], cube[3], ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, cube[3], cube[0], ConsoleColor.Red);

                camera.DrawLineToFrame(ref frame, cube[4], cube[5], ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, cube[5], cube[6], ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, cube[6], cube[7], ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, cube[7], cube[4], ConsoleColor.Blue);

                //jehlan
                /*camera.DrawLineToFrame(ref frame, pyramid[0], pyramid[1], ConsoleColor.Yellow);
                camera.DrawLineToFrame(ref frame, pyramid[1], pyramid[2], ConsoleColor.Yellow);
                camera.DrawLineToFrame(ref frame, pyramid[2], pyramid[3], ConsoleColor.Yellow);
                camera.DrawLineToFrame(ref frame, pyramid[3], pyramid[0], ConsoleColor.Yellow);
                
                camera.DrawLineToFrame(ref frame, pyramid[0], pyramid[4], ConsoleColor.Magenta);
                camera.DrawLineToFrame(ref frame, pyramid[1], pyramid[4], ConsoleColor.Magenta);
                camera.DrawLineToFrame(ref frame, pyramid[2], pyramid[4], ConsoleColor.Magenta);
                camera.DrawLineToFrame(ref frame, pyramid[3], pyramid[4], ConsoleColor.Magenta);*/

                display.Render(frame);

                // krychle
                for (int i = 0; i < cube.Length; i++)
                    cube[i].RotateAroundY(4.5f, Vector3.Zero);

                // jehlan
                /*for (int i = 0; i < pyramid.Length; i++)
                    pyramid[i].RotateAroundY(4.5f, Vector3.Zero);*/

                if (camera.position.z+12 <= -10 || camera.position.z+12 > 0)
                    dir = -dir;

                camera.position.z += dir;

                Thread.Sleep(100);
            }
        }
    }
}