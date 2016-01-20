using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;
	public int targetLevel;

	IEnumerator OnTriggerEnter2D(Collider2D other){

		PlayerPrefs.SetInt("locationLevel",targetLevel);

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadeToBlack ());


		other.gameObject.transform.position = warpTarget.position;
		Camera.main.transform.position = warpTarget.position;

		yield return StartCoroutine (sf.FadeToClear ());

	
	}
}
