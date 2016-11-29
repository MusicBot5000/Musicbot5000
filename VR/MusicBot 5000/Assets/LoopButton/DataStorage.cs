using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Timers;
using UnityEditor;





public class DataStorage : MonoBehaviour
{

	public bool isLooping = false;
	public bool playing = false;

	public bool notePlayed = false;


	public Toggle myTrigger;
	public Toggle writeTrigger;
	public Text status;
	public DateTime refTime;
	public long maxSeconds = 5;
	public const long maxLoopTime = 5000;
	public Loop loop;

	// Use this for initialization
	void Start()
	{
		myTrigger.isOn = false;
		writeTrigger.isOn = false;
		myTrigger.onValueChanged.AddListener (StartLoop);
		writeTrigger.onValueChanged.AddListener (PlayLoop);
		loop = null;

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
			//loop = null; // TODO: Change this as necessary
			loop = null;
			StartCoroutine("ReadData");
		}
	}

	// runs for 20 seconds or until looping is manually ended
	IEnumerator ReadData()
	{
		refTime = DateTime.Now;
		DateTime curr = DateTime.Now;
		DateTime prev = refTime;
		double elapsed = (curr - refTime).TotalMilliseconds;
		int inst;
		int note;

		double delay;
		Debug.Log("Start Loop");
		status.text = "Looping";
		while (elapsed < maxLoopTime && isLooping)
		{
			curr = DateTime.Now;
			elapsed = (curr - refTime).TotalMilliseconds;

			if (notePlayed) {

				delay = (curr - prev).TotalMilliseconds;
				inst = 0; // TODO: Get Global instrument variable from the Prefab upon collision
				note = 0; // TODO: Update this to be w.r.t the certain key that was hit

				if (loop == null) {
					loop = new Loop (inst, note, delay);
				} 
				else {
					loop.addNote (inst, note, delay);
				}
				notePlayed = false;
				prev = curr;
			}

			yield return null;

		}
		Debug.Log("End Loop");
		status.text = "Not Looping";
		myTrigger.isOn = false;
	}

	// starts or stops playback of loop
	public void PlayLoop(bool something)
	{
		playing = !playing;
		if (playing) {
			StartCoroutine ("WriteData");
		} else {
			StopCoroutine ("WriteData");
		}

	}

	// runs loop until stop command is set
	IEnumerator WriteData()
	{
		int instrument;
		int note;
		double delay;
		if (loop == null || loop.getHead() == null)
		{
			// there is no loop to play
			status.text = "No Loops Available!";

			yield return new WaitForSeconds(1);
			writeTrigger.isOn = false;


		}
		else
		{
			status.text = "Playback Loop";
			Note temp = loop.getHead ();
			for (;;)
			{ 
				// traverse loop and return stuff and add appropriate delays
				instrument = temp.getInst();
				note = temp.getNote();
				delay = temp.getDelay();
				EditorApplication.Beep ();
				yield return new WaitForSeconds((float) delay/1000.0f);
				//TODO: Send this to the arduino 
				EditorApplication.Beep();

				temp = temp.getNext();

			}
		}
	}

}

// Note node class that stores information about played note in order in the Loop list
public class Note
{
	private int instrument; // 0 for xylophone 1 for drum
	private int note; // 0-3 for drum, 0-10 for xylophone
	private double timing; // elapsed time in milliseconds
	private Note next; // next note in sequence

	// constructor
	public Note(int instNum, int noteNum, double length)
	{
		this.instrument = instNum;
		this.note = noteNum;
		this.timing = length;
		this.next = null;
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
	public double getDelay()
	{
		return timing;
	}
	// returns next note
	public void setNext(Note nextNote)
	{
		next = nextNote;
	}
	public Note getNext(){
		return next;
	}
}




// loop circular linked list class that stores notes as nodes in order
public class Loop
{
	private Note head; // first note in loop
	private Note curr; // last note in loop (most recently added)

	// constructor for loop with 1 note
	public Loop(int x, int y, double z)
	{
		this.head = new global::Note(x, y, z);
		this.head.setNext(head);
		this.curr = head;
	}

	public Note getHead()
	{
		return head;
	}

	// adds a new note to the loop
	public void addNote(int x, int y, double z)
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



