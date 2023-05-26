using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GameGrid : MonoBehaviour
{
    private static GameGrid instance;

    public static GameGrid MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameGrid>();
            }

            return instance;
        }

    }

    public int height, width;

    private NavMeshSurface navMeshSurfaces;

    [SerializeField]
    private GameObject gridPrefab;

    private GameObject[,] gameGrid;

    private void Awake()
    {
        navMeshSurfaces = gameObject.GetComponent<NavMeshSurface>();

        CreatGameMap();

        navMeshSurfaces.BuildNavMesh();
    }

    private void CreatGameMap()
    {
        gameGrid = new GameObject[height, width];

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                gameGrid[x, z] = Instantiate(gridPrefab, new Vector3(x, 0, z), Quaternion.identity);
                gameGrid[x, z].transform.parent = transform;
                gameGrid[x, z].gameObject.name = "Grid Space ( x: " + x.ToString() + " , Y: " + z.ToString() + ")";
            }
        }
    }
}
