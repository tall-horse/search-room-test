using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private string alternativeTime = "12:34";
    void Start()
    {
        StartCoroutine(UpdateTimeCoroutine());
    }

    IEnumerator UpdateTimeCoroutine()
    {
        while (true)
        {
            bool internetAvailable = false;
            yield return StartCoroutine(CheckInternetConnection((isAvailable) => internetAvailable = isAvailable));

            if (internetAvailable)
            {
                DateTime currentTime = DateTime.Now;
                string timeString = currentTime.ToString("HH:mm");
                timeText.text = timeString;
            }
            else
            {
                timeText.text = alternativeTime;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CheckInternetConnection(Action<bool> callback)
    {
        using (var request = new UnityEngine.Networking.UnityWebRequest("https://www.google.com"))
        {
            request.method = UnityEngine.Networking.UnityWebRequest.kHttpVerbHEAD;
            request.timeout = 2;
            yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (request.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
#else
        if (!request.isNetworkError && !request.isHttpError)
#endif
            {
                callback(true);
            }
            else
            {
                callback(false);
            }
        }
    }
}
