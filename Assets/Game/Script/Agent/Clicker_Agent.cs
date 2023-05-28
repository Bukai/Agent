using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clicker_Agent : MonoBehaviour
{
    private static Clicker_Agent instance;

    public static Clicker_Agent MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Clicker_Agent>();
            }

            return instance;
        }

    }

    [SerializeField]
    private Material agentMaterial, selectedAgentMaterial;

    [SerializeField]
    private GameObject agentPanelInfo;

    [SerializeField]
    private TextMeshProUGUI agentName, agentLifeCount;

    private GameObject agentHit;

    [HideInInspector]
    public bool agentPanelIsOpen;

    private void Awake()
    {
        agentPanelInfo.SetActive(false);

        agentPanelIsOpen = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            GameObject agent = GameObject.FindGameObjectWithTag("Agent");

            if (Physics.Raycast(ray, out hit))
            {
                var selectionAgent = hit.transform;
                var selectionAgentRenderer = selectionAgent.GetComponent<Renderer>();

                if (agentPanelIsOpen == true)
                {
                    uncheckAgent();
                }

                if (hit.collider.tag == agent.tag)
                {
                    agentHit = hit.transform.gameObject;

                    if (selectionAgentRenderer != null)
                    {
                        selectionAgentRenderer.material = selectedAgentMaterial;
                    }

                    agentPanel();
                }
            }
        }
    }

    private void agentPanel()
    {
        agentPanelInfo.SetActive(true);
        agentName.text = agentHit.name;
        agentLifeCount.text = agentHit.GetComponent<Life_Agent>().lifeAgent.ToString();
        agentPanelIsOpen = true;
    }

    public void uncheckAgent()
    {
        agentPanelIsOpen = false;

        if (agentHit != null)
        {
            agentHit.GetComponent<Renderer>().material = agentMaterial;
        }
        
        agentPanelInfo.SetActive(false);
    }
}
