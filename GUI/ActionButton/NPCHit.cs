using UnityEngine;
using System.Collections;


public class NPCHit : MonoBehaviour {
	public static bool npcHit=false;
	void Start () {
		
	}
	void OnCollisionEnter2D(){

		string message = GetComponent<NPCMessages>().message;
		npcHit = true;
		ActionMenu.NPCmessage = message;
		
	}
	void OnCollisionExit2D(){
		
		npcHit = false;
		ActionMenu.NPCmessage = null;
		
	}
}
