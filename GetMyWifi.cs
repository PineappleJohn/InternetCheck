using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GetMyWifi : MonoBehaviour
{
    public UnityEvent UnityEvent;
    private readonly string link = "";
    private void Start() => StartCoroutine(SendRequest());

    IEnumerator SendRequest()
    {
        yield return new WaitForSeconds(5);
        using UnityWebRequest www = UnityWebRequest.Get(link);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            //no WiFi!!!!
            UnityEvent.Invoke();
            yield break;
        }
    }
}
