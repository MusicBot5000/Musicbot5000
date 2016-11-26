using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

    // Use this for initialization
    public Transform InstrumentSpot;
    public GameObject[] Instruments;
    GameObject InstrumentInst;
    public int InstrumentID;
    public bool MenuOpen;

	void Start () {
        InstrumentID = -1;
        MenuOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeInstrument(int Id)
    {
        if (InstrumentInst != null && Id!=InstrumentID)
        {
            Destroy(InstrumentInst);
        }
        if (Id >= 0 && Id!=InstrumentID)
        {
            InstrumentInst = Instantiate(Instruments[Id], InstrumentSpot) as GameObject;
        }
        InstrumentID = Id;
    }

}
