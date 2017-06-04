using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private Vector2 origin; 
	private Vector2 direction;
	private bool touched;
	private int pointerID;

	void Awake () {
		touched = false; 
		direction = Vector2.zero;
	}

	void Update () {
		direction = Vector2.zero;
	}
	
	public void OnPointerDown (PointerEventData data) {
		if (!touched) {
			touched = true;
			origin = data.position;
			pointerID = data.pointerId;
			//Debug.Log("i touched the screen");
		}
	}

	public void OnPointerUp (PointerEventData data) {
		if (pointerID == data.pointerId) {
			Vector2 currentPosition = data.position;
			direction = currentPosition - origin;
			Debug.Log(direction);
			touched = false;
		}
	}

	public Vector2 GetDirection () {
		return direction;
	}

}
