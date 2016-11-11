using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public Transform InstrumentSpot;
    public GameObject[] Instruments;
    GameObject InstrumentInst;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeInstrument(int Id)
    {
        if (InstrumentInst != null)
        {
            Destroy(InstrumentInst);
        }
        if (Id >= 0)
        {
            InstrumentInst = Instantiate(Instruments[Id], InstrumentSpot) as GameObject;
        }
    }
}
