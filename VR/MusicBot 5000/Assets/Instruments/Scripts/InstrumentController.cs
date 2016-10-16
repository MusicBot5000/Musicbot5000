using UnityEngine;
using System.Collections;

public class InstrumentController : MonoBehaviour {
    public string n;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayNote(string note)
    {
        n = note;
        Debug.Log("Note " + note + " played.");
    }
}
