using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MeshBuilding
{
    public class MeshBuilder
    {
        public List<Vector3> Vertices { get; private set; }

        public List<Vector3> Normals { get; private set; }

        public List<Vector2> UVs { get; private set; }

        private List<int> _indices;

        public MeshBuilder()
        {
            Initialise();
        }

        public void AddTriangle(int index0, int index1, int index2)
        {
            _indices.Add(index0);
            _indices.Add(index1);
            _indices.Add(index2);
        }

        public Mesh GetResultAndResetState()
        {
            var mesh = new Mesh
            {
                vertices = Vertices.ToArray(),
                triangles = _indices.ToArray()
            };

            if (Normals.Count == Vertices.Count)
                mesh.normals = Normals.ToArray();

            if (UVs.Count == Vertices.Count)
                mesh.uv = UVs.ToArray();

            mesh.RecalculateBounds();

            Initialise();

            return mesh;
        }

        private void Initialise()
        {
            UVs = new List<Vector2>();
            Normals = new List<Vector3>();
            Vertices = new List<Vector3>();
            _indices = new List<int>();
        }
    }
}