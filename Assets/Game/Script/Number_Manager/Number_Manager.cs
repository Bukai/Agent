using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Number_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject numbersPanel;

    [SerializeField]
    private int maxNumber;

    [SerializeField]
    private TextMeshProUGUI numbersText;

    private string marko = "Marko";
    private string polo = "Polo";

    private void Awake()
    {
        numbersPanel.SetActive(false);
    }

    public void OpenNumbersPanel()
    {
        numbersPanel.SetActive(true);

        for (int i = 1; i < maxNumber; i++)
        {
            if (i % 3 == 0 && i % 5 != 0)
            {
                numbersText.text += marko + "<br>";
            }
            else if (i % 5 == 0 && i % 3 != 0)
            {
                numbersText.text += polo + "<br>";
            }
            else if (i % 3 == 0 && i % 5 == 0)
            {
                numbersText.text += marko + polo + "<br>";
            }
            else
            {
                numbersText.text += i.ToString() + "<br>";
            }
        }
    }

    public void CloseNumbersPanel()
    {
        numbersPanel.SetActive(false);
    }
}
