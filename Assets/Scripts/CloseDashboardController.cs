using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseDashboardController : MonoBehaviour
{
    public GameObject UI;

    public void OnPressed()
    {
        Debug.Log("UI Closed!");
        UI.SetActive(false);
    }
}
