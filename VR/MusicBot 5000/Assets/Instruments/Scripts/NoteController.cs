using UnityEngine;
using System.Collections;

public class NoteController : MonoBehaviour {

    public string note;
    public InstrumentController cont;
	// Use this for initialization
	protected void Start () {
        cont = GameObject.FindGameObjectWithTag("Instrument").GetComponent<InstrumentController>() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void OnTriggerEnter(Collider col)
    {
        cont = GameObject.FindGameObjectWithTag("Instrument").GetComponent<InstrumentController>();
        if (col.gameObject.tag == "Player")
        {
            Vector3 ColliderPosition = transform.InverseTransformPoint(col.transform.position);
            ColliderPosition.y -= transform.GetComponent<BoxCollider>().center.y;
            if (ColliderPosition.y > -0.008)
            {
                Debug.Log(ColliderPosition.y);
                cont.SendMessage("PlayNote", note);
            }
        }
    }
}
