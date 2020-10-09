using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [Range(10, 50)]
    public int k = 30;
    public int width, height, cellSize, maxDistance, minDistance;

    PossionDiskSampling pds;
    List<PossionDiskSampling.Pos> points;

    private void Start()
    {
        pds = new PossionDiskSampling();
        GenerateSampling();
    }

    private void OnDrawGizmos()
    {
        if (points != null)
        {
            Gizmos.color = Color.red;
            foreach (var item in points)
                Gizmos.DrawCube(new Vector3(item.x, 0f, item.y), Vector3.one * 5);
        }
    }

    public void GenerateSampling()
    {
        points = null;
        pds.k = 30;
        pds.minDist = minDistance;
        pds.maxDist = maxDistance;
        points = pds.GetSampling(width, height, cellSize);
    }
}
