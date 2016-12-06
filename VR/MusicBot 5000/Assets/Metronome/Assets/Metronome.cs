
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;




public class Metronome : MonoBehaviour
{
	public Button myButton;
	public Slider mySlider;
	public AudioSource src; 



	public double bpm = 0.0f;

	double nextTick = 0.0F; // The next tick in dspTime
	double sampleRate = 0.0F; 
	bool ticked = false;
	bool active = false;

	void Start() {
		double startTick = AudioSettings.dspTime;
		sampleRate = AudioSettings.outputSampleRate;
		bpm = mySlider.value;
		nextTick = startTick + (60.0 / bpm);
		Debug.Log (nextTick);
		myButton.onClick.AddListener (toggle);

	}

	void LateUpdate() {
		if ( !ticked && nextTick >= AudioSettings.dspTime && active ) {
			ticked = true;
			BroadcastMessage( "OnTick" );
		}
	}

	// Just an example OnTick here
	void toggle() {
		
		active = !active;
	}
	void OnTick() {
		
		src.Play ();
		//EditorApplication.Beep();

	

	}

	void FixedUpdate() {
		bpm = mySlider.value;
		double timePerTick = 60.0f / bpm;
		double dspTime = AudioSettings.dspTime;
		//Debug.Log (nextTick);
		while ( dspTime >= nextTick && active) {
			ticked = false;
			nextTick += timePerTick;
		}

	}
}