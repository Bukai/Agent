using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Agent : MonoBehaviour
{

    private static Life_Agent instance;

    public static Life_Agent MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Life_Agent>();
            }

            return instance;
        }

    }

    private MeshRenderer agentSprite;

    [SerializeField]
    private Material agentMaterial;

    [SerializeField]
    private float flashLenght;

    public int lifeAgent;

    private float flashCounter;

    private bool damagebreak = false;
    private bool colorchange = true;
    private bool coroutineCalled = false;

    private void Start()
    {
        agentSprite = GetComponent<MeshRenderer>();

        flashCounter = flashLenght;
    }

    private void FixedUpdate()
    {
        if (colorchange && damagebreak)
        {
            if (!coroutineCalled)
            {
                StartCoroutine(color());
            }
        }
        else
        {
            agentSprite.material = agentMaterial;
        }

        if (flashCounter <= 0)
        {
            damagebreak = false;
            colorchange = false;
            flashCounter = flashLenght;
        }

        if (damagebreak)
        {
            flashCounter -= 1 * Time.deltaTime;
            colorchange = true;
        }
    }

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
            damagebreak = true;
            lifeAgent--;
            Spawn_Agent.MyInstance.agentsInMap--;
        }
    }

    IEnumerator color()
    {
        while (colorchange && damagebreak)
        {
            coroutineCalled = true;
            agentSprite.material.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            agentSprite.material.color = Color.white;
            yield return new WaitForSeconds(0.3f);
        }

        coroutineCalled = false;
    }
}
