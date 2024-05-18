using System.Drawing;

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
    }

    internal class RenderModel {
        private StaticModel model;
        public Vector3 position;
        public Vector3 rotation;
        public Color color;

        public RenderModel(StaticModel model, Color color, Vector3 position, Vector3 rotation) {
            this.model = model;
            this.position = position;
            this.rotation = rotation;
            this.color = color;
        }

        public uint GetVertexCount() { return (uint) model.vertices.Length; }
        public Vector3 GetVertex(uint index) {
            return new Vector3(model.vertices[index]).Rotate(rotation);
        }
        public uint GetIndexCount() { return (uint) model.indices.Length; }
        public uint GetIndex(uint index) { return model.indices[index]; }

        public void Rotate(Vector3 rotation) {
            this.rotation.Add(rotation);
            this.rotation.x %= 360;
            this.rotation.y %= 360;
            this.rotation.z %= 360;
        }

        public void RotateAround(Vector3 rotation, Vector3 point) {
            position.Subtract(point);

            position.Rotate(rotation);
            Rotate(rotation);

            position.Add(point);
        }
    }
}
