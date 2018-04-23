using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static string playerName = "Player";
	public static string fatherName = "Father";
	public static string greenName = "Green";
	public static string strangerName = "Stranger";
	public static string friendName = "Friend";
	public static string motherName = "Mom";
	public static string ancientName = "Ancient";
	public static string blackName = "Black Car";
	public static string village2Name = "Village2";
	public static string kingdomName = "Kingdom";
	public static string forestName = "Forest";
	public static string empty = "";
	public static bool killedDeer = true;
	public static bool fatherDied = false;
	public static bool ancientAppears;
	public static bool anotherBlack;

	public static object GetValue(string key){
		var field = typeof(Global).GetField(key);
		return field.GetValue(null);
	}
}
