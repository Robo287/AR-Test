using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ComputerSceneController : MonoBehaviour
{
    public Text Results;
    private readonly string labstatsurl = "https://api.labstats.com";
    private readonly string TOKEN = "4504d01b-7154-4ea7-99e4-b797c30beaf4";
    void Start()
    {
        StartCoroutine(APIHandler());
    }

    IEnumerator APIHandler()
    {
        using (UnityWebRequest getList = UnityWebRequest.Get(labstatsurl + "/groups/"))
        {
            Debug.Log("Testing API");
            getList.SetRequestHeader("Authorization", "Bearer " + TOKEN); //set authorization token
            yield return getList.SendWebRequest(); //make API call
            var apiRes = getList.downloadHandler.text;
            Results.text = apiRes;
        }
    }
}
