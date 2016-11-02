using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

public class Communication : MonoBehaviour {

    SerialPort serial;
   
    // Use this for initialization
    void Start () {
        serial = new SerialPort("COM4", 9600);
    }

    public void SendNum(int note)
    {
        serial.Open();
        serial.Write(note+"");
        serial.Close();
    }

}
