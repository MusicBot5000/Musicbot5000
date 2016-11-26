using UnityEngine;
using System.Collections;

public class fistStickToggler : MonoBehaviour {

    public GameObject Palm;
    public GameObject Stick;

    // Use this for initialization
    void Awake () {
    }

    void Start()
    {
        transform.eulerAngles = Palm.transform.eulerAngles;
        transform.position = Palm.transform.position;
    }

    // Update is called once per frame
    void Update () {
        transform.eulerAngles = Palm.transform.eulerAngles;
        transform.position = Palm.transform.position;
    }

    public void ShowStick()
    {
        StartCoroutine(ActivateStick(true));
    }

    public void HideStick()
    {
        StartCoroutine(ActivateStick(false));
    }

    IEnumerator ActivateStick(bool active)
    {
        Stick.SetActive(active);
        yield return null;
    }
}
