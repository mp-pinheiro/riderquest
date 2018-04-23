using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	
	// Update is called once per frame
	void Update () {
		if(player==null) return;
		Vector3 pos = player.position;
		transform.position = new Vector3(
			pos.x,
			pos.y,
			transform.position.z
		);
	}
}
