using UnityEngine;

namespace Assets.Scripts.MeshBuilding
{
    public class QuadBuilder
    {
        private readonly MeshBuilder _meshBuilder;

        public QuadBuilder(MeshBuilder meshBuilder)
        {
            _meshBuilder = meshBuilder;
        }

        public Mesh BuildQuad(Vector3 offset, Vector3 widthDir, Vector3 lengthDir)
        {
            var normal = Vector3.Cross(lengthDir, widthDir).normalized;

            _meshBuilder.Vertices.Add(offset);
            _meshBuilder.UVs.Add(new Vector2(0.0f, 0.0f));
            _meshBuilder.Normals.Add(normal);

            _meshBuilder.Vertices.Add(offset + lengthDir);
            _meshBuilder.UVs.Add(new Vector2(0.0f, 1.0f));
            _meshBuilder.Normals.Add(normal);

            _meshBuilder.Vertices.Add(offset + lengthDir + widthDir);
            _meshBuilder.UVs.Add(new Vector2(1.0f, 1.0f));
            _meshBuilder.Normals.Add(normal);

            _meshBuilder.Vertices.Add(offset + widthDir);
            _meshBuilder.UVs.Add(new Vector2(1.0f, 0.0f));
            _meshBuilder.Normals.Add(normal);

            var baseIndex = _meshBuilder.Vertices.Count - 4;

            _meshBuilder.AddTriangle(baseIndex, baseIndex + 1, baseIndex + 2);
            _meshBuilder.AddTriangle(baseIndex, baseIndex + 2, baseIndex + 3);

            return _meshBuilder.GetResultAndResetState();
        }
    }
}
