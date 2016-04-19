using UnityEngine;

namespace Assets.Scripts
{
    public class CubeGenerationScript : MonoBehaviour
    {
        public int X;
        public int Y;
        public int Size;
        public Material CubeMaterial;

        private CubeBuilder cubeBuilder;

        void Start()
        {
            cubeBuilder = new CubeBuilder(new QuadBuilder(new MeshBuilder()));

            CreateCube(Size);
        }

        private GameObject CreateCube(int size)
        {
            var cube = new GameObject("ScriptedCube");

            var mf = cube.AddComponent<MeshFilter>();
            var mr = cube.AddComponent<MeshRenderer>();
            mf.mesh = cubeBuilder.BuildCube(size);
            mr.material = CubeMaterial;

            return cube;
        }
    }
}