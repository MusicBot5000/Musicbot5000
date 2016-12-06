using UnityEngine;
using System.Collections;
using Leap;

public class menuToggler : MonoBehaviour {
    
    
    public GameObject LPalm;

    Vector3 RedPos, BluePos, GreenPos, ClosePos;

    public GameObject DrumOption, XyloOption, ExitOption;

    private IEnumerator _OpenMenu, _CloseMenu;

    private GameController GameCon;

    void Awake()
    {

        _OpenMenu = ActivateOption(true);

        _CloseMenu = ActivateOption(false);
    }

    // Use this for initialization
    void Start () {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        transform.eulerAngles = LPalm.transform.eulerAngles;
    }

    


    // Update is called once per frame
    void Update () {
        transform.eulerAngles = LPalm.transform.eulerAngles;
        transform.position = LPalm.transform.position;
    }

    IEnumerator ActivateOption(bool active)
    {
        GameCon.LMenuOpen = active;
        DrumOption.SetActive(active);
        XyloOption.SetActive(active);
        ExitOption.SetActive(active);
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

    IEnumerator MoveObject(GameObject obj, Vector3 startPos, Vector3 endPos)
    {
        float progress = 0.0f;
        float speed = 0.0001f;

        while (progress < 1.0f)
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, progress);

            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * speed;
        }

        obj.transform.position = endPos;
    }
}
