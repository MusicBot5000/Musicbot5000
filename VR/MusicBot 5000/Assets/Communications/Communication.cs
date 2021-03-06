﻿using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using System.Net;

public class Communication : MonoBehaviour {

    SerialPort serial;
    public string IP_Address;
    public int port;
    public LoopStorage musicLoop;
    public bool DONTCONNECT;
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
            //Debug.Log("IN COMMS" + instrument + note);
            musicLoop.AddNote(instrument + note);
        }
    }


    public void SendHTTPRequest(string note)
    {
        if (!DONTCONNECT)
        {
            WebRequest request = WebRequest.Create("http://" + IP_Address + ":" + port + "/note/" + note + "/VR Module");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse response = request.GetResponse();
            Debug.Log("received: " + response.ToString());
        }
    }
}
