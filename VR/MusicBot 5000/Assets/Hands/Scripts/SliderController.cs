using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SliderController : MonoBehaviour {
    GameObject SlideArea;
    GameObject SlideThumb;
    GameController GameCon;
    public Slider Slide;
    public Text Tempo;
    private float pos;

    public bool Sliding;
	// Use this for initialization
	void Start () {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        SlideArea = transform.Find("Handle Slide Area").gameObject;
        SlideThumb = SlideArea.transform.Find("Handle").gameObject;
	}

    void OnTriggerStay(Collider Other)
    {
        if (Sliding && Other.tag=="MenuPointer")
        {
            pos = (transform.InverseTransformPoint(Other.transform.position).x + 90) / 160;
            Slide.value = pos;
            GameCon.MetronomeBPM = Convert.ToInt32(Slide.value * 180);
            Tempo.text = String.Format("{0}\nBPM",GameCon.MetronomeBPM);
        }
    }
}
