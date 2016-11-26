
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public delegate void MetronomeEvent(Metronome metronome);

public class Metronome : MonoBehaviour {
	public int Base;
	public int Step;
	public int BPM;
	public int CurrentStep = 1;
	public int CurrentMeasure;

	private float interval;
	private float nextTime;

	public event MetronomeEvent OnTick;
	public event MetronomeEvent OnNewMeasure;

	public bool active = false;
	public Button myButton;
	public InputField myField;
	// Use this for initialization
	void Start () {
		
		myField = GetComponentInParent<InputField>();
		Button myButton = GetComponent<Button>();
		myButton.onClick.AddListener(StartMetronome);
		//StartMetronome(); 
	}

	void update()
	{
		
		string text = myField.text;
		int.TryParse(text, out BPM); 
		Debug.Log(BPM);

	} 



	public void StartMetronome()
	{
		active = !active;
		if (active) {
			StopCoroutine ("DoTick");
			CurrentStep = 1;
			var multiplier = Base / 4f;
			var tmpInterval = 60f / BPM;
			interval = tmpInterval / multiplier;
			nextTime = Time.time;
			StartCoroutine ("DoTick");
		} else {
			StopCoroutine ("DoTick");
		}

	}

	IEnumerator DoTick()
	{
		AudioSource mySource = GetComponent<AudioSource>();
		for (; ; )
		{
			mySource.Play();

			if (CurrentStep == 1 && OnNewMeasure != null)
				OnNewMeasure(this);
			if (OnTick != null)
				OnTick(this);
			nextTime += interval;
			yield return new WaitForSeconds(nextTime - Time.time);
			CurrentStep++;
			if (CurrentStep > Step)
			{
				CurrentStep = 1;
				CurrentMeasure++;
			}
		}
	}
}