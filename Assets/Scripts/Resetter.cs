using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;			//	The rigidbody of the projectile
	public float resetSpeed = 0.025f;		//	The angular velocity threshold of the projectile, below which our game will reset
	public GameObject target;
	public static int level;
	
	private float resetSpeedSqr;			//	The square value of Reset Speed, for efficient calculation
	public float timer;
	private SpringJoint2D spring;			//	The SpringJoint2D component which is destroyed when the projectile is launched
	
	void Start ()
	{
		//	Calculate the Resset Speed Squared from the Reset Speed
		resetSpeedSqr = resetSpeed * resetSpeed;

		timer = 10.0f;

		//	Get the SpringJoint2D component through our reference to the GameObject's Rigidbody
		spring = projectile.GetComponent <SpringJoint2D>();

		target = GameObject.Find("Targets");

		level = PlayerPrefs.GetInt("level", level);
	}
	
	void Update () {
		//	If we hold down the "R" key...
		if (Input.GetKeyDown (KeyCode.R)) {
			//	... call the Reset() function
			Reset ();
		}

		if (spring == null) {
			timer = timer - Time.deltaTime;
		}

		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr && target != null && timer <= 0 || (timer <+ 0 && target != null)) {
			//	... call the Reset() function
			Reset ();
		}

		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr && target == null && timer <= 0 && level <= 12|| (timer <= 0 && target == null && level <= 12)) {
			//	change to Score screen
			level ++;
			SaveLevel();
			SceneManager.LoadScene("Score");
		}
		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr && target == null && timer <= 0 && level == 13 || (timer <= 0 && target == null && level == 13)) {
			//	change to Score screen
			level ++;
			SaveLevel();
			SceneManager.LoadScene("EndGame");
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		//	If the projectile leaves the Collider2D boundary...
		if (other.GetComponent<Rigidbody2D>() == projectile) {
			//	... call the Reset() function
			Reset ();
		}
	}

	void SaveLevel() {
		PlayerPrefs.SetInt("level", level);
	}
	
	void Reset () {
		//	The reset function will Reset the game by reloading the same level
		SceneManager.LoadScene (Application.loadedLevel);
	}
}
