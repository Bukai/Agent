using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Agent : MonoBehaviour
{

    public int lifeAgent;

    private void Update()
    {
        if (lifeAgent == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Agent")
        {
            lifeAgent--;
            Spawn_Agent.MyInstance.agentsInMap--;
        }
    }
}
