using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlane : MonoBehaviour {

    private void Awake()
    {
        ReSample();
    }

    // Use this for initialization
    void ReSample() {
        Mesh m = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = m.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = SampleCell3(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z);
        }
        m.vertices = vertices;
        m.RecalculateBounds();
        m.RecalculateNormals();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public static float SampleCell3(float x, float y)
    {
        float flatness = 0.2f;
        float noise = Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100);
        if (noise > 0.5f + flatness)
        {
            noise = noise - flatness;
        }
        else if (noise < 0.5f - flatness)
        {
            noise = noise + flatness;
        }
        else
        {
            noise = 0.5f;
        }

        return (noise * 300) + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }

}
