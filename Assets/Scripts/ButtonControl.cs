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
    public Text InfoText;
    public GameObject ResultsUI;
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
        // InfoText.text = tmp2[0];
        showTicketInfo(tmp2[0]);
    }

    public void showTicketInfo(string ticketNumber)
    {
        Debug.Log("showTicketInfo called, parsed: " + ticketNumber);
        StartCoroutine(APIHandler(ticketNumber));
    }

    public IEnumerator APIHandler(string ticketNumber)
    {
        Debug.Log("APIHandler Coroutine started, parsed: " + ticketNumber);
        Uri getURI = new Uri("https://api.lib.fau.edu/systems/REST/1.0/ticket/" + ticketNumber);
        // Uri getURI = new Uri("https://api.lib.fau.edu/systems/REST/1.0/ticket/17599");

        WWWForm form = new WWWForm();
        form.AddField("user", "eng2022ed1");
        form.AddField("pass", "ARInLibrary");
        using (UnityWebRequest auth = UnityWebRequest.Post(libticketURL, form))
        {
            yield return auth.SendWebRequest();
            if (auth.result != UnityWebRequest.Result.Success)
            {
                // TODO: Error message
                Debug.Log(auth.error);
            }
            else
            {
                Debug.Log("Success");
                Debug.Log(getURI);
                using (UnityWebRequest getTicketInfo = UnityWebRequest.Get(getURI))
                {
                    getTicketInfo.SetRequestHeader("referer", reflibticketURL); //set referer header
                    yield return getTicketInfo.SendWebRequest();
                    Debug.Log(getTicketInfo.downloadHandler.text);
                    var infoText = getTicketInfo.downloadHandler.text; //display result
                    InfoText.text = infoText;
                    ResultsUI.SetActive(true);
                    // if(onTicketInfoComplete != null)
                    // {
                    //     onTicketInfoComplete(this, infoText);
                    // }
                }
            }
        }
    }
}
