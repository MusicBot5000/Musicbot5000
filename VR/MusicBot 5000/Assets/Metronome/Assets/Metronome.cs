
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;




public class Metronome : MonoBehaviour
{
<<<<<<< HEAD
    public GameController GameCon;

	//public Button myButton;
	//public Slider mySlider;
	public AudioSource src; 
    


	public double bpm = 0.0f;

	double nextTick = 0.0F; // The next tick in dspTime
	double sampleRate = 0.0F; 
	bool ticked = false;
    double dspTime;

	void Start() {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        GameCon.MetronomeActive = false;

		double startTick = AudioSettings.dspTime;
		sampleRate = AudioSettings.outputSampleRate;
		//bpm = mySlider.value;
		nextTick = startTick + (60.0 / bpm);
		Debug.Log (nextTick);
		//myButton.onClick.AddListener (toggle);

	}

	void LateUpdate() {
		if ( !ticked && nextTick >= AudioSettings.dspTime && GameCon.MetronomeActive ) {
=======
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
>>>>>>> refs/remotes/origin/master
			ticked = true;
			BroadcastMessage( "OnTick" );
		}
	}
<<<<<<< HEAD
=======

	// Just an example OnTick here
	void toggle() {
		
		active = !active;
	}
	void OnTick() {
		
		src.Play ();
		//EditorApplication.Beep();

	
>>>>>>> refs/remotes/origin/master

	// Just an example OnTick here
	void OnTick() {
		src.Play ();
		//EditorApplication.Beep();
	}

<<<<<<< HEAD
    public void Toggle()
    {
        GameCon.MetronomeActive = !GameCon.MetronomeActive;
        nextTick = dspTime;
    }

	void FixedUpdate() {
		//bpm = mySlider.value;
		double timePerTick = 60.0f / bpm;
		dspTime = AudioSettings.dspTime;
		
		while ( dspTime >= nextTick && GameCon.MetronomeActive) {
=======
	void FixedUpdate() {
		bpm = mySlider.value;
		double timePerTick = 60.0f / bpm;
		double dspTime = AudioSettings.dspTime;
		//Debug.Log (nextTick);
		while ( dspTime >= nextTick && active) {
>>>>>>> refs/remotes/origin/master
			ticked = false;
			nextTick += timePerTick;
		}

	}
}