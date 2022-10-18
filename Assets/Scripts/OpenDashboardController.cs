using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDashboardController : MonoBehaviour
{

    public Text Textfield;
    public GameObject Cube;

    public void OnPressed(string text)
    {
        Debug.Log("Open the dashboard!");
        Textfield.text = text;
        Cube.SetActive(true);
    }
}
