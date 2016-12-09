using UnityEngine;
using System.Collections;

public class HandleAreaController : MonoBehaviour {
    private SliderController Slider;
    // Use this for initialization
    void Start () {
        Slider = transform.parent.gameObject.GetComponent<SliderController>();
    }
}
