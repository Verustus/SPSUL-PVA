using System.Numerics;

namespace Console_3D_Renderer {
    internal class Program {
        public static void Main(String[] args) {
            Vector3 pointA1 = new Vector3(-2.5f, -2.5f, -2.5f);
            Vector3 pointB1 = new Vector3(-2.5f, -2.5f,  2.5f);
            Vector3 pointC1 = new Vector3( 2.5f, -2.5f,  2.5f);
            Vector3 pointD1 = new Vector3( 2.5f, -2.5f, -2.5f);
            Vector3 pointA2 = new Vector3(-2.5f,  2.5f, -2.5f);
            Vector3 pointB2 = new Vector3(-2.5f,  2.5f,  2.5f);
            Vector3 pointC2 = new Vector3( 2.5f,  2.5f,  2.5f);
            Vector3 pointD2 = new Vector3( 2.5f,  2.5f, -2.5f);

            Camera camera = new Camera(8f, 16f/9f, new Vector3(0, 0, -12), Quaternion.CreateFromYawPitchRoll(0, 0, 0));

            ConsoleDisplay display = new ConsoleDisplay();
            while (true) {
                ConsoleColor[,] frame = new ConsoleColor[Console.WindowHeight, Console.WindowWidth/2];
                
                camera.aspectRatio = frame.GetLength(1)/frame.GetLength(0);
                
                Vector2 projectedPointA1 = camera.PerspectiveProjection(pointA1);
                Vector2 projectedPointB1 = camera.PerspectiveProjection(pointB1);
                Vector2 projectedPointC1 = camera.PerspectiveProjection(pointC1);
                Vector2 projectedPointD1 = camera.PerspectiveProjection(pointD1);
                Vector2 projectedPointA2 = camera.PerspectiveProjection(pointA2);
                Vector2 projectedPointB2 = camera.PerspectiveProjection(pointB2);
                Vector2 projectedPointC2 = camera.PerspectiveProjection(pointC2);
                Vector2 projectedPointD2 = camera.PerspectiveProjection(pointD2);

                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointA1, projectedPointB1, ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointB1, projectedPointC1, ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointC1, projectedPointD1, ConsoleColor.Blue);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointD1, projectedPointA1, ConsoleColor.Blue);

                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointA2, projectedPointB2, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointB2, projectedPointC2, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointC2, projectedPointD2, ConsoleColor.Red);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointD2, projectedPointA2, ConsoleColor.Red);

                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointA1, projectedPointA2, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointB1, projectedPointB2, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointC1, projectedPointC2, ConsoleColor.Green);
                camera.DrawLineToFrame(ref frame, 5, 10, projectedPointD1, projectedPointD2, ConsoleColor.Green);
                for (int i = 0; i < frame.GetLength(0); i++) {
                    for (int j = 0; j < frame.GetLength(1); j++)
                        display.SetPixel(i, j, frame[i, j]);
                }

                pointA1.RotateAroundY(4.5f, Vector3.Zero);
                pointB1.RotateAroundY(4.5f, Vector3.Zero);
                pointC1.RotateAroundY(4.5f, Vector3.Zero);
                pointD1.RotateAroundY(4.5f, Vector3.Zero);
                pointA2.RotateAroundY(4.5f, Vector3.Zero);
                pointB2.RotateAroundY(4.5f, Vector3.Zero);
                pointC2.RotateAroundY(4.5f, Vector3.Zero);
                pointD2.RotateAroundY(4.5f, Vector3.Zero);

                display.Render();
                //Console.WriteLine(pointA2);
                Thread.Sleep(10);
            }
            //Screen screen = new Screen();
            //screen.StartLoop(frame);
        }
    }
}