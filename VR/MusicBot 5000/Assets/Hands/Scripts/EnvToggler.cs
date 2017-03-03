using UnityEngine;
using System.Collections;

public class EnvToggler : MonoBehaviour {

    public GameController GameCon;

    // Use this for initialization
    void Start()
    {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "MenuPointer")
        {
            GameCon.ToggleEnvMenu(transform.name);
            string log = string.Format("The {0} Environment Selected", transform.name);
            Debug.Log(log);
        }
    }
}
