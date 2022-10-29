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

    // public string TextString;
    private readonly string libticketURL = "https://api.lib.fau.edu/systems";
    private readonly string reflibticketURL = "https://libticket.fau.edu/systems";

    public void SetText(string textString)
    {
        btnText.SetText(textString); //take button text and set it to btnText
        // TextString = textString;
    }

        public void OnClick()
    {
        var tmp = btnText.text.Split(new string[] { ": " }, StringSplitOptions.None); //get text from the button
        var tmp2 = tmp[1].Split(new string[] { "\n" }, StringSplitOptions.None); //isolate the ticket number
        Debug.Log(tmp2[0]);
        // showTicketInfo(tmp2[0]);
    }
}
