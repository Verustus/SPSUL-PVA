using System.Numerics;

namespace Console_3D_Renderer {
    internal class Program {
        private static float dir = 0.2f;

        public static void Main() {
            /*Vector3 pointA1 = new Vector3(-2.5f, -2.5f, -2.5f);
            Vector3 pointB1 = new Vector3(-2.5f, -2.5f,  2.5f);
            Vector3 pointC1 = new Vector3( 2.5f, -2.5f,  2.5f);
            Vector3 pointD1 = new Vector3( 2.5f, -2.5f, -2.5f);
            Vector3 pointA2 = new Vector3(-2.5f,  2.5f, -2.5f);
            Vector3 pointB2 = new Vector3(-2.5f,  2.5f,  2.5f);
            Vector3 pointC2 = new Vector3( 2.5f,  2.5f,  2.5f);
            Vector3 pointD2 = new Vector3( 2.5f,  2.5f, -2.5f);*/
            
            Vector3 pointA = new Vector3(-2.5f, -2.5f, -2.5f);
            Vector3 pointB = new Vector3(-2.5f, -2.5f,  2.5f);
            Vector3 pointC = new Vector3( 2.5f, -2.5f,  2.5f);
            Vector3 pointD = new Vector3( 2.5f, -2.5f, -2.5f);
            Vector3 pointE = new Vector3(   0f,  2.5f,    0f);

            Camera camera = new Camera(5f, 16f/9f, new Vector3(0, 5, -15), Quaternion.CreateFromYawPitchRoll(0, -0.25f, 0), new Vector2(5, 5));

            ConsoleDisplay display = new ConsoleDisplay();
            while (true) {
                Frame frame = new Frame(Console.WindowHeight, Console.WindowWidth/2);
                
                camera.aspectRatio = (float) frame.width/(float) frame.height;

                /*camera.DrawLineToFrame(ref frame, pointA1, pointA2, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, pointB1, pointB2, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, pointC1, pointC2, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, pointD1, pointD2, ConsoleColor.Green);

                camera.DrawLineToFrame(ref frame, pointA1, pointB1, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, pointB1, pointC1, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, pointC1, pointD1, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, pointD1, pointA1, ConsoleColor.Red);

                camera.DrawLineToFrame(ref frame, pointA2, pointB2, ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, pointB2, pointC2, ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, pointC2, pointD2, ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, pointD2, pointA2, ConsoleColor.Blue);*/

                camera.DrawLineToFrame(ref frame, pointA, pointB, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, pointB, pointC, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, pointC, pointD, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, pointD, pointA, ConsoleColor.Red);
                
                camera.DrawLineToFrame(ref frame, pointA, pointE, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, pointB, pointE, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, pointC, pointE, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, pointD, pointE, ConsoleColor.Green);

                display.Render(frame);

                /*pointA1.RotateAroundY(4.5f, Vector3.Zero);
                pointB1.RotateAroundY(4.5f, Vector3.Zero);
                pointC1.RotateAroundY(4.5f, Vector3.Zero);
                pointD1.RotateAroundY(4.5f, Vector3.Zero);
                pointA2.RotateAroundY(4.5f, Vector3.Zero);
                pointB2.RotateAroundY(4.5f, Vector3.Zero);
                pointC2.RotateAroundY(4.5f, Vector3.Zero);
                pointD2.RotateAroundY(4.5f, Vector3.Zero);*/

                pointA.RotateAroundY(4.5f, Vector3.Zero);
                pointB.RotateAroundY(4.5f, Vector3.Zero);
                pointC.RotateAroundY(4.5f, Vector3.Zero);
                pointD.RotateAroundY(4.5f, Vector3.Zero);
                pointE.RotateAroundY(4.5f, Vector3.Zero);

                if (camera.position.z+15 <= -10 || camera.position.z+15 > 0)
                    dir = -dir;

                camera.position.z += dir;

                Thread.Sleep(100);
            }
        }
    }
}