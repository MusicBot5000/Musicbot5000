using UnityEngine;
using System.Collections;

public class actionToggler : MonoBehaviour {

    private GameController GameCon;
    public Canvas MetronomeInfo;

    private menuToggler Menu;

    public Material Toggled;
    public Material UnToggled;

    private GameObject Selector;
    private Material SelectorMat;

    private bool ActionActive;

    // Use this for initialization
    void Start () {
        Selector = transform.Find("OuterButton").gameObject;
        SelectorMat = Selector.GetComponent<Renderer>().material;

        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider Other)
    {
        // The Metronome is toggled in the Metronome.cs file by polling this boolean variable.
        if (Other.tag == "MenuPointer")
        {
            switch (transform.gameObject.name)
            {
                case "MetroButton":
                    GameCon.ToggleMetronome();
                    ActionActive = GameCon.MetronomeActive;
                    MetronomeInfo.gameObject.SetActive(GameCon.MetronomeActive);
                    break;
                case "RecButton":
                    GameCon.ToggleRecLoop();
                    ActionActive = GameCon.RecLoopActive;
                    break;
                case "PlayButton":
                    GameCon.TogglePlayLoop();
                    ActionActive = GameCon.PlayLoopActive;
                    break;
                case "EnvButton":
                    GameCon.ToggleEnvMenu(null);
                    break;
                default:
                    Debug.LogError("ERROR: Not valid button");
                    break;
            }

            if (ActionActive)
            {
                SelectorMat.color = Toggled.color;
            }
            else
            {
                SelectorMat.color = UnToggled.color;
            }
        }
    }
}
