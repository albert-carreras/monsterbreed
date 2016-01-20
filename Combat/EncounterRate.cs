using UnityEngine;
using System.Collections;

public class EncounterRate : MonoBehaviour {

	float rate=0f;
	float encounter=0f;
	void OnTriggerEnter2D(){

		if (EncounterZone.isInside == false) {
			EncounterZone.isInside = true;
		} else{
			EncounterZone.isInside = false;
		}
	}

	void Update(){
		PlayerMovement temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

		if (EncounterZone.isInside == true && (PlayerMovement.old_pos!=temp.rb.position)) {

			if (rate<0.05f){
				rate = rate+0.000008f;}
			encounter=Random.Range (0.1f,0.3f);
			PlayerPrefs.SetFloat("xPos", temp.rb.position.x);
			PlayerPrefs.SetFloat("yPos", temp.rb.position.y);
			if (encounter > 0.3f-rate){

				Application.LoadLevel("battle");
			}
		}

	}
	
}
