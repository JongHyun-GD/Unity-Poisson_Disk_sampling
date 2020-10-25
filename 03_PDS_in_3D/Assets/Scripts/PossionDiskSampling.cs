using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PossionDiskSampling
{
    #region Public Variables
    public int k = 30;
    public float minDist = 10;
    public float maxDist = 10;
    #endregion

    public struct Pos
    {
        public float x, y, z;

        public Pos(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    public List<Pos> GetSampling(int xSize, int ySize, int zSize, int cellSize)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        List<Pos> output = new List<Pos>();
        Queue<Pos> process = new Queue<Pos>();
        bool[,,] grid = new bool[(xSize / cellSize) +1, (ySize / cellSize) +1, (zSize / cellSize) + 1];
        for (int i = 0; i < (xSize / cellSize) + 1; ++ i)
            for (int j = 0; j < (ySize / cellSize) + 1; ++ j)
                for (int k = 0; k < (zSize / cellSize) + 1; ++k)
                    grid[i, j, k] = false;

        float rx = Random.Range(0, xSize);
        float ry = Random.Range(0, ySize);
        float rz = Random.Range(0, zSize);

        Pos first = new Pos(rx, ry, rz);
        process.Enqueue(first);
        output.Add(first);

        while(process.Count != 0)
        {
            Pos curPoint = process.Dequeue();

            for (int i = 0; i < k; ++ i)
            {
                float randomTheta = Random.Range(0, 360);
                float randomPi = Random.Range(0, 360);
                float randomDistance = Random.Range(minDist, maxDist);

                float nx = curPoint.x + randomDistance * Mathf.Sin(randomTheta * Mathf.Deg2Rad) * Mathf.Cos(randomPi * Mathf.Deg2Rad);
                float ny = curPoint.y + randomDistance * Mathf.Cos(randomTheta * Mathf.Deg2Rad);
                float nz = curPoint.z + randomDistance * Mathf.Sin(randomTheta * Mathf.Deg2Rad) * Mathf.Sin(randomPi * Mathf.Deg2Rad);

                // Debug.Log(nx + ", " + ny);
                if (nx >= 0 && nx < xSize && ny >= 0 && ny < ySize && nz >= 0 && nz < zSize &&    // 범위 체크
                    hasNeiborhood(ref grid, (int)(ny / cellSize), (int)(nx / cellSize), (int)(nz / cellSize)) == false)          // 해당 cell 주변에 Point가 없다면
                {
                    output.Add(new Pos(nx, ny, nz));
                    process.Enqueue(new Pos(nx, ny, nz));
                    grid[(int)(ny / cellSize), (int)(nx / cellSize), (int)(nz / cellSize)] = true;
                }
            }
        }

        // Debug.Log(output.Count);
        return output;
    }

    bool hasNeiborhood(ref bool[,,] grid, int x, int y, int z)
    {
        for (int i = x-1; i <= x+1; ++ i)
            for (int j = y-1; j <= y+1; ++ j)
                for (int k = z-1; k <= z+1; ++ k)
                if (i >= 0 && i < grid.GetLength(0) && j >= 0 && j < grid.GetLength(1) && k >= 0 && k < grid.GetLength(2) &&
                    grid[i, j, k] == true)
                    return true;

        return false;
    }
}
