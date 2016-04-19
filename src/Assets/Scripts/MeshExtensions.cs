using UnityEngine;

namespace Assets.Scripts
{
    public static class MeshExtensions 
    {
        public static Mesh RotateMesh(this Mesh mesh, Vector3 eulerAnglesRotation)
        {
            var center = Vector3.zero;
            var rotation = new Quaternion { eulerAngles = eulerAnglesRotation };
            var verts = mesh.vertices;
            for (var i = 0; i < verts.Length; i++)
            {
                verts[i] = rotation * (verts[i] - center) + center;
            }
            mesh.vertices = verts;
            return mesh;
        }

        public static Mesh MoveMesh(this Mesh mesh, Vector3 moveVector)
        {
            var verts = mesh.vertices;
            for (var i = 0; i < verts.Length; i++)
            {
                verts[i] = verts[i] + moveVector;
            }
            mesh.vertices = verts;
            return mesh;
        }
    }
}
