using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	Camera myCam;
	// Use this for initialization
	void Start () {

		myCam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		myCam.orthographicSize = (Screen.height / 100f) / 0.35f;

		if (target) {
		
			transform.position = Vector3.Lerp(transform.position, target.position, 1f) + new Vector3(0,0,-10);
		
		}
	}
}
