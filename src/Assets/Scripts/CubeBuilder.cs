using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubeBuilder
    {
        private readonly QuadBuilder _quadBuilder;

        public CubeBuilder(QuadBuilder quadBuilder)
        {
            _quadBuilder = quadBuilder;
        }

        public Mesh BuildCube(int size)
        {
            var upDir = Vector3.up*size;
            var rightDir = Vector3.right*size;
            var forwardDir = Vector3.forward*size;

            var nearCorner = Vector3.zero;
            var farCorner = upDir + rightDir + forwardDir;

            var quadsCombine = new List<Mesh>
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