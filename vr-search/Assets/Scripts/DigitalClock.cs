using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net.NetworkInformation;
using System.Collections;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private string alternativeTime = "12:34";

    private bool blinkColon = true;

    void Start()
    {
        StartCoroutine(UpdateTimeCoroutine());
    }

    IEnumerator UpdateTimeCoroutine()
    {
        while (true)
        {
            if (IsInternetAvailable())
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

    string BlinkColon(string time)
    {
        if (blinkColon)
        {
            return time;
        }
        else
        {
            return time.Substring(0, 2) + " " + time.Substring(3, 2);
        }
    }

    bool IsInternetAvailable()
    {
        try
        {

            using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
            {
                PingReply reply = ping.Send("8.8.8.8", 1000); // Google DNS
                return (reply.Status == IPStatus.Success);
            }
        }
        catch
        {
            return false;
        }
    }

    void Update()
    {
        blinkColon = !blinkColon;
    }
}
