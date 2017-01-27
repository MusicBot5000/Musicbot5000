using UnityEngine;
using System.Collections;

public class DrumNoteController : NoteController {
    
    public float delay;
    private float startTime;
    public float nextTime;
    public float RollDelay;
    public bool isIn = false;

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    new void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        startTime = Time.unscaledTime;
        nextTime = startTime + delay;
    }

	void OnTriggerStay(Collider col)
    {
        isIn = true;
        if(Time.unscaledTime > nextTime)
        {
            //Debug.Log("line 27");
            //if (col.gameObject.tag == "Player") //TEMPORART FIX: WILL BE UNCOMMENTED WHEN DRUMSTICKS HAVE COLLIDERS
            {
                //Debug.Log("line 32");
                cont.SendMessage("PlayNote", note);
                nextTime = Time.unscaledTime + RollDelay;
                Debug.Log(nextTime);
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        isIn = false;
    }
}
