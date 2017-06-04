using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text finalScoreText;
	public Text highScoreText;

	// Use this for initialization
	void Start () {
		finalScoreText.text = ("Score: " + PlayerPrefsManager.GetScore());
		highScoreText.text = ("High Score: " + PlayerPrefsManager.GetHighScore());
	}

}
