using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string SCORE_KEY = "score";
	const string HIGH_SCORE_KEY = "high_score";

	public static void SetScore (int score) {
		PlayerPrefs.SetInt(SCORE_KEY, score);
	}

	public static int GetScore () {
		return PlayerPrefs.GetInt(SCORE_KEY);
	}

	public static void SetHighScore (int currentScore) {
		PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentScore);
	}

	public static int GetHighScore () {
		return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
	}

}
