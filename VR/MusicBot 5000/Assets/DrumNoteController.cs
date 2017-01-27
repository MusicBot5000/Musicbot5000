using UnityEngine;
using System.Collections;

public class DrumNoteController : NoteController {
    
    public float delay;
    public string endRoll;
    private float startTime;

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    new void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        startTime = Time.unscaledTime;
    }

	void OnTriggerStay(Collider col)
    {
        if(Time.unscaledTime - startTime > delay)
        {
            if (col.gameObject.tag == "Player")
            {
                cont.SendMessage("PlayNote", note);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            cont.SendMessage("PlayNote", endRoll);
        }
    }
}
