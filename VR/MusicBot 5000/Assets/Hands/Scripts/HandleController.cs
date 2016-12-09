using UnityEngine;
using System.Collections;

public class HandleController : MonoBehaviour {
    SliderController Slider;
	// Use this for initialization
	void Start () {
        Slider = transform.parent.parent.gameObject.GetComponent<SliderController>();
	}

    void OnTriggerEnter(Collider Other)
    {
        Slider.Sliding = true;
    }
    void OnTriggerExit(Collider Other)
    {
        Slider.Sliding = false;
    }
}
