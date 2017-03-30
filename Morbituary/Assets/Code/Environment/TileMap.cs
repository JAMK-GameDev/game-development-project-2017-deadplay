using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the tile on which the whole game will be played
/// </summary>
[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]      // "Sanity check". Requires it to have the following component, otherwise the game cannot be run!
[RequireComponent(typeof(MeshRenderer))]    // These checks are performed so the game does not have random crashes during play-time.
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour
{
    // Fields
    public int sizeX = 100;
    public int sizeZ = 50;
    public float tileSize = 1.0f;

    // Properties
    int tileCount { get { return sizeX * sizeZ; } }
    int trisCount { get { return tileCount * 2; } }

    int vSizeX { get { return sizeX + 1; } }
    int vSizeZ { get { return sizeZ + 1; } }
    int vertCount { get { return vSizeX * vSizeZ; } }

    void Start () {
        BuildMesh();
	}
	
	void Update () {
		
	}


    /// <summary>
    /// This is a hard coded approach, demonstrating the fundamental basics behind the tile map.
    /// </summary>
    void BuildMesh()
    {
        // Generate mesh data
        Vector3[] vertices = new Vector3[vertCount];
        Vector3[] normals = new Vector3[vertCount];
        Vector2[] uv = new Vector2[vertCount];

        int[] triangles = new int[trisCount * 3];

        int x, z;
        for (z = 0; z < sizeZ; ++z)
        {
            for (x = 0; x < sizeX; ++x)
            {
                int i = z * vSizeX + x;
                vertices[i] = new Vector3(x * tileSize, 0, z * tileSize);
                normals[i] = Vector3.up;
                uv[i] = MapUV(x, z);
            }
        }
        Debug.Log("Build Mesh: Triangles Created");

        // Populate Triangles
        for (z = 0; z < sizeZ; ++z)
        {
            for (x = 0; x < sizeX; ++x)
            {
                int squareIndex = z * sizeX + x;
                int triOffset = squareIndex * 6;
                int vertOffset = squareIndex * 6;

                triangles[triOffset + 0] = z * vSizeX + x + 0;
                triangles[triOffset + 1] = z * vSizeX + x + vSizeX + 1;
                triangles[triOffset + 2] = z * vSizeX + x + vSizeX + 0;

                triangles[triOffset + 3] = z * vSizeX + x + 0;
                triangles[triOffset + 4] = z * vSizeX + x + 1;
                triangles[triOffset + 5] = z * vSizeX + x + vSizeX + 1;
            }
        }

        Debug.Log("Build Mesh: Verticles Created");

        // Create a new mesh and populate with the data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign our mesh to our components
        MeshFilter filter = GetComponent<MeshFilter>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        MeshCollider collider = GetComponent<MeshCollider>();

        filter.mesh = mesh;

        Debug.Log("Build Mesh: Mesh Created");
    }

    private Vector2 MapUV(int x, int z)
    {
        return new Vector2((float) x / vSizeX, (float) z / vSizeZ);
    }
}
