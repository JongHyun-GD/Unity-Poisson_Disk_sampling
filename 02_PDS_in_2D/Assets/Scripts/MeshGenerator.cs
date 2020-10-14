using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [Range(10, 50)]
    public int k = 30;
    public int width, height, cellSize, maxDistance, minDistance;

    public bool b_drawGizmos = false;
    public bool b_instanciate = false;
    public GameObject genMesh;

    PossionDiskSampling pds;
    List<PossionDiskSampling.Pos> points;
    List<GameObject> meshes; // GenerateMesh로 만들어진 GameObjects

    private void Start()
    {
        pds = new PossionDiskSampling();
        meshes = new List<GameObject>();
        GenerateSampling();
    }

    private void OnDrawGizmos()
    {
        if (b_drawGizmos && points != null)
        {
            Gizmos.color = Color.red;
            foreach (var item in points)
                Gizmos.DrawCube(new Vector3(item.x, 0f, item.y), Vector3.one * 10);
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

    public void GenerateMesh()
    {
        if (points == null) {
            Debug.Log("Can not generate mesh. There are not samples.");
            return;
        }

        if (genMesh == null)
        {
            Debug.Log("Can not generate mesh. There is not mesh.");
            return;
        }

        float y, x;
        for (int i = 0; i < points.Count; ++ i) {
            y = points[i].y;
            x = points[i].x;

            meshes.Add(Instantiate(genMesh, new Vector3(x, 0, y), Quaternion.identity, this.transform));
        }
    }

    public void DeleteMesh ()
    {
        if (meshes == null)
        {
            Debug.Log("There is no instanciated meshes");
            return;
        }

        foreach (GameObject item in meshes)
        {
            Destroy(item);
        }
    }
}
