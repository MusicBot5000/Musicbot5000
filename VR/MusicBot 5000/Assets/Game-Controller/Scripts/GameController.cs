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
    EnvMenuToggler EnvMenu;
    public bool LMenuOpen;
    public bool RMenuOpen;
    public bool EnvMenuOpen;

    // Metronome Control Variables
    Metronome Metro;
    public bool MetronomeActive;
    public double MetronomeBPM;

    // Looping Control Varaibles
    public bool RecLoopActive;
    public bool PlayLoopActive;
    public LoopStorage looper;
    

	void Start () {
        InstrumentID = -1;

        LMenuOpen = false;
        RMenuOpen = false;
        EnvMenuOpen = false;
        EnvMenu = GameObject.Find("EnvSelection").GetComponentInChildren<EnvMenuToggler>();

        MetronomeActive = false;
        MetronomeBPM = 100;
        Metro = GameObject.Find("Metronome").GetComponentInChildren<Metronome>();

        RecLoopActive = false;
        PlayLoopActive = false;
        looper = GameObject.FindGameObjectWithTag("GameController").GetComponent<LoopStorage>();
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

    public void ToggleEnvMenu()
    {
        EnvMenu.Toggle();
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
        looper.StartLoop();//The looper will start recording.
        Debug.Log("ToggleRecLoop "+RecLoopActive); //Line to be Deleted
    }

    // Called from actionToggler.cs
    // /Hands/Scripts/actionToggler.cs
    public void TogglePlayLoop()
    {
        PlayLoopActive = !PlayLoopActive; // Use this variable and put this line in the record toggle function in the script
        looper.PlayLoop();
        Debug.Log("TogglePlayLoop "+PlayLoopActive); //Line to be Deleted
        
    }

}
