namespace Console_3D_Renderer {
    internal class Model {
        public List<Vector3> vertices { get; private set; } = new List<Vector3>();
        public List<uint> indices { get; private set; } = new List<uint>();

        public uint AddVertex(Vector3 vertex) {
            int index = vertices.IndexOf(vertex);
            if (index == -1) {
                index = vertices.Count;
                vertices.Add(vertex);
            }
            return (uint) index;
        }

        public void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3) {
            uint i1 = AddVertex(v1);
            uint i2 = AddVertex(v2);
            uint i3 = AddVertex(v3);

            indices.Add(i1);
            indices.Add(i2);
            indices.Add(i3);
        }
    }

    internal class StaticModel {
        public Vector3[] vertices { get; private set; }
        public uint[] indices { get; private set; }

        public StaticModel(Model model) {
            vertices = model.vertices.ToArray();
            indices = model.indices.ToArray();
        }

        public StaticModel(Vector3[] vertices, uint[] indices) {
            this.vertices = vertices;
            this.indices = indices;
        }

        public void Rotate(Vector3 rotation) {
            foreach (Vector3 v in vertices)
                v.Rotate(rotation);
        }
    }

    internal class RenderModel {
        public StaticModel model { get; private set; }
        public Vector3 position = Vector3.Zero;
        public ConsoleColor color;

        public RenderModel(StaticModel model, Vector3 position, ConsoleColor color) {
            this.model = model;
            this.position = position;
            this.color = color;
        }

        public void Rotate(Vector3 rotation) {
            model.Rotate(rotation);
        }

        public void RotateAround(Vector3 rotation, Vector3 point) {
            position.Subtract(point);

            position.Rotate(rotation);
            Rotate(rotation);

            position.Add(point);
        }
    }
}
