using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	//int menuNumber = 0;
	bool showMonstersGui = false; 
	bool showSaveGui = false;
	bool openGUI = false;
    bool showStats = false;
    bool showSkills = false;
    public GUISkin skin;
	void Start(){
	}

	void Update(){

        if (Input.GetKeyDown("e"))openGUI =! openGUI;
		}
	void OnGUI(){
		GUI.skin = skin;

		if(openGUI){
		GUI.Box (new Rect(506, 0, 134, 480), "");

            if (!showMonstersGui)
            {
                if (GUI.Button(new Rect(525, 70, 100, 24), "Monsters"))
                {
                    showMonstersGui = true;
                    
                }
            }
            if (showMonstersGui)
            {
                if (GUI.Button(new Rect(525, 70, 100, 24), "Close Page"))
                    showMonstersGui = false;
            }

            if (GUI.Button (new Rect (525, 100,100,24), "Save"))
			showSaveGui = true;

            if ( GUI.Button (new Rect (514, 30,120,24), "Close Menu")) 
		{
				openGUI = false; 
		}
		if (showMonstersGui) {
				GUI.Box (new Rect (10, 10,480,460), "");

                int j = 0;

                foreach (BaseStatMonster m in Team.team)
                {
                    GUI.Label(new Rect(70+j, 70, 100, 20), m.MonsterName);
                    GUI.Label(new Rect(70 + j, 95, 100, 20), "HP: " + m.HP.ToString());
                    GUI.Label(new Rect(70 + j, 120, 100, 20), "MP: " + m.MP.ToString());

                    string resource1 = m.ML + "/" + m.MonsterType + m.Sprite;
                    Texture2D textMonster1 = Resources.Load(resource1, typeof(Texture2D)) as Texture2D;
                    GUI.DrawTexture(new Rect(50+j, 160, 110, 110), textMonster1);

                    if (GUI.Button(new Rect(50 + j, 350, 110, 26), "Stats")) {

                        showStats = true;
                        Debug.Log("show");
                        if (showStats) {

                            GUI.Box(new Rect(50+j, 350, 110, 100), "");
                            GUI.Label(new Rect(50 + j, 370, 100, 20), "Level: "+m.Level.ToString());
                            GUI.Label(new Rect(50 + j, 395, 100, 20), m.MonsterDescription);
                            Debug.Log("show!");
                            //if (GUI.Button(new Rect(50 + j, 440, 110, 26), "Close")) showStats = false;
                        }


                    }
                    if (GUI.Button(new Rect(50 + j, 380, 110, 26), "Skills"))
                    {
                        showSkills = true;

                        if (showSkills){

                        }

                    }

                    j = j + 150;

                }
                
		} 
			if (showSaveGui){

				GUI.Box(new Rect(514, 130, 120,104),"Save?");
				if(GUI.Button (new Rect (525, 170,100,24), "Yes")){

                    showSaveGui = false;

                    SaveLoad.Save();
					

				}
				if(GUI.Button (new Rect (525, 200,100,24), "No")){

                    showSaveGui = false;


                }
            }
           
        }
	}


}