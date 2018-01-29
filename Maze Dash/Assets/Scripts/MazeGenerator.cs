using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject[] blocks;
    public Transform blockParent;

    const int NEEDLE = 4;

    readonly int[,] maze = new int[20, 20]
    {
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,1},
        {1,0,0,1,1,1,1,1,0,1,1,1,1,1,2,1,1,1,0,1},
        {1,0,1,1,0,0,0,1,0,1,0,0,0,0,-2,0,0,0,0,1},
        {1,0,1,0,0,0,0,1,0,1,0,1,0,1,1,0,1,1,0,1},
        {1,0,1,0,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,1},
        {1,0,1,1,1,1,1,1,0,1,1,0,1,0,1,1,1,1,0,1},
        {1,0,0,4,0,0,1,0,0,0,0,0,0,0,4,0,0,0,0,1},
        {1,0,1,1,1,0,1,0,1,1,1,0,1,1,0,1,1,1,0,1},
        {1,0,1,0,1,0,1,0,1,0,1,0,1,1,0,0,0,0,0,1},
        {1,4,1,0,1,0,1,0,4,0,1,0,1,1,0,1,1,1,0,1},
        {1,0,1,0,1,1,1,1,1,1,1,0,1,1,0,0,0,1,0,1},
        {1,0,1,0,0,0,0,0,0,0,0,0,1,1,0,1,0,1,0,1},
        {1,0,1,0,1,1,1,1,1,1,1,0,1,1,0,1,0,0,0,1},
        {1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,1,1},
        {1,0,1,1,1,1,1,0,1,1,1,0,1,1,1,1,0,1,0,3},
        {1,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,1,0,1},
        {1,1,1,1,0,1,1,1,1,0,1,0,1,1,-2,1,1,1,0,1},
        {1,0,0,0,0,0,0,0,0,4,1,0,0,0,2,0,0,0,4,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] >= 1)
                {
                    GameObject spawnedBlock = Instantiate(blocks[maze[i, j] - 1]);
                    spawnedBlock.transform.position = new Vector3((i + 0.5f) * 2.0f, 0.0f, (j + 0.5f) * 2.0f);
                    spawnedBlock.transform.parent = blockParent;

                    if (maze[i, j] == 2)
                    {
                        int[,] dir = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 0, 1 }, { 1, 0 } };

                        for (int d = 0; d < 4; d++)
                        {
                            int nx = i + dir[d, 0], ny = j + dir[d, 1];

                            if (nx < 0 || nx >= maze.GetLength(0) || ny < 0 || ny >= maze.GetLength(1))
                            {
                                continue;
                            }

                            if (maze[nx, ny] == -2)
                            {
                                MovingBlock movingBlockScript = spawnedBlock.GetComponent<MovingBlock>();
                                movingBlockScript.originPos = new Vector3((i + 0.5f) * 2.0f, 1.0f, (j + 0.5f) * 2.0f);
                                movingBlockScript.newPos = new Vector3((nx + 0.5f) * 2.0f, 1.0f, (ny + 0.5f) * 2.0f);

                                maze[nx, ny] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
