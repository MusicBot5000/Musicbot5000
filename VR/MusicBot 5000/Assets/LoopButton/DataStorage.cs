using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Timers;





public class DataStorage : MonoBehaviour
{

	public bool isLooping = false;
	public Toggle myTrigger;
	public Text status;
	public DateTime refTime;
	public long maxSeconds = 5;
	public const long maxLoopTime = 5000;
	public Loop loop;

	// Use this for initialization
	void Start()
	{
		
		myTrigger.onValueChanged.AddListener (StartLoop);


	}

	// Update is called once per frame
	void Update()
	{

	}

	// starts or stops looping storage
	public void StartLoop(bool something)
	{
		isLooping = !isLooping;
		if (isLooping)
		{
			StartCoroutine("ReadData");
		}
	}

	// runs for 20 seconds or until looping is manually ended
	IEnumerator ReadData()
	{
		loop = new Loop();
		refTime = DateTime.Now;
		DateTime curr = DateTime.Now;
		double elapsed = (curr - refTime).TotalMilliseconds;
		int inst;
		int note;
		Debug.Log("Start Loop");
		status.text = "Looping";
		while (elapsed < maxLoopTime && isLooping)
		{
			curr = DateTime.Now;
			elapsed = (curr - refTime).TotalMilliseconds;
			yield return null;

			// if a note is hit then store in a Note within loop
			// no comms protocol set up yet
		}
		Debug.Log("End Loop");
		status.text = "Not Looping";
		myTrigger.isOn = false;
	}
}

// Note node class that stores information about played note in order in the Loop list
public class Note
{
	private int instrument; // 0 for xylophone 1 for drum
	private int note; // 0-3 for drum, 0-10 for xylophone
	private long timing; // elapsed time in milliseconds
	private Note next; // next note in sequence

	// constructor
	public Note(int instNum, int noteNum, long length)
	{
		instrument = instNum;
		note = noteNum;
		length = timing;
		next = null;
	}

	// returns instrument number
	public int getInst()
	{
		return instrument;
	}
	// returns note number
	public int getNote()
	{
		return note;
	}
	// returns delay before note in milliseconds
	public long getDelay()
	{
		return timing;
	}
	// returns next note
	public void setNext(Note nextNote)
	{
		next = nextNote;
	}
}

/*
    // starts or stops playback of loop
    public void PlayLoop()
    {
        playing = !playing;
        if (playing)
        {
            StartCoroutine("WriteData");
        }
        else
        {
            StopCoroutine("WriteData");
        }
    }

    // runs loop until stop command is set
    IEnumerator WriteData()
    {
        if (loop == mull || loop.getHead == null)
        {
            // there is no loop to play
        }
        else
        {
            for (;;)
            { 
                // traverse loop and return stuff and add appropriate delays
            }
        }
    }
    */
// loop circular linked list class that stores notes as nodes in order
public class Loop
{
	private Note head; // first note in loop
	private Note curr; // last note in loop (most recently added)

	// constructor for empty loop
	public Loop()
	{
		head = null;
		curr = null;
	}

	// constructor for loop with 1 note
	public Loop(int x, int y, long z)
	{
		head = new global::Note(x, y, x);
		head.setNext(head);
		curr = head;
	}

	public Note getHead()
	{
		return head;
	}

	// adds a new note to the loop
	public void addNote(int x, int y, long z)
	{
		Note temp = new Note(x, y, z);
		// sets head if loop empty
		if (head == null)
		{
			head = temp;
			head.setNext(head);
			curr = head;
		}
		// otherwise adds to end of loop
		else
		{
			curr.setNext(temp);
			temp.setNext(head);
			curr = temp;
		}
	}
}









