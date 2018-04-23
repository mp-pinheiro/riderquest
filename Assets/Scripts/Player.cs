using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Car {
	static GameObject instance;
	static Vector3 previousPosition;
	static bool usePreviousPosition;

	protected override void Awake(){
		base.Awake();
		instance = gameObject;

		//load previous position
		if(usePreviousPosition){
			transform.position = previousPosition;
			usePreviousPosition = false;
		}
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(Input.GetKey(KeyCode.LeftArrow)){
			TurnLeft();
		}else if(Input.GetKey(KeyCode.RightArrow)){
			TurnRight();
		}else{
			StopTurning();
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			Accelerate();
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			Reverse();
		}

		//reset
		if(Input.GetKeyDown(KeyCode.R)){
			rb.velocity = Vector2.zero;
			rb.position = Vector2.zero;
		}
	}

	public static GameObject GetInstance(){
		return instance;
	}

	public static void SetPreviousPosition(Vector3 pos){
		previousPosition = pos;
		usePreviousPosition = true;
	}
}
