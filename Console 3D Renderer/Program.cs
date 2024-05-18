using System.Numerics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Console_3D_Renderer {
    internal class Program {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_MAXIMIZE = 3;

        private static float dir = 0.2f;

        public static void Main() {
            IntPtr hWnd = GetForegroundWindow();
            ShowWindow(hWnd, SW_MAXIMIZE);

            Camera camera = new Camera(30f, 16f/9f, new Vector3(0, 0, -5), Quaternion.CreateFromYawPitchRoll(0, 0, 0), new Vector2(1, 1));

            ConsoleDisplay display = new ConsoleDisplay();
            RenderModel renderModel = new RenderModel(new StaticModel(ModelLoader.LoadStl("..\\..\\..\\models\\cube.stl")), Color.Green, Vector3.Zero, Vector3.Zero);
            /*RenderModel renderModel = new RenderModel(new StaticModel(
                new Vector3[] {
                    new Vector3(0, 0, 0),
                    new Vector3(0, 1, 0),
                    new Vector3(1, 1, 0),
                }, new uint[] { 0, 1, 2 }
            ), Color.Green, Vector3.Zero, Vector3.Zero);*/

            while (true) {
                Frame frame = new Frame(Console.WindowHeight, Console.WindowWidth/2);
                
                camera.aspectRatio = (float) frame.width/(float) frame.height;

                Renderer.Render(ref camera, ref frame, renderModel);

                display.Draw(frame);

                renderModel.Rotate(new Vector3(0.225f, 0.45f, 0.9f));

                if (camera.position.z+5 <= -10 || camera.position.z+5 > 0)
                    dir = -dir;

                camera.position.z += dir;
            }
        }
    }
}