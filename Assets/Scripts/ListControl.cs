using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;

public class ListControl : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    public GridObjectCollection scrollList;

    private readonly string libticketURL = "https://api.lib.fau.edu/systems";
    private readonly string reflibticketURL = "https://libticket.fau.edu/systems";
    bool working = true;

    void Start()
    {
        StartCoroutine(test());
        // StopCoroutine(APIHandler());
        scrollList.UpdateCollection();
        // APIHandler();
        // makeList(25);
    }

    IEnumerator test()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", "eng2022ed1");
        form.AddField("pass", "ARInLibrary");
        using (UnityWebRequest auth = UnityWebRequest.Post(libticketURL, form)) //open an authenticated session to make API calls in
        {
            yield return auth.SendWebRequest();
            if (auth.result == UnityWebRequest.Result.Success)
            {
                makeList();
            }
        }
    }

    void makeList()
    {
        for (var i = 0; i <= 25; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            button.GetComponent<ButtonControl>().SetText("Ticket Number: " + i + System.Environment.NewLine + "[summary]");
        }
        // working = false;
    }

    // IEnumerator APIHandler()
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("user", "eng2022ed1");
    //     form.AddField("pass", "ARInLibrary");
    //     using (UnityWebRequest auth = UnityWebRequest.Post(libticketURL, form)) //open an authenticated session to make API calls in
    //     {
    //         yield return auth.SendWebRequest();
    //         if (auth.result != UnityWebRequest.Result.Success)
    //         {
    //             // TODO: Error in environment
    //             Debug.Log(auth.error);
    //         }
    //         else
    //         {
    //             Debug.Log("Success");
    //             using (UnityWebRequest getTicketList = UnityWebRequest.Get("https://api.lib.fau.edu/systems/REST/1.0/search/ticket?query=Queue='General'ANDStatus='open'&orderby=-Created"))
    //             {
    //                 getTicketList.SetRequestHeader("referer", reflibticketURL); //set referer header
    //                 yield return getTicketList.SendWebRequest(); //make API call, wait for response
    //                 var resTicketList = getTicketList.downloadHandler.text;
    //                 string[] textList = resTicketList.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries); //split ticket into lines, ignore empty lines
    //                 var ticketList = new List<KeyValuePair<string, string>>();
    //                 foreach (var ticketText in textList) //for each ticket, create a key, value pair
    //                 {
    //                     var tmp = ticketText.Split(new string[] { ": " }, StringSplitOptions.None);
    //                     string ticketID;
    //                     string ticketSum;
    //                     if (tmp.Length > 1)
    //                     {
    //                         ticketID = tmp[0];
    //                         if (tmp.Length > 2)
    //                         {
    //                             ticketSum = tmp[1] + ": " + tmp[2];
    //                         }
    //                         else
    //                         {
    //                             ticketSum = tmp[1];
    //                         }
    //                         ticketList.Add(new KeyValuePair<string, string>(ticketID, ticketSum));
    //                     }
    //                 }
    //                 foreach (var ticket in ticketList)
    //                 {
    //                     GameObject button = Instantiate(buttonTemplate) as GameObject;
    //                     button.SetActive(true);
    //                     button.GetComponent<ButtonControl>().SetText("Ticket Number: " + ticket.Key + System.Environment.NewLine + ticket.Value);
    //                     button.transform.SetParent(buttonTemplate.transform.parent, false);
    //                 }
    //             }
    //         }
    //     }
    // }
}
