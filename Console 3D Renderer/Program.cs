using System.Numerics;

namespace Console_3D_Renderer {
    internal class Program {
        private static float dir = 0.2f;

        public static void Main() {
            Camera camera = new Camera(5f, 16f/9f, new Vector3(0, 0, -15), Quaternion.CreateFromYawPitchRoll(0, 0, 0), new Vector2(3, 3));

            ConsoleDisplay display = new ConsoleDisplay();
            RenderModel renderModel = new RenderModel(new StaticModel(ModelLoader.LoadStl("..\\..\\..\\models\\cube.stl")), Vector3.Zero, ConsoleColor.Green);
            /*RenderModel renderModel = new RenderModel(new StaticModel(
                new Vector3[] {
                    new Vector3(0, 0, 0),
                    new Vector3(0, 1, 0),
                    new Vector3(1, 1, 0),
                }, new uint[] { 0, 1, 2 }
            ), Vector3.Zero, ConsoleColor.Green);*/

            while (true) {
                Frame frame = new Frame(Console.WindowHeight, Console.WindowWidth/2);
                
                camera.aspectRatio = (float) frame.width/(float) frame.height;

                Renderer.Render(ref camera, ref frame, renderModel, false);

                display.Draw(frame);

                renderModel.Rotate(new Vector3(0.225f, 0.45f, 0.9f));

                if (camera.position.z+15 <= -10 || camera.position.z+15 > 0)
                    dir = -dir;

                camera.position.z += dir;
            }
        }
    }
}