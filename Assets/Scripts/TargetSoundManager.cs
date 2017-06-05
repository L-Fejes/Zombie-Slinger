using UnityEngine;

public class TargetSoundManager : MonoBehaviour {

	//For all the sound clips on the objects place Sound Variables Here
	public AudioClip triggerSound;
	// public GameObject sourceObject;

	//The AudioSource variable
	private AudioSource audio;
	//To control the min and max volume limits
	private float volMin = .03f;
	private float volMax = 1.0f;

	//to change the pitch of the sounds and alter due on velocity
	private float lowPitchRng = .50f;
	private float highPitchRng = 1.25f;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// Sent when another object enters a trigger collider attached to this object (2D physics only).
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Projectile") {
			float vol = Random.Range(volMin, volMax);
			audio.pitch = Random.Range(lowPitchRng, highPitchRng);
			audio.PlayOneShot(triggerSound, vol);
		}
	}
}
