using UnityEngine;
using System.Collections;

public class LoopStorage : MonoBehaviour
{

    public bool isLooping = false;
    public bool playing = false;

    public bool notePlayed = false;

    
    //public Text status;
    public float refTime;
    public long maxSeconds = 5;
    public const long maxLoopTime = 5000;
    public Loop loop;
    public float lastTime;

    public Communication comms;

    // Use this for initialization
    void Start()
    {
        loop = null;
        comms = GameObject.FindGameObjectWithTag("GameController").GetComponent<Communication>();
    }


    // starts or stops looping storage
    public void StartLoop(bool something)
    {
        isLooping = !isLooping;
        if (isLooping)
        {
            //loop = null; // TODO: Change this as necessary
            loop = null;
            refTime = Time.unscaledTime;
        }
    }

    public void AddNote(string note)
    {
        float noteTime = Time.unscaledTime;
        if(loop == null)
        {
            loop = new Loop(note, noteTime);
        }
        else
        {
            loop.addNote(note, noteTime);
        }
    }

    // runs for 20 seconds or until looping is manually ended
    //IEnumerator RecordData()
    //{
    //    float curr = 0;
    //    float prev = refTime;
    //    float elapsed = (curr - refTime);
    //    string id;

    //    double delay;
    //    Debug.Log("Start Loop");

    //    while (elapsed < maxLoopTime && isLooping)
    //    {
    //        curr = DateTime.Now;
    //        elapsed = (curr - refTime);

    //        if (notePlayed)
    //        {
    //            id = "";//TODO get input from user
    //            delay = (curr - prev).TotalMilliseconds;

    //            if (loop == null)
    //            {
    //                loop = new Loop(id, delay);
    //                Debug.Log(loop.getHead().getId());
    //            }
    //            else
    //            {
    //                loop.addNote(id, delay);
    //            }
    //            notePlayed = false;
    //            prev = curr;
    //        }

    //        yield return null;

    //    }
    //    Debug.Log("End Loop");
    //    status.text = "Not Looping";
    //    myTrigger.isOn = false;
    //}

    // starts or stops playback of loop
    public void PlayLoop(bool something)
    {
        playing = !playing;
        if (playing)
        {
            StartCoroutine("PlayData");
        }
        else
        {
            StopCoroutine("PlayData");
        }

    }

    // runs loop until stop command is set
    IEnumerator PlayData()
    {
        string id;
        double delay;
        if (loop == null || loop.getHead() == null)
        {
            // there is no loop to play
            Debug.Log("No Loops Available!");


        }
        else
        {
            //status.text = "Playback Loop";
            Note temp = loop.getHead();
            for (;;)
            {
                // traverse loop and return stuff and add appropriate delays
                id = temp.getId();
                delay = temp.getDelay();
                //EditorApplication.Beep();
                yield return new WaitForSeconds((float)delay / 1000.0f);
                //TODO: Send this to the arduino 
                //EditorApplication.Beep();
                comms.SendHTTPRequest(id);
                temp = temp.getNext();

            }
        }
    }

}
