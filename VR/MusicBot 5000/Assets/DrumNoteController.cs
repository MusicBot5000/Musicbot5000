using UnityEngine;
using System.Collections;

public class DrumNoteController : NoteController {
    
    public float delay;
    public string note2;
    private float nextTime;
    public float nextRoll;
    private bool roll1;

	// Use this for initialization
	new void Start () {
        base.Start();
        roll1 = true;
	}

    new void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        nextTime = Time.unscaledTime+delay;
    }

	void OnTriggerStay(Collider col)
    {
        if(Time.unscaledTime > nextTime)
        {
            if (col.gameObject.tag == "Player")
            {
                nextTime = Time.unscaledTime + nextRoll;
                if (roll1)
                {
                    cont.SendMessage("PlayNote", note);
                }else
                {
                    cont.SendMessage("PlayNote", note2);
                }
                roll1 = !roll1;
            }
        }
    }

    //void OnTriggerExit(Collider col)
    //{
    //    if(col.gameObject.tag == "Player")
    //    {
    //        cont.SendMessage("PlayNote", endRoll);
    //    }
    //}
}
