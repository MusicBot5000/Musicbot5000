using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

    // Use this for initialization

    // Instrument Control Variables
    public Transform InstrumentSpot;
    public GameObject[] Instruments;
    GameObject InstrumentInst;
    public int InstrumentID;

    // Hand Control Variables
    public bool LMenuOpen;
    public bool RMenuOpen;

    // Metronome Control Variables
    Metronome Metro;
    public bool MetronomeActive;
    public int MetronomeBPM;

    // Looping Control Varaibles
    public bool RecLoopActive;
    public bool PlayLoopActive;
    

	void Start () {
        Metro = GameObject.Find("Metronome").GetComponentInChildren<Metronome>();

        MetronomeBPM = 0;
        InstrumentID = -1;
        LMenuOpen = false;
        RMenuOpen = false;
        MetronomeActive = false;
        RecLoopActive = false;
        PlayLoopActive = false;
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


    // Called from actionToggler.cs
    // /Hands/Scripts/actionToggler.cs
    public void ToggleMetronome()
    {
        Metro.Toggle();
    }

    // Called from actionToggler.cs
    // /Hands/Scripts/actionToggler.cs
    public void ToggleRecLoop()
    {

        RecLoopActive = !RecLoopActive; // Use this variable and put this line in the record toggle function in the script
        Debug.Log("ToggleRecLoop "+RecLoopActive); //Line to be Deleted
    }

    // Called from actionToggler.cs
    // /Hands/Scripts/actionToggler.cs
    public void TogglePlayLoop()
    {
        PlayLoopActive = !PlayLoopActive; // Use this variable and put this line in the record toggle function in the script
        Debug.Log("TogglePlayLoop "+PlayLoopActive); //Line to be Deleted
        
    }

}
