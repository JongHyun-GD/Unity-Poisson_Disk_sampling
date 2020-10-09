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
        public float x, y;

        public Pos(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }

    public List<Pos> GetSampling(int width, int height, int cellSize)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        List<Pos> output = new List<Pos>();
        Queue<Pos> process = new Queue<Pos>();
        bool[,] grid = new bool[(height / cellSize) +1, (width / cellSize) +1];
        for (int i = 0; i < (height / cellSize) + 1; ++ i)
            for (int j = 0; j < (width / cellSize) + 1; ++ j)
                grid[i, j] = false;

        float rx = Random.Range(0, width);
        float ry = Random.Range(0, height);

        Pos first = new Pos(rx, ry);
        process.Enqueue(first);
        output.Add(first);

        while(process.Count != 0)
        {
            Pos curPoint = process.Dequeue();

            for (int i = 0; i < k; ++ i)
            {
                float randomAngle = Random.Range(0, 360);
                float randomDistance = Random.Range(minDist, maxDist);

                float nx = curPoint.x + randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
                float ny = curPoint.y + randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad);

                // Debug.Log(nx + ", " + ny);
                if (nx >= 0 && nx < width && ny >= 0 && ny < height &&    // 범위 체크
                    hasNeiborhood(ref grid, (int)(ny / cellSize), (int)(nx / cellSize)) == false)          // 해당 cell 주변에 Point가 없다면
                {
                    output.Add(new Pos(nx, ny));
                    process.Enqueue(new Pos(nx, ny));
                    grid[(int)(ny / cellSize), (int)(nx / cellSize)] = true;
                }
            }
        }

        // Debug.Log(output.Count);
        return output;
    }

    bool hasNeiborhood(ref bool[,] grid, int row, int col)
    {
        for (int i = row-1; i <= row+1; ++ i)
            for (int j = col-1; j <= col+1; ++ j)
                if (i >= 0 && i < grid.GetLength(0) && j >= 0 && j < grid.GetLength(1) &&
                    grid[i, j] == true)
                    return true;

        return false;
    }
}
