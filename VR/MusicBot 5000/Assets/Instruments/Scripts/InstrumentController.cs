using UnityEngine;
using System.Collections;

public class InstrumentController : MonoBehaviour {
    public string n;
    public string Instrument;
    public Communication comms;
	// Use this for initialization
	void Start () {
        comms = GameObject.FindGameObjectWithTag("GameController").GetComponent<Communication>();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayNote(string note)
    {
        n = note;
        Debug.Log("Note " + note + " played.");
        comms.SendNum(Instrument, note);
    }
}
