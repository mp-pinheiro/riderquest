using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Event : MonoBehaviour {
	public UnityEvent callback;
	static HashSet<string> usedEvents;
	public bool autoStart;

	// Use this for initialization
	void Start () {
		//create set once
		if(usedEvents==null){
			usedEvents = new HashSet<string>();
		}

		//auto-start event
		if(autoStart) StartEvent();
	}

	void OnCollisionEnter2D(Collision2D other){
		//on hero touch event
		StartEvent();
	}

	void OnTriggerEnter2D(Collider2D other){
		//on hero touch event
		StartEvent();
	}

	void StartEvent(){
		//call method
		string name = callback.GetPersistentMethodName(0);
		if(!usedEvents.Contains(name)){
			usedEvents.Add(name);
			callback.Invoke();
		}
	}

	public void Dream(){
		StartCoroutine(DreamRoutine());
	}
	IEnumerator DreamRoutine(){
		yield return MessageManager.ShowMessage("Voice", Global.playerName + "... " + Global.playerName + "... It's coming... You must... You have to...");
		SceneManager.LoadScene("bedroom");
	}

	public void WakeUp(){
		StartCoroutine(WakeUpRoutine());
	}
	IEnumerator WakeUpRoutine(){
		yield return MessageManager.ShowMessage(Global.motherName, Global.playerName + " wake up! Breakfast is ready!");
		yield return MessageManager.ShowMessage(Global.playerName, "What a strange dream...");
	}

	public void Breakfast(){
		StartCoroutine(BreakfastRoutine());
	}
	IEnumerator BreakfastRoutine(){
		yield return MessageManager.ShowMessage(Global.fatherName, "Look who's finally up! Ready for our little adventure today, pal?");
		yield return MessageManager.ShowMessage(Global.playerName, "We are really going!?");
		yield return MessageManager.ShowMessage(Global.fatherName, "Yes! I told you we would.");
		yield return MessageManager.ShowMessage(Global.motherName, "I still think you're too young to go hunting.");
		yield return MessageManager.ShowMessage(Global.fatherName, "We are going to be just fine! I'll bring him back in one piece, don't worry.");
		yield return MessageManager.ShowMessage(Global.playerName, "Alright, alright. Have fun, you two.");
		SceneManager.LoadScene("overworld");
	}

	public void Hunt(){
		StartCoroutine(HuntRoutine());
	}
	IEnumerator HuntRoutine(){
		yield return MessageManager.ShowMessage(Global.playerName, "Wow! I've never been so far away from the village.");
		yield return MessageManager.ShowMessage(Global.fatherName, "This is the real world, son! Far north is " + Global.village2Name + ", the village I was born in. And to the east is " + Global.kingdomName + ", the capital of the kingdom, where I met your mother.");
		yield return MessageManager.ShowMessage(Global.fatherName, "All around us there's wonders and adventure.");
		yield return MessageManager.ShowMessage(Global.playerName, "I want to travel the world one day, like father did.");
		yield return MessageManager.ShowMessage(Global.fatherName, "I am sure you will. Now let's hunt some food! Let's go west, to the " + Global.forestName + ", there's game to give and lose there.");
	}

	public void FindDeer(){
		StartCoroutine(FindDeerRoutine());
	}
	IEnumerator FindDeerRoutine(){
		yield return MessageManager.ShowMessage(Global.fatherName, "Alright, son, here we go. Hunting is a simple, but meticulous process.");
		yield return MessageManager.ShowMessage(Global.fatherName, "Some people think hunting means lurking in the shadows, staying silent and waiting for a moment to strike.");
		yield return MessageManager.ShowMessage(Global.fatherName, "Those people die of starvation.");
		yield return MessageManager.ShowMessage(Global.fatherName, "If you want to catch something, you have to think like your prey, you have to put yourself on its tires.");
		yield return MessageManager.ShowMessage(Global.fatherName, "So, if you see a deer, charge at it at full speed. ");
	}

	public void FoundDeer(){
		StartCoroutine(FoundDeerRoutine());
	}
	IEnumerator FoundDeerRoutine(){
		yield return MessageManager.ShowMessage(Global.fatherName, "There it is! Quick, catch it!");
	}

	public void HouseAssault(){
		StartCoroutine(HouseAssaultRoutine());
	}
	IEnumerator HouseAssaultRoutine(){
		yield return MessageManager.ShowMessage(Global.fatherName, "Hey!");
		yield return MessageManager.ShowMessage(Global.fatherName, "Son, go to " + Global.ancientName + "'s house.");
		yield return MessageManager.ShowMessage(Global.playerName, "Dad, what's happening? Where is mom?");
		yield return MessageManager.ShowMessage(Global.fatherName, "I said go!");
		yield return MessageManager.ShowMessage(Global.fatherName, "We will talk later.");
		yield return MessageManager.ShowMessage(Global.blackName, "You. Do you have it?");
		yield return MessageManager.ShowMessage(Global.fatherName, "Get out of my home!");
		yield return MessageManager.ShowMessage(Global.fatherName, "Where is my wife?");
		yield return MessageManager.ShowMessage(Global.blackName, "Everything will be okay if you tell us where it is.");
		yield return MessageManager.ShowMessage(Global.fatherName, "I don't know what you're talking about!");
		GetComponentInChildren<Enemy>().StartBattle();
	}

	public void HouseAssault2(){
		StartCoroutine(HouseAssault2Routine());
	}
	IEnumerator HouseAssault2Routine(){
		yield return MessageManager.ShowMessage(Global.blackName, "We don't have to do this. Just tell us where it is.");
		Global.ancientAppears = true;
		Transform ancient = transform.GetChild(1).GetChild(0);
		yield return ancient.GetComponent<Manipulator>().MoveTo(new Vector2(1.05f, -19.44f), 1.0f);
		yield return MessageManager.ShowMessage(Global.ancientName, "Come on, " + Global.playerName + ", we have to go.");
		yield return MessageManager.ShowMessage(Global.playerName, Global.ancientName + ", you have to help my father! They have my mom!");
		yield return MessageManager.ShowMessage(Global.ancientName, "Let's go, I said!");
		yield return MessageManager.ShowMessage(Global.playerName, "No...!");
		Global.anotherBlack = true;
		yield return MessageManager.ShowMessage(Global.blackName, "It's not here.");
		yield return MessageManager.ShowMessage(Global.blackName, "Get rid of them.");
		yield return MessageManager.ShowMessage(Global.playerName, "NO! DAD!");
		yield return MessageManager.ShowMessage(Global.ancientName, "I am sorry, my child, I have to keep you safe.");
		ancient.GetComponent<AudioSource>().Play();
		ScreenHider.HideScreen();
		yield return new WaitForSeconds(1f);
		GetComponentInChildren<AudioSource>().Play();
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("dream");
	}

	public void Dream2(){
		StartCoroutine(Dream2Routine());
	}
	IEnumerator Dream2Routine(){
		yield return MessageManager.ShowMessage("Voice", "They still don't have it... I couldn't give it to them.");
		yield return MessageManager.ShowMessage("Voice", "Son. You have to keep it safe. They must not have it.");
		yield return MessageManager.ShowMessage("Voice", "You must protect it. Find " + Global.friendName + "...");
		SceneManager.LoadScene("bedroom");
	}
}
