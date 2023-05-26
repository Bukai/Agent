using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Agent : MonoBehaviour
{
    private static Spawn_Agent instance;

    public static Spawn_Agent MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<Spawn_Agent>();
            }

            return instance;
        }

    }

    [SerializeField]
    private GameObject spawnerAgentPrefab;

    [SerializeField]
    private int agentsInStart;

    [SerializeField]
    private int maxAgentInMap;

    [HideInInspector]
    public int agentsInMap;

    [Range(2, 6)][SerializeField]
    private float spawnerTime;

    private int agentId;

    void Start()
    {
        for (int i = 0; i < agentsInStart; i++)
        {
            agentsInMap++;
            Instantiate(spawnerAgentPrefab, new Vector3(Random.Range((GameGrid.MyInstance.width * 0.2f), GameGrid.MyInstance.width * 0.9f), 0, Random.Range((GameGrid.MyInstance.height * 0.2f), GameGrid.MyInstance.height * 0.9f)), Quaternion.identity);
            spawnerAgentPrefab.name = "Agent id: " + agentId++;
        }

        StartCoroutine(spawnEnemy(spawnerTime, spawnerAgentPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject agent)
    {
        yield return new WaitForSeconds(interval);
        if (agentsInMap < maxAgentInMap)
        {
            GameObject newEnemy = Instantiate(agent, new Vector3(Random.Range((GameGrid.MyInstance.width * 0.2f), GameGrid.MyInstance.width * 0.9f), 0, Random.Range((GameGrid.MyInstance.height * 0.2f), GameGrid.MyInstance.height * 0.9f)), Quaternion.identity);
            agent.name = "Agent id: " + agentId++;
            StartCoroutine(spawnEnemy(interval, agent));
            agentsInMap++;
        }
        else
        {
            StartCoroutine(spawnEnemy(interval, null));
        }
    }
}
