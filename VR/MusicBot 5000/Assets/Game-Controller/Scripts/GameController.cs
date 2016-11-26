using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class GameController : MonoBehaviour
{
=======
public class GameController : MonoBehaviour {
>>>>>>> refs/remotes/origin/master

    // Use this for initialization
    public Transform InstrumentSpot;
    public GameObject[] Instruments;
    GameObject InstrumentInst;
    public int InstrumentID;


<<<<<<< HEAD
    void Start()
    {
        InstrumentID = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeInstrument(int Id)
    {
        if (InstrumentInst != null && Id != InstrumentID)
        {
            Destroy(InstrumentInst);
        }
        if (Id >= 0 && Id != InstrumentID)
=======
	void Start () {
        InstrumentID = -1;
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
>>>>>>> refs/remotes/origin/master
        {
            InstrumentInst = Instantiate(Instruments[Id], InstrumentSpot) as GameObject;
        }
        InstrumentID = Id;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> refs/remotes/origin/master
