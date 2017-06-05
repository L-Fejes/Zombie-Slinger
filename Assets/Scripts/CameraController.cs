using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform projectile;
	private float xRange = 0.5f;
	private float yRange = 0.5f;
	private float smoothFollowX = 10.0f;
	private float smoothFollowY = 10.0f;
	public Vector2 minXandY;
	public Vector2 maxXandY;
	


	// Use this for initialization
	void Start () {
		// sets the transform player to the GameObject that has been tagged player
		projectile = GameObject.FindGameObjectWithTag("Projectile").transform;
	}
	bool CheckX() { 
		// returns if the distance between the camera and player is less that the range specified
		return Mathf.Abs(transform.position.x - projectile.position.x) > xRange; 
		}
	bool CheckY() {
		// returns if the distance between the camera and player is less that the range specified
		return Mathf.Abs(transform.position.y - projectile.position.y) > yRange;
	}

	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	void FixedUpdate()
	{
		TrackPlayer();
	}

	void TrackPlayer() {
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		// this is for if the player has moved out of the predefined ranges
		if (CheckX()) {
			targetX = Mathf.Lerp(transform.position.x, projectile.position.x, smoothFollowX * Time.deltaTime);
		}
		if (CheckY()) {
			targetY = Mathf.Lerp(transform.position.y, projectile.position.y, smoothFollowY * Time.deltaTime);
		}

		// Setting it so that the camera can't co lower that the min value and higher than the max
		targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
		targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

		// setting the new position to the value's just defined, and keeping the z position the same
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
