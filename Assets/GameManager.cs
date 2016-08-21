using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int gamePoint = 4;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("pheonixVictoryCount") == false || PlayerPrefs.HasKey ("boatVictoryCount") == false) {
			PlayerPrefs.SetInt ("pheonixVictoryCount", 0);
			PlayerPrefs.SetInt ("boatVictoryCount", 0);
		}
		print (PlayerPrefs.GetInt ("pheonixVictoryCount") + " : " + PlayerPrefs.GetInt ("boatVictoryCount"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Victory(int player){
		if (player == 1) {
			PlayerPrefs.SetInt ("pheonixVictoryCount", PlayerPrefs.GetInt("pheonixVictoryCount")+1);
			if (PlayerPrefs.GetInt("pheonixVictoryCount") >= gamePoint) {
				SceneManager.LoadScene ("HunterDefeat");
			} else {
				SceneManager.LoadScene ("BattleScene");
			}
		}
		else if (player == 2) {
			PlayerPrefs.SetInt ("boatVictoryCount", PlayerPrefs.GetInt("boatVictoryCount")+1);
			if (PlayerPrefs.GetInt("boatVictoryCount") >= gamePoint) {
				SceneManager.LoadScene ("PhoenixDefeat");
			} else {
				SceneManager.LoadScene ("BattleScene");
			}
		}
	}

	void LoadGame(string scene){
		SceneManager.LoadScene (scene);
	}
}
