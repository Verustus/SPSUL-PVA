using System.Globalization;
using System.Text;

namespace Console_3D_Renderer {
    static internal class ModelLoader {
        public static Model LoadStl(string filePath) {
            if (IsBinaryStl(filePath))
                return LoadBinaryStl(filePath);
            else
                return LoadAsciiStl(filePath);
        }
        private static bool IsBinaryStl(string filePath) {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open))) {
                byte[] header = reader.ReadBytes(80);
                string headerText = Encoding.ASCII.GetString(header);
                return !headerText.StartsWith("solid", StringComparison.OrdinalIgnoreCase);
            }
        }
        private static Model LoadBinaryStl(string filePath) {
            Model model = new Model();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open))) {
                reader.BaseStream.Seek(80, SeekOrigin.Begin);
                uint triangleCount = reader.ReadUInt32();

                for (uint i = 0; i < triangleCount; i++) {
                    reader.ReadBytes(12);
                    var v1 = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    var v2 = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    var v3 = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

                    model.AddTriangle(v1, v2, v3);
                    reader.ReadUInt16();
                }
            }

            return model;
        }
        private static Model LoadAsciiStl(string filePath) {
            Model model = new Model();

            using (StreamReader reader = new StreamReader(filePath)) {
                string line;
                Vector3[] triangle = new Vector3[3];
                int vertexIndex = 0;

                while ((line = reader.ReadLine()) != null) {
                    if (line.Trim().StartsWith("vertex", StringComparison.OrdinalIgnoreCase)) {
                        var parts = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        float x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                        float y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                        float z = float.Parse(parts[3], CultureInfo.InvariantCulture);

                        triangle[vertexIndex++] = new Vector3(x, y, z);

                        if (vertexIndex == 3) {
                            model.AddTriangle(triangle[0], triangle[1], triangle[2]);
                            vertexIndex = 0;
                        }
                    }
                }
            }

            return model;
        }
    }
}
