using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {
	public Button yourButton;
	public static int level;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(LoadScene);

		level = PlayerPrefs.GetInt("level", level);
	}

	void Update() {
		/*if(text.tag == "Player") {
			text.text = "" + score;
		}
		else if(text.tag == "Finish") {
			text.text = "" + highscore;
		}*/

		if(Input.GetKeyUp(KeyCode.Return)) {
			AddInt();
		}
		if(level == 14) {
			AddInt();
		}
	}

	//Test for changing level in score screen
	public static void AddInt ()
    {
        level ++;
		PlayerPrefs.SetInt("level", level);
    }

	void LoadScene () {
		if(level == 1) {
			SceneManager.LoadScene("Level0");
		} else if (level == 2) {
			//SceneManager.UnloadScene("Level1");
			SceneManager.LoadScene("Level1");
		}else if (level == 3) {
			SceneManager.LoadScene("Level2");
		}else if (level == 4) {
			SceneManager.LoadScene("Level3");
		}else if (level == 5) {
			SceneManager.LoadScene("Level4");
		}else if (level == 6) {
			SceneManager.LoadScene("Level5");
		}else if (level == 7) {
			SceneManager.LoadScene("Level6");
		}else if (level == 8) {
			SceneManager.LoadScene("Level7");
		}else if (level == 9) {
			SceneManager.LoadScene("Level10");
		}else if (level == 10) {
			SceneManager.LoadScene("Level20");
		}else if (level == 11) {
			SceneManager.LoadScene("Level21");
		}else if (level ==12) {
			SceneManager.LoadScene("Level22");
		}else if (level == 13) {
			SceneManager.LoadScene("Level23");
		}else if (level == 14) {
			SceneManager.LoadScene("EndGame");
		} else {
    		SceneManager.LoadScene("Title");
		}

		// switch(level) {
		// 	case 1:
		// 	SceneManager.LoadScene("Level0");
		// 	case 2:
		// }
 	}

}
