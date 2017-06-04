using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	
	public float autoLoadLevel;
	
	void Start () {
		if (autoLoadLevel <= 0) {
			Debug.Log("auto load is disabled");
		}
		
		else {
			Invoke("LoadNextLevel", autoLoadLevel);
		}
	}
	
	public void LoadLevel (string levelName) {
		Debug.Log("Load level: " + levelName);
		SceneManager.LoadScene(levelName);
	}

	public void RestartGame (string levelName) {
		PlayerPrefsManager.SetScore(0);
		SceneManager.LoadScene(levelName);
	}
	
	public void QuitGame () {
		Debug.Log("quit the game yo");
		Application.Quit();
	}
	
	public void LoadNextLevel () {
		SceneManager.LoadScene(1);
	}
	
}
