using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionMenu : MonoBehaviour {

	public GameObject menu; // Assign in inspector
	public GameObject text; 
	public bool isShowing=false;
	public static string NPCmessage;


	void Update() {
		 Text textMessage = text.GetComponent<Text>();

		menu.SetActive(isShowing);

		if (Input.GetKeyDown("space")&&NPCHit.npcHit) {
			isShowing = !isShowing;
			menu.SetActive(isShowing);
			textMessage.text=NPCmessage;
			text.SetActive(isShowing);
		}
	}
}