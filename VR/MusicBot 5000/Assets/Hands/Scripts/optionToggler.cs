using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

public class optionToggler : MonoBehaviour {

    public int Instrument;
    public Material UnSelected;
    public Material Selected;
    SerialPort serial;
    public GameObject Me;
    public GameObject Other1;
    public GameObject Other2;
    Material MeMat;
    Material O1Mat;
    Material O2Mat;
    GameController GameCon;

    // Use this for initialization
    void Start () {
        MeMat = Me.GetComponent < Renderer >().material;
        O1Mat = Other1.GetComponent<Renderer>().material;
        O2Mat = Other2.GetComponent<Renderer>().material;
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MenuPointer"))
        {
            GameCon.ChangeInstrument(Instrument);
            MeMat.color = Selected.color;
            O1Mat.color = UnSelected.color;
            O2Mat.color = UnSelected.color;
        }
    }

}
