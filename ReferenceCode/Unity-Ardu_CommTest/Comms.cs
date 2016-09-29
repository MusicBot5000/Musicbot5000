using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Comms : MonoBehaviour {
    SerialPort serial;
    // Use this for initialization
    void Start () {
        serial = new SerialPort("COM7",9600); // My arduino was connected to COM7 change this for you guys
	    				      // baud rate has to match ardu
	    
        Debug.Log("hello"); // check to see if this script is running in unity by seeing if the console displays this
	}
	
	// Update is called once per frame
	void Update () {
        
		//If the up arrow key is pressed, send "hello" to ardu. You can play with what I send.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            serial.Open();
            serial.Write("hello");
            serial.Close();
        }
	}
}
