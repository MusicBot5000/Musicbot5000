using UnityEngine;
using System.Collections;

public class MultizoneController : MonoBehaviour {

    public GameObject[] OtherZones;//The other hit zones in the instrument area
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider Col)
    {
        //Debug.Log("Triggered");
        for(int i = 0; i < OtherZones.Length; i++)
        {
            OtherZones[i].GetComponent<MeshCollider>().enabled = false;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        //Debug.Log("Not Triggered");
        for (int i = 0; i < OtherZones.Length; i++)
        {
            OtherZones[i].GetComponent<MeshCollider>().enabled = true;
        }
    }
}
