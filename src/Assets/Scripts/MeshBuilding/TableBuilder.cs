using System.Linq;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.MeshBuilding
{
    public class TableBuilder
    {
        private readonly CuboidBuilder _cuboidBuilder;

        private const int tableLegsCount = 4;

        public int TabletopWidth { get; set; }

        public int TabletopLength { get; set; }

        public int TabletopHeight { get; set; }

        public int LegsLength { get; set; }

        public int LegsThickness { get; set; }

        public TableBuilder(CuboidBuilder cuboidBuilder)
        {
            _cuboidBuilder = cuboidBuilder;
        }

        public Mesh BuildTable()
        {
            var partsCombine = new[]
            {
                BuildTabletop(),
                BuildTableLegs()
            }.Select(x => new CombineInstance { mesh = x }).ToArray();

            var table = new Mesh();
            table.CombineMeshes(partsCombine, true, false);
            return table;
        }

        private Mesh BuildTableLegs()
        {
            var legsCombine = Enumerable.Range(0, tableLegsCount)
                .Select(i => MakeLeg())
                .Select(legMesh => new CombineInstance { mesh = legMesh }).ToArray();

            legsCombine[0].mesh.MoveMesh(Vector3.left * 0);
            legsCombine[1].mesh.MoveMesh(Vector3.right * (TabletopWidth - LegsThickness));
            legsCombine[2].mesh.MoveMesh(Vector3.forward * (TabletopLength - LegsThickness));
            legsCombine[3].mesh.MoveMesh(Vector3.right * (TabletopWidth - LegsThickness) + Vector3.forward * (TabletopLength - LegsThickness));

            var legs = new Mesh();
            legs.CombineMeshes(legsCombine, true, false);
            return legs;
        }

        private Mesh MakeLeg()
        {
            return _cuboidBuilder.BuildCuboid(LegsThickness, LegsThickness, LegsLength).RotateMesh(new Vector3(90, 0, 0));
        }

        private Mesh BuildTabletop()
        {
            return _cuboidBuilder.BuildCuboid(TabletopHeight, TabletopWidth, TabletopLength);
        }
    }
}
