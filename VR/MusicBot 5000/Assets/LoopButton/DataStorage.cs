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
		String id;

		double delay;
		Debug.Log("Start Loop");
		status.text = "Looping";

		while (elapsed < maxLoopTime && isLooping)
		{
			curr = DateTime.Now;
			elapsed = (curr - refTime).TotalMilliseconds;

			if (notePlayed) {
				id = "";
				delay = (curr - prev).TotalMilliseconds;

				if (loop == null) {
					loop = new Loop(id, delay);
					Debug.Log (loop.getHead ().getId());
				} 
				else {
					loop.addNote (id, delay);
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
		String id;
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
				id = temp.getId();
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
	private char instrument; // 0 for xylophone 1 for drum
	private int note; // 0-3 for drum, 0-10 for xylophone
	private double timing; // elapsed time in milliseconds
	private Note next; // next note in sequence

	// constructor
	public Note(String id, double length)
	{
		this.instrument = id[0];
		int.TryParse (id.Substring (1, 2), out this.note);
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
	// returns id
	public string getId(){
		string str = "";
		str += instrument;

		if (note >= 10) {
			str += note.ToString ();
		} else {
			str += "0";
			str += note.ToString ();
		}
		return str;
	}
}




// loop circular linked list class that stores notes as nodes in order
public class Loop
{
	private Note head; // first note in loop
	private Note curr; // last note in loop (most recently added)

	// constructor for loop with 1 note
	public Loop(String x, double y)
	{
		this.head = new global::Note(x, y);
		this.head.setNext(head);
		this.curr = head;
	}

	public Note getHead()
	{
		return head;
	}
	public Note getCurr()
	{
		return curr;
	}



	// adds a new note to the loop
	public void addNote(String x, double y)
	{
		Note temp = new Note(x,y);
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
