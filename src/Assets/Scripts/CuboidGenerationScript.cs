using Assets.Scripts.MeshBuilding;
using UnityEngine;

namespace Assets.Scripts
{
    public class CuboidGenerationScript : MonoBehaviour
    {
        public int Height;
        public int Width;
        public int Length;
        public Material CubeMaterial;

        void Start()
        {
            var cuboidBuilder = new CuboidBuilder(new QuadBuilder(new MeshBuilder()));
            CreateCuboid(cuboidBuilder, Height, Width, Length);
        }

        private void CreateCuboid(CuboidBuilder cuboidBuilder, int height, int width, int length)
        {
            var cube = new GameObject("ScriptedCube");

            var mf = cube.AddComponent<MeshFilter>();
            mf.mesh = cuboidBuilder.BuildCuboid(height, width, length);

            var mr = cube.AddComponent<MeshRenderer>();
            mr.material = CubeMaterial;
        }
    }
}