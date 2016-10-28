using UnityEngine;
using System.Collections;
using Leap;

public class menuToggler : MonoBehaviour {
    
    public GameObject LPalm;

    Vector3 RedPos, BluePos, GreenPos, ClosePos;

    public GameObject DrumOption, XyloOption, ExitOption;

    private IEnumerator _OpenMenu, _CloseMenu;

    void Awake()
    {
        //RedOption = GameObject.Find("Menu/Options/Red");
        //BlueOption = GameObject.Find("Menu/Options/Blue");
        //GreenOption = GameObject.Find("Menu/Options/Green");

        //DrumOption = GameObject.Find("Menu/Buttons/DrumButton");
        //XyloOption = GameObject.Find("Menu/Buttons/XylophoneButton");
        //ExitOption = GameObject.Find("Menu/Buttons/XButton");

        //ClosePos = new Vector3(0f, 0f, 0f);

        //RedPos = new Vector3(-0.074f,-0.013f,-0.136f);
        //BluePos = new Vector3(-0.107f, -0.012f, -0.073f);
        //GreenPos = new Vector3(-0.085f, -0.012f, -0.011f);

        _OpenMenu = ActivateOption(true);

        _CloseMenu = ActivateOption(false);
    }

    // Use this for initialization
    void Start () {
        transform.eulerAngles = LPalm.transform.eulerAngles;
    }

    


    // Update is called once per frame
    void Update () {
        transform.eulerAngles = LPalm.transform.eulerAngles;
        transform.position = LPalm.transform.position;
    }

    IEnumerator ActivateOption(bool active)
    {
        //RedOption.SetActive(active);
        //BlueOption.SetActive(active);
        //GreenOption.SetActive(active);
        DrumOption.SetActive(active);
        XyloOption.SetActive(active);
        ExitOption.SetActive(active);
        yield return null;
    }

    public void OpenMenu()
    {
        StartCoroutine(ActivateOption(true));
        //StartCoroutine(MoveObject(RedOption,ClosePos,RedPos));
        //StartCoroutine(MoveObject(BlueOption, ClosePos, BluePos));
        //StartCoroutine(MoveObject(GreenOption, ClosePos, GreenPos));
    }

    public void CloseMenu()
    {
        StartCoroutine(ActivateOption(false));
        //StartCoroutine(MoveObject(RedOption, RedPos, ClosePos));
        //StartCoroutine(MoveObject(BlueOption, BluePos, ClosePos));
        //StartCoroutine(MoveObject(GreenOption, GreenPos, ClosePos));
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
