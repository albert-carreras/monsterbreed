using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Vector2 movement_vector = new Vector2 (0,0);
	public Rigidbody2D rb;
	Animator anim;
	Vector2 returnVector;
	public static Vector2 old_pos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		if (PlayerPrefs.GetInt ("returning") == 1) {
			returnVector.x = PlayerPrefs.GetFloat ("xPos");
			returnVector.y = PlayerPrefs.GetFloat ("yPos");
			transform.position=returnVector;

			Debug.Log (returnVector);
			PlayerPrefs.SetInt ("returning", 0);
			
		}
		old_pos = transform.position;

	}
	bool mvHoz=false;
	bool mvVer=false;
	// Update is called once per frame
	void Update () {
			ActionMenu aMenuLoad = GameObject.FindGameObjectWithTag ("ActionMenu").GetComponent<ActionMenu> ();

			float xPos = 0, yPos = 0;
			if (Input.GetAxisRaw ("Vertical") != 0 && Input.GetAxisRaw ("Horizontal") != 0) {
				if (mvHoz) {
					yPos = Input.GetAxisRaw ("Vertical");


				} else if (mvVer) {
					xPos = Input.GetAxisRaw ("Horizontal");

				}
			} else {
				mvHoz = Input.GetAxisRaw ("Horizontal") != 0;
				xPos = Input.GetAxisRaw ("Horizontal");
				mvVer = Input.GetAxisRaw ("Vertical") != 0;
				yPos = Input.GetAxisRaw ("Vertical");
			}

			movement_vector.x = xPos;
			movement_vector.y = yPos;

			if (movement_vector != Vector2.zero) {

				if (aMenuLoad.isShowing == true) { 
					movement_vector = Vector2.zero;
					anim.SetBool ("isWalking", false);

				} else {
		
					anim.SetFloat ("Input_x", movement_vector.x);
					anim.SetFloat ("Input_y", movement_vector.y);
				}

			} else {
				anim.SetBool ("isWalking", false);
			}
		 
			rb.MovePosition (rb.position + (movement_vector * 7f) * Time.deltaTime);
		old_pos = transform.position;

	}

}
