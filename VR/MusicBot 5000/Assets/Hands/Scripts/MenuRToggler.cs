using UnityEngine;
using System.Collections;

public class MenuRToggler : MonoBehaviour {

    public GameObject RPalm;

    public GameObject MetroOption, LoopOption, MetroSlider;

    private GameController GameCon;

    // Use this for initialization
    void Start () {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        transform.eulerAngles = RPalm.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = RPalm.transform.eulerAngles;
        transform.position = RPalm.transform.position;
    }

    IEnumerator ActivateOption(bool active)
    {
        GameCon.RMenuOpen = active;
        MetroOption.SetActive(active);
        LoopOption.SetActive(active);
        yield return null;
    }

    public void OpenMenu()
    {
        StartCoroutine(ActivateOption(true));
    }

    public void CloseMenu()
    {

        StartCoroutine(ActivateOption(false));
    }
}
