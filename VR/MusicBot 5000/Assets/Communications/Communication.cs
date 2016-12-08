using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using System.Net;

public class Communication : MonoBehaviour {

    SerialPort serial;
    public string IP_Address;
    public LoopStorage musicLoop;
    // Use this for initialization
    void Start () {
        //serial = new SerialPort("COM4", 9600);
        musicLoop = GameObject.FindGameObjectWithTag("GameController").GetComponent<LoopStorage>();
    }

    public void SendNum(string instrument, string note)
    {
        SendHTTPRequest(instrument + note);
        if (musicLoop.isLooping)
        {
            musicLoop.AddNote(instrument + note);
        }
    }


    public void SendHTTPRequest(string note)
    {
        WebRequest request = WebRequest.Create(IP_Address + note + "/VR Module");
        request.Credentials = CredentialCache.DefaultCredentials;
        request.Method = "GET";
        request.ContentType = "application/x-www-form-urlencoded";
        WebResponse response = request.GetResponse();
        Debug.Log("received: " + response.ToString());
    }
}
