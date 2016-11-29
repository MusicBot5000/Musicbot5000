using UnityEngine;
using System.Collections;

public class InstrumentController : MonoBehaviour {
    public int n;
    public Communication comms;
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        comms = GameObject.FindGameObjectWithTag("GameController").GetComponent<Communication>();
    }

=======
	}
>>>>>>> refs/remotes/origin/master
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayNote(int note)
    {
        n = note;
        Debug.Log("Note " + note + " played.");
        comms.SendNum(note);
    }
}
