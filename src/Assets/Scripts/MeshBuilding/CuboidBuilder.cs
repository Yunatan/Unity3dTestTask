using System.Linq;
using UnityEngine;

namespace Assets.Scripts.MeshBuilding
{
    public class CuboidBuilder
    {
        private readonly QuadBuilder _quadBuilder;

        public CuboidBuilder(QuadBuilder quadBuilder)
        {
            _quadBuilder = quadBuilder;
        }

        public Mesh BuildCuboid(int height, int width, int length)
        {
            var upDir = Vector3.up * height;
            var rightDir = Vector3.right * width;
            var forwardDir = Vector3.forward * length;

            var nearCorner = Vector3.zero;
            var farCorner = upDir + rightDir + forwardDir;

            var quadsCombine = new[]
            {
                _quadBuilder.BuildQuad(nearCorner, forwardDir, rightDir),
                _quadBuilder.BuildQuad(nearCorner, rightDir, upDir),
                _quadBuilder.BuildQuad(nearCorner, upDir, forwardDir),
                _quadBuilder.BuildQuad(farCorner, -rightDir, -forwardDir),
                _quadBuilder.BuildQuad(farCorner, -upDir, -rightDir),
                _quadBuilder.BuildQuad(farCorner, -forwardDir, -upDir)
            }.Select(x => new CombineInstance { mesh = x }).ToArray();

            var cube = new Mesh();
            cube.CombineMeshes(quadsCombine, true, false);
            return cube;
        }
    }
}