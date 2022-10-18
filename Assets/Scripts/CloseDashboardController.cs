using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseDashboardController : MonoBehaviour
{

    public Text Textfield;
    public GameObject Cube;

    public void OnPressed(string text)
    {
        Debug.Log("Close the dashboard!");
        Textfield.text = text;
        Cube.SetActive(false);
    }
}
