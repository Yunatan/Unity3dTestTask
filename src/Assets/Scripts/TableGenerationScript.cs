using Assets.Scripts.MeshBuilding;
using UnityEngine;

namespace Assets.Scripts
{
    public class TableGenerationScript : MonoBehaviour
    {
        //public int tabletopWidth;
        //public int tabletopLength;
        //public int tabletopHeight;
        //public int legsLength;
        //public int legsThickness;
        public Material tableMaterial;

        private GameObject _tableInstance;

        void Start()
        {
            var tableBuilder = new TableBuilder(new CuboidBuilder(new QuadBuilder(new MeshBuilder())))
            {
                TabletopWidth = Random.Range(15, 25), //tabletopWidth,
                TabletopLength = Random.Range(15, 37), //tabletopLength,
                TabletopHeight = Random.Range(1, 3), //tabletopHeight,
                LegsLength = Random.Range(5, 20), //legsLength,
                LegsThickness = Random.Range(1, 3), //legsThickness
            };

            var tableMesh = tableBuilder.BuildTable();
            var table = CreateTable(tableMesh);

            table.transform.Translate(Vector3.up * (tableBuilder.LegsLength + tableBuilder.TabletopHeight));
        }

        public void Regenerate()
        {
            Destroy(_tableInstance);
            Start();
        }

        private GameObject CreateTable(Mesh tableMesh)
        {
            var table = new GameObject("ScriptedTable");

            var mf = table.AddComponent<MeshFilter>();
            mf.mesh = tableMesh;

            var mr = table.AddComponent<MeshRenderer>();
            mr.material = tableMaterial;

           return  _tableInstance = table;
        }
    }
}
