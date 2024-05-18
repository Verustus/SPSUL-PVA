using System.Reflection;

namespace Console_3D_Renderer {
    static internal class Renderer {
        public static void Render(ref Camera camera, ref Frame frame, RenderModel model, bool solid = false) {
            Render(ref camera, ref frame, [model], solid);
        }
        public static void Render(ref Camera camera, ref Frame frame, RenderModel[] models, bool solid = false) {
            foreach (RenderModel renderModel in models) {
                if (renderModel.GetIndexCount() < 2) continue;
                for (int i = 0; i < renderModel.GetIndexCount(); i++) {
                    if (!solid) {
                        Vector3 v0 = renderModel.GetVertex(renderModel.GetIndex((uint) i));
                        Vector3 v1 = renderModel.GetVertex(renderModel.GetIndex((uint) ((i + 1) % renderModel.GetIndexCount())));
                        
                        (Vector2, float) projectedV0 = camera.PerspectiveProjection(v0);
                        (Vector2, float) projectedV1 = camera.PerspectiveProjection(v1);

                        camera.DrawLineToFrame(ref frame, projectedV0, projectedV1, renderModel.color);
                    } else {
                        continue;
                    }
                }
            }
        }
    }
}
