using UnityEngine;
using System.Collections;
using Leap;

public class menuToggler : MonoBehaviour
{


    public GameObject Palm;
    public GameObject[] Buttons;
    public bool LeftHand;

    private GameController GameCon;


    // Use this for initialization
    void Start()
    {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        transform.eulerAngles = Palm.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Palm.transform.eulerAngles;
        transform.position = Palm.transform.position;
        if (GameCon.EnvMenuOpen)
        {
            CloseMenu();
        }
    }

    IEnumerator ActivateOption(bool active)
    {
        bool TurnOn = active && !GameCon.EnvMenuOpen;
        switch (LeftHand)
        {
            case true:
                GameCon.LMenuOpen = TurnOn;
                break;

            case false:
                GameCon.RMenuOpen = TurnOn;
                break;
        }
        foreach (GameObject Button in Buttons)
        {
            Button.SetActive(TurnOn);
        }
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

    // Might try to animate the buttons soon
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
