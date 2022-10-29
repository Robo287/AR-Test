using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDashboardController : MonoBehaviour
{
    public GameObject UI;

    public void OnPressed()
    {
        Debug.Log("UI Opened!");
        UI.SetActive(true);
    }
}
