using UnityEngine;

public class SoundManager : MonoBehaviour {
	//LINK FOR SOUND TUTORIAL
	//https://unity3d.com/learn/tutorials/topics/audio/sound-effects-scripting

	//For all the sound clips on the objects place Sound Variables Here
	public AudioClip startSound;
	public AudioClip colllideSound;
	// public GameObject sourceObject;

	//The AudioSource variable
	private AudioSource audio;
	//To control the min and max volume limits
	private float volMin = .03f;
	private float volMax = 1.0f;

	//to change the pitch of the sounds and alter due on velocity
	private float lowPitchRng = .50f;
	private float highPitchRng = 1.25f;
	//private float velocityToVol = .2f;
	//private float velocityClipSplit = 10f;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Example of audio usage
		if(Input.GetButtonDown("Fire1")){
			float vol = Random.Range(volMin, volMax);
			audio.PlayOneShot(startSound, vol);
		}
	}

	/// Sent when another object enters a trigger collider attached to this object (2D physics only).
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy") {
			float vol = Random.Range(volMin, volMax);
			audio.pitch = Random.Range(lowPitchRng, highPitchRng);
			audio.PlayOneShot(colllideSound, vol);
		}
	}

	/// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "Enemy") {
			float vol = Random.Range(volMin, volMax);
			audio.pitch = Random.Range(lowPitchRng, highPitchRng);
			audio.PlayOneShot(colllideSound, vol);
		}
	}
}
