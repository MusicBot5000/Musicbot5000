using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Timers;

public class DataStorage : MonoBehaviour
{

	public bool isLooping = false;

	public int refTime; // Use Integer time here

	public const long MAXLOOPTIME = 5 * 1000; // Changed this to const on Nov 23 2016 - Isaac TODO: Change back to 20 sec.
	public Loop loop;

	public Timer loopTimer;

	// Use this for initialization
	void Start()
	{
		
		
		Toggle myToggle = GetComponent<Toggle>();
		Label timeLabel = GetComponent<Label> ();
		myToggle.onValueChanged.AddListener (StartLoop);
		loopTimer = new Timer (); // created a timer - Isaac
		loopTimer.Interval = MAXLOOPTIME;
	}


	// Update is called once per frame
	void Update()
	{
		
	}

	private void timer_Tick(object sender, EventArgs e)
	{
		if (refTime > 0)
		{
			refTime = refTime - 1;
			timeLabel.Text = refTime + "seconds";
		}

		else
		{
			
			loopTimer.Stop();
			timeLabel.Text = "Not Looping";

			sum.Value = addend1 + addend2;
			startButton.Enabled = true;
		}


	// starts or stops looping storage
	public void StartLoop(bool something) 
	{
		isLooping = !isLooping;
		if (isLooping)
		{
			loopTimer.Enabled = true;
			loopTimer.Tick += new System.EventHandler (ReadData);
		}
		else
		{
			loopTimer.Enabled = false;
		}
	}

	// runs for 20 seconds or until looping is manually ended
	private void ReadData(object sender, EventArgs e)
	{
		loop = new Loop();
		refTime = DateTime.Now;
		DateTime curr = DateTime.Now;
		double elapsed = (curr - refTime).TotalMilliseconds;
		int inst;
		int note;
		Debug.Log ("Hello World"); 
		/*
		while (elapsed < MAXLOOPTIME)
		{
			Debug.Log ("Looping");
			curr = DateTime.Now;
			elapsed = (curr - refTime).TotalMilliseconds;
			// if a note is hit then store in a Note within loop
			// no comms protocol set up yet
		} */


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
