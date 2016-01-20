using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void Awake(){
	
		DontDestroyOnLoad (transform.gameObject);
	
	}
	public static string monster1Name{ get; set;}
	public static BaseMonster monster1Type { get; set;}
	public static int monster1Level{ get; set;}
	public static float monster1ModLevel{ get; set;}
	public static int monster1HP{ get; set;}
	public static int monster1MP{ get; set;}
	public static int monster1Stren{ get; set;}
	public static int monster1Intel{ get; set;}
	public static int monster1Wisdom{ get; set;}
	public static int monster1Defen{ get; set;}

	public static string monster2Name{ get; set;}
	public static BaseMonster monster2Type { get; set;}
	public static int monster2Level{ get; set;}
	public static float monster2ModLevel{ get; set;}
	public static int monster2HP{ get; set;}
	public static int monster2MP{ get; set;}
	public static int monster2Stren{ get; set;}
	public static int monster2Intel{ get; set;}
	public static int monster2Wisdom{ get; set;}
	public static int monster2Defen{ get; set;}

	public static string monster3Name{ get; set;}	
	public static BaseMonster monster3Type { get; set;}
	public static int monster3Level{ get; set;}
	public static float monster3ModLevel{ get; set;}
	public static int monster3HP{ get; set;}
	public static int monster3MP{ get; set;}
	public static int monster3Stren{ get; set;}
	public static int monster3Intel{ get; set;}
	public static int monster3Wisdom{ get; set;}
	public static int monster3Defen{ get; set;}


}
