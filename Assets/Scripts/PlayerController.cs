using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Renderer rend;
	private int colorSwitch; 
	private GameManager gameManaga;
	private LevelManager levelManaga;
	private int scoreValue = 1; 

	public Color [] shapeColors;
	public TouchController touchControlla;

	void Start () {
		colorSwitch = Random.Range(0, shapeColors.Length);
		rend = GetComponent<Renderer>(); 
		rend.material.color = shapeColors[colorSwitch];
		gameManaga = GameObject.Find("Game Manager").GetComponent<GameManager>();
		levelManaga = GameObject.Find("Level Manager").GetComponent<LevelManager>();
	}
	
	void Update () {
		PlayerMovementTouch();
	}

	private void PlayerMovementTouch () {
			if (touchControlla.GetDirection().x > 200){
				transform.Rotate(0, 0, 90);
				colorSwitch++;
				if (colorSwitch > shapeColors.Length-1){
					colorSwitch = 0;  
				}
				rend.material.color = shapeColors[colorSwitch];
			}
			else if (touchControlla.GetDirection().x < -200) {
				transform.Rotate(0, 0, -90);
				colorSwitch--;
				if (colorSwitch < 0) {
					colorSwitch = shapeColors.Length-1;
				}
				rend.material.color = shapeColors[colorSwitch]; 
			}
	}

	// Used for inital testing 
	/*private void PlayerMovementKeyboard () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.Rotate(0, 0, 90);
			colorSwitch++;
			if (colorSwitch > shapeColors.Length-1){
				colorSwitch = 0;  
			}
			rend.material.color = shapeColors[colorSwitch];
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.Rotate(0, 0, -90);
			colorSwitch--;
			if (colorSwitch < 0) {
				colorSwitch = shapeColors.Length-1;
			}
			rend.material.color = shapeColors[colorSwitch]; 
		}

	}*/

	void OnTriggerExit2D (Collider2D other) {// with screen extension see if exit is still gucci
		if (gameManaga.GetColorBarIndex() == colorSwitch) {
			gameManaga.AddScore(scoreValue);
			Destroy(other.gameObject); 
		}
		else {
			levelManaga.LoadLevel("03_End");
		}
	}

}
