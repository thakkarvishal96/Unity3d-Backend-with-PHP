using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class web : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        StartCoroutine(Gettext());

    }

    IEnumerator Gettext() 
    {
        using (UnityWebRequest WWW = UnityWebRequest.Get("http://localhost/unity/Userdata.php"))
        {
            // Request and wait for the desired page.
            yield return WWW.Send();


            if (WWW.isNetworkError || WWW.isHttpError)
            {
                Debug.Log(": Error: " + WWW.error);
            }
            else
            {
                Debug.Log(":\nReceived: " + WWW.downloadHandler.text);

                byte[] results = WWW.downloadHandler.data;
            }
        }
    }
}