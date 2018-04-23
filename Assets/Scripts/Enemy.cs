using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject playerParty;
	public GameObject enemyParty;
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag=="Player"){
			StartBattle();
		}
	}

	public void StartBattle(){
		BattleManager.StartBattle(playerParty, enemyParty);
	}
}
