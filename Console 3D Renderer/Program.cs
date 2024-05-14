using System.Numerics;

namespace Console_3D_Renderer {
    internal class Program {
        public static void Main(String[] args) {
            // nestihl jsem to instaloval jsem visual studio celou prvni hodinu jinak to ma byt 3d renderer do konzole chtel jsem renderovat krychli
            Vector3 point = new Vector3(1, 1, 1);
            Camera camera = new Camera(60f, 16f / 9f, new Vector3(1, 3, 3), Quaternion.Identity);
            
            
            point.RotateAroundY(90, Vector3.zero);
            
            Console.WriteLine(point);
            Console.WriteLine(camera.PerspectiveProjection(point));
        }
    }
}