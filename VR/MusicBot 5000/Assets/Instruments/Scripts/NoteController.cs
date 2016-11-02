using UnityEngine;
using System.Collections;

public class NoteController : MonoBehaviour {

    public int note;
    InstrumentController cont;
	// Use this for initialization
	void Start () {
        cont = GameObject.FindGameObjectWithTag("Instrument").GetComponent<InstrumentController>() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            cont.SendMessage("PlayNote", note);
        }
    }
}
