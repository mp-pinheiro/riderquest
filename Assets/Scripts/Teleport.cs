using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {
	public string scene;
	public Vector2 position;
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			Player.SetPreviousPosition(position);
			SceneManager.LoadScene(scene);
		}
	}
}
