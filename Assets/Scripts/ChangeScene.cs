using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static int level;

	// Use this for initialization
	void Start () {
		level = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Return)|| Input.GetKeyUp(KeyCode.RightAlt)) {
			PlayerPrefs.SetInt("level", level);
			LoadScene();
		}
	}

	public void LoadScene () {
    	SceneManager.LoadScene("Level0");
 	}

}
