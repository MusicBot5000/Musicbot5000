using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{

    public readonly int frequency = 44100;
    public readonly int maxLength = 20 * 44100;
    public bool isLooping = false;
    public Button myButton;
    public System.Collections.Generic.Queue<byte> loop;

    // Use this for initialization
    void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(StartLoop);

    }

    // Update is called once per frame
    void Update()
    {

    }

    // starts or stops looping storage
    public void StartLoop()
    {
        isLooping = !isLooping;
        if (isLooping)
        {
            StartCoroutine("ReadData");
        }
        else
        {
            StopCoroutine("ReadData");
        }
    }

    // runs for 20 seconds or until looping storage is manually ended
    IEnumerator ReadData()
    {
        loop = new System.Collections.Generic.Queue<byte>();
        for (int i =0;i<maxLength;i++)
        {
            // store 1 byte that represents if a note is pressed
        }
        yield return null;
    }

}
