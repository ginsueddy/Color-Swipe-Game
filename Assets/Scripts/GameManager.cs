using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject [] colorBars;
	public float waitTime; 

	public Text scoreText;
	public Text highScoreText;

	private int colorBarIndex;		
	private int score = 0; 
	private int highScore;
	//private int numOfSides; // obtain from player prefs

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnColorBars());
		highScore = PlayerPrefsManager.GetHighScore();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScore();
		CheckHighScore();
		DisplayHighScore();
	}

	private IEnumerator SpawnColorBars () {
			colorBarIndex = Random.Range(0, colorBars.Length);
			Instantiate(colorBars[colorBarIndex], new Vector3 (0, 10, 0), Quaternion.identity);
			yield return new WaitForSeconds(waitTime);
			while (true) {
				colorBarIndex = RandNumGenerator(colorBarIndex);
				Instantiate(colorBars[colorBarIndex], new Vector3 (0, 10, 0), Quaternion.identity);
				yield return new WaitForSeconds(waitTime);
			}
	}

	public int GetScore () {
		return score;
	}

	private void CheckHighScore () {
		if (score > highScore) {
			PlayerPrefsManager.SetHighScore(score);
		}
	}

	private void DisplayHighScore() {
		highScoreText.text = ("HighScore: " + highScore);
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue; 
		PlayerPrefsManager.SetScore(score);
	}

	private void UpdateScore () {
		scoreText.text = ("Score: " + score);
	}

	public int GetColorBarIndex() {
		return colorBarIndex;
	} 

	private int RandNumGenerator (int previousNum) {
		int newColorBarIndex = Random.Range(0, colorBars.Length); 

		if (newColorBarIndex == previousNum){
			do {
				newColorBarIndex = Random.Range(0, colorBars.Length);
			} while (newColorBarIndex == previousNum);
		}
		return newColorBarIndex;
	}

}
