using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoHomeController : MonoBehaviour
{
    public Text Textfield;

    public void OnPressed(string text)
    {
        Debug.Log("Home Button Pressed!");
        Textfield.text = text;
    }
}
