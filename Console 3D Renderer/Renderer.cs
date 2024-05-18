namespace Console_3D_Renderer {
    static internal class Renderer {
        public static void Render(ref Camera camera, ref Frame frame, RenderModel model, bool solid = false) {
            Render(ref camera, ref frame, new RenderModel[] { model }, solid);
        }
        public static void Render(ref Camera camera, ref Frame frame, RenderModel[] models, bool solid = false) {
            foreach (RenderModel renderModel in models) {
                StaticModel model = renderModel.model;

                if (model.indices.Length < 2) continue;
                for (int i = 0; i < model.indices.Length; i++) {
                    if (!solid) {
                        Vector3 v0 = model.vertices[model.indices[i]].Add(renderModel.position);
                        Vector3 v1 = model.vertices[model.indices[(i + 1) % model.indices.Length]].Add(renderModel.position);
                        
                        (Vector2, float) projectedV0 = camera.PerspectiveProjection(v0);
                        (Vector2, float) projectedV1 = camera.PerspectiveProjection(v1);

                        camera.DrawLineToFrame(ref frame, projectedV0, projectedV1, renderModel.color);
                    } else {
                        Vector3 v0 = model.vertices[model.indices[i]].Add(renderModel.position);
                        Vector3 v1 = model.vertices[model.indices[(i + 1) % model.indices.Length]].Add(renderModel.position);
                        Vector3 v2 = model.vertices[model.indices[(i + 2) % model.indices.Length]].Add(renderModel.position);
                
                        camera.DrawTriangleToFrame(ref frame, v0, v1, v2, renderModel.color);
                    }
                }
            }
        }
    }
}
