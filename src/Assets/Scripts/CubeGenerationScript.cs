using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeGenerationScript : MonoBehaviour
{
    public int X;

    public int Y;

    public int Size;

    void Start ()
	{
	    var cube = CreateCube(Size);
        //Instantiate(cube, new Vector3(X, Y, 0), Quaternion.identity);
    }

    private GameObject CreateCube(int size)
    {
        var cubeMesh = GenerateCubeMesh(size);
        var cube = new GameObject();
        var mf = cube.AddComponent<MeshFilter>();
        cube.AddComponent<MeshRenderer>();
        mf.mesh = cubeMesh;

        return cube;
    }

    private Mesh GenerateCubeMesh(int size)
    {
        var m = new Mesh
        {
            name = "ScriptedMesh",
            vertices = new[]
            {
                new Vector3(-size, -size,  -size),
                new Vector3(-size,  size,  -size),
                new Vector3( size,  size,  -size),
                new Vector3( size, -size,  -size),
                new Vector3( size, -size,   size),
                new Vector3( size,  size,   size),
                new Vector3(-size,   size,  size),
                new Vector3(-size, -size,  size)
            },
            triangles = new[]
            {
                0, 1, 2,
                2, 3, 0,

                0, 7, 6,
                6, 1, 0,

                0, 3, 4, 
                4, 7, 0,

                5, 4, 3,
                3, 2, 5,

                5, 6, 7,
                7, 4, 5,

                5, 2, 1,
                1, 6, 5
            }
        };

        m.RecalculateNormals();

        return m;
    }
}
