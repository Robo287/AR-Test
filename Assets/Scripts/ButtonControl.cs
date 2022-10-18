using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using System.Net.Http;
using UnityEngine.Networking;
using TMPro;


public class ButtonControl : MonoBehaviour
{
    [SerializeField] public TextMeshPro btnText;

    public void SetText(string textString)
    {
        btnText.SetText(textString); //take button text and set it to btnText
        // TextString = textString;
    }
}
