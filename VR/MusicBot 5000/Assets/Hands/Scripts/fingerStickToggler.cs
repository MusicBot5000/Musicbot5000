using UnityEngine;
using System.Collections;

public class fingerStickToggler : MonoBehaviour
{
    
    public GameObject Hand;
    public GameObject Finger;
    public GameObject Stick;
    private GameObject Tip, Knuckle;
    private Vector3 FingerVector, KnuckleVector;

    // Use this for initialization
    void Awake()
    {
    }

    void Start()
    {
        Tip = Finger.transform.FindChild("bone3").gameObject;
        Knuckle = Finger.transform.FindChild("bone1").gameObject;

        FingerVector = Tip.transform.position - Knuckle.transform.position;
        Stick.transform.rotation = Quaternion.LookRotation(FingerVector.normalized);
        Stick.transform.position = Knuckle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FingerVector = Tip.transform.position - Knuckle.transform.position;
        Stick.transform.rotation = Quaternion.LookRotation(FingerVector.normalized);
        KnuckleVector = Knuckle.transform.position;
        KnuckleVector.z -= 0.11f;
        Stick.transform.position = KnuckleVector;
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
        Hand.SetActive(!active);
        Stick.SetActive(active);
        yield return null;
    }
}
