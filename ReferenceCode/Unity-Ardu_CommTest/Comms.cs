using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Comms : MonoBehaviour {
    SerialPort serial;
    // Use this for initialization
    void Start () {
        serial = new SerialPort("COM7",9600);
        Debug.Log("hello");
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            serial.Open();
            serial.Write("hello");
            serial.Close();
        }
	}
}
