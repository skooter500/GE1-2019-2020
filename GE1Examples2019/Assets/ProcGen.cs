using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen : MonoBehaviour
{
    public int quadsPerTile = 10;

    public float scale = 10;
    public float perlinScale = 0.1f;
    public Material material;

    Mesh m;

    public void GenerateMesh()
    {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();

        mr.material = material;

        m = mf.mesh;

        int verticesPerQuad = 4;
        int trianglesPerQuad = 6;

        Vector3[] vertices = new Vector3[verticesPerQuad * quadsPerTile * quadsPerTile];
        int[] triangles = new int[trianglesPerQuad * quadsPerTile * quadsPerTile];

        Vector3 bottomLeft = new Vector3(-quadsPerTile / 2, 0, -quadsPerTile / 2);

        int vertex = 0;
        int triangle = 0;
        for (int row = 0; row < quadsPerTile; row++)
        {
            for(int col = 0; col < quadsPerTile; col ++)
            {
                Vector3 bl = bottomLeft + new Vector3(col, SampleCell(row, col), row);
                Vector3 tl = bottomLeft + new Vector3(col, SampleCell(row + 1, col), row + 1);
                Vector3 tr = bottomLeft + new Vector3(col + 1, SampleCell(row + 1, col + 1), row + 1);
                Vector3 br = bottomLeft + new Vector3(col + 1, SampleCell(row, col + 1), row);

                int startVertex = vertex;
                vertices[vertex++] = bl;
                vertices[vertex++] = tl;
                vertices[vertex++] = tr;
                vertices[vertex++] = br;

                triangles[triangle++] = startVertex;
                triangles[triangle++] = startVertex + 1;
                triangles[triangle++] = startVertex + 3;
                triangles[triangle++] = startVertex + 3;
                triangles[triangle++] = startVertex + 1;
                triangles[triangle++] = startVertex + 2;
            }
        }
        m.vertices = vertices;
        m.triangles = triangles;
        m.RecalculateNormals();

    }

    private float SampleCell(float row, float col)
    {
        /*
        float xtheta = (col / (float)quadsPerTile) * Mathf.PI;
        float ytheta = (row / (float)quadsPerTile) * Mathf.PI;

        return (Mathf.Sin(xtheta) * Mathf.Sin(ytheta)) * scale ;
        */

        return Mathf.PerlinNoise(col * perlinScale, row * perlinScale) * scale;

    }

    public void Awake()
    {
        GenerateMesh();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = m.vertices;
        for(int i = 0; i < vertices.Length; i ++)
        {
            vertices[i].y = SampleCell(vertices[i].x + t, vertices[i].z + t);
        }
        m.vertices = vertices;
        t += speed * Time.deltaTime;
    }

    public float speed = 1.0f;
    float t = 0;
}
