using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    //Script that handles on its own the battle Scene.

	int monsterNum;                  //Number of monsters that appear
	int i;                          //iterator for dealing with monsterNum
	public GUISkin skin;

    bool fightPressed = false;      //Checks if Fight,... Buttons are pressed
    bool scoutPressed = false;
	bool skillPressed = false;
    bool runPressed = false;

    bool showPlayerText1 = true;    //Checks if its time to show text (add a 1 at the end!)

    bool monster1Dead = false;      //Checks whether monster is dead.
    bool monster2Dead = false;
    bool monster3Dead = false;

    bool isRunning = false;         //Checks if TextSlow is running
    bool added;     //add to team or sent to monsterList
	bool beginning=true; //beginning of battle
	int monsterHit;
	string[] message = new string[4];
	int messageNum=0;
	int damage;
    public enum BattleStates{       //enumerate BattleStates

		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN,
		CAPTURE,
		END
	}
    BaseStatMonster monster1;
    BaseStatMonster monster2;
    BaseStatMonster monster3;

    private BattleStates currentState; 

	void Start () {
		currentState = BattleStates.START;      //Initial BattleState

        
		monsterNum=Random.Range(1, 4);          //Define number of Monsters and initialize iterator
		i=0;


	}
	
	void Update () {

        //Main Battle Actions (non-GUI)

        switch (currentState){
		case (BattleStates.START):
            
            //Create Monsters depending on how many we found
			while(i<=monsterNum){
				switch(i){
				case 1:
                     monster1 = new CreateNewMonster().createMonster();
					break;
				case 2:
                     monster2 = new CreateNewMonster().createMonster();
					break;
				case 3:
                     monster3 = new CreateNewMonster().createMonster();
					break;
				

				}
				i++;
			}
			/*beginning=true;
			showPlayerText1=false;

			if (beginning)
			{
				if (!showPlayerText1)
				{
					if (i>=1){

						GUI.Label(new Rect(20, 375, 100, 20), monster1.MonsterName+" appeared!");

					}else if (i>=2){

						GUI.Label(new Rect(20, 395, 100, 20), monster2.MonsterName+" appeared!");

					}else if (i==3){
						GUI.Label(new Rect(20, 415, 100, 20), monster3.MonsterName+" appeared!");

					}
					if(!isRunning) StartCoroutine(slowText());

				}
			}*/
            //after creating go to playerchoice state
		    currentState=BattleStates.PLAYERCHOICE;
			break;

		case (BattleStates.PLAYERCHOICE):
                //DONE IN ONGUI()

                break;

		case (BattleStates.ENEMYCHOICE):
                //DONE IN ONGUI()

                break;

		case (BattleStates.LOSE):
                //DONE IN ONGUI()

                break;

		case (BattleStates.WIN):


			break;
			
		case (BattleStates.CAPTURE):
			//Capture Logic


                //Add monster to LIST
                if (Team.team.Count > 2)
                {
                    MonsterList.monstersList.Add(monster1);
                    added = false;
                }
                else
                {
                    Team.team.Add(monster1);
                    added = true;
                }
                
                //finish battle
                currentState = BattleStates.END;
			break;
		
		case (BattleStates.END):
                //finish battle

                //recover position
                //load Scene
            PlayerPrefs.SetInt("returning", 1);
			Application.LoadLevel("Main");
		break;
	}

	}

    //Use it to Slow down text (no need to click)
	public IEnumerator slowText()
	{
        isRunning = true;
        yield return new WaitForSeconds(1.7f);

        showPlayerText1 = true;
        fightPressed = false;
		skillPressed = false;
        scoutPressed = false;
        runPressed = false;
        isRunning = false;
		beginning = false;
        
    }

    void OnGUI() {
		Debug.Log (currentState);
        //Define nextPage arrow
        Texture2D arrow = Resources.Load("arrow", typeof(Texture2D)) as Texture2D;

        //Define Skin for GUI
        GUI.skin = skin;

        //Define size for LABELS AND BUTTONS
        GUIStyle customButton = new GUIStyle("button");
        GUIStyle customName = new GUIStyle("label");
        customButton.fontSize = 25;
        customName.fontSize = 27;

        //TEAM MONSTER 1

        //MONSTER1 NAME, HP AND MP
		GUI.Label(new Rect(40, 20, 100, 20), Team.team[0].MonsterName, customName);
		GUI.Label(new Rect(60, 54, 100, 20), "HP: " + Team.team[0].HP.ToString(), customName);
		GUI.Label(new Rect(60, 84, 100, 20), "MP: " + Team.team[0].MP.ToString(), customName);
      
        //TEAM MONSTER 2

        //MONSTER 2 NAME, HP AND MP
		if (Team.team.Count >1 )
        {
			GUI.Label(new Rect(245, 16, 100, 20), Team.team[1].MonsterName, customName);
			GUI.Label(new Rect(260, 54, 100, 20), "HP: " + Team.team[1].HP.ToString(), customName);
			GUI.Label(new Rect(260, 84, 100, 20), "MP: " + Team.team[1].MP.ToString(), customName);
        }
        //TEAM MONSTER 3

        //MONSTER 3 NAME, HP AND MP
		if (Team.team.Count >2)
        {
			GUI.Label(new Rect(440, 20, 100, 20), Team.team[2].MonsterName, customName);
			GUI.Label(new Rect(460, 54, 100, 20), "HP: " + Team.team[2].HP.ToString(), customName);
			GUI.Label(new Rect(460, 84, 100, 20), "MP: " + Team.team[2].MP.ToString(), customName);
        }
		//ENEMY MONSTER 1

		//MONSTER1 TEXTURE (ONLY WHEN ALIVE!!)
		if (!monster1Dead)
		{
			string resource1 = monster1.ML + "/" + monster1.MonsterType + monster1.Sprite;
			Texture2D textMonster1 = Resources.Load(resource1, typeof(Texture2D)) as Texture2D;
			GUI.DrawTexture(new Rect(240, 160, 120, 120), textMonster1);
		}
		
		//ENEMY MONSTER 2
		
		//MONSTER 2 NAME, HP AND MP
		if (monster2 != null)
		{

			if (!monster2Dead)
			{
				//MONSTER2 TEXTURE (ONLY WHEN ALIVE!!)
				string resource2 = monster2.ML + "/" + monster2.MonsterType + monster2.Sprite;
				Texture2D textMonster2 = Resources.Load(resource2, typeof(Texture2D)) as Texture2D;
				GUI.DrawTexture(new Rect(30, 160, 120, 120), textMonster2);
			}
		}
		//ENEMY MONSTER 3
		
		//MONSTER 3 NAME, HP AND MP
		if (monster3 != null)
		{
			if (!monster3Dead)
			{
				//MONSTER3 TEXTURE (ONLY WHEN ALIVE!!)
				string resource3 = monster3.ML + "/" + monster3.MonsterType + monster3.Sprite;
				Texture2D textMonster3 = Resources.Load(resource3, typeof(Texture2D)) as Texture2D;
				GUI.DrawTexture(new Rect(460, 160, 120, 120), textMonster3);
			}
		}
        //BOTTOM BUTTONS
        if (!fightPressed && !scoutPressed && !skillPressed && !runPressed) { //check for any button press

			if (GUI.Button (new Rect (20, 370, 300, 45), "FIGHT", customButton)) {


				messageNum=0;

				foreach (BaseStatMonster m in Team.team) {

					messageNum++;

					if(Random.Range(1,65)==2){

						message[messageNum]=m.MonsterName+" Missed his target!!";

					}else{

						if (monsterNum>1){
							if(monsterNum>2){
								if (monster3.HP<monster2.HP){
									if(monster1.HP<monster3.HP){monsterHit=1;}else{monsterHit=3;}
								}else{
									if(monster1.HP<monster2.HP){monsterHit=1;}else{monsterHit=2;}							
								}
							}else{
								if (monster1.HP <= 0){									
									if(monster3==null)monsterHit=2;
									else if(monster2==null)monsterHit=3;
									if(monster2.HP<monster3.HP){
										monsterHit=2;
									}else{
										monsterHit=3;
									}
								}
								else if (monster2.HP <= 0){
									if(monster3==null)monsterHit=1;
									else if(monster1.HP<monster3.HP){
										monsterHit=1;
									}else{
										monsterHit=3;
									}
								}
								else if (monster3==null|| monster3.HP <= 0){if(monster1.HP<monster2.HP){monsterHit=1;}else{monsterHit=2;}}

							}
						}else{
							if ((monster1.HP <= 0)&&(monster2 == null || monster2.HP<=0)){
								if(monster3==null){if (!isRunning)StartCoroutine (slowText ());
									currentState = BattleStates.ENEMYCHOICE;}
								else if (monster3.HP>0){
								monsterHit=3;
								}else {if (!isRunning)StartCoroutine (slowText ());
									currentState = BattleStates.ENEMYCHOICE;}
							}

							else if ((monster1.HP <= 0)&&(monster3==null|| monster3.HP <= 0)){
								if(monster2==null){if (!isRunning)StartCoroutine (slowText ());
									currentState = BattleStates.ENEMYCHOICE;}
								if (monster2.HP>0){
									monsterHit=2;
								}else {if (!isRunning)StartCoroutine (slowText ());
									currentState = BattleStates.ENEMYCHOICE;}
								}
							else if ((monster2==null|| monster2.HP <= 0)&&(monster3==null|| monster3.HP <= 0)){
								if(monster1==null){if (!isRunning)StartCoroutine (slowText ());
									currentState = BattleStates.ENEMYCHOICE;}
								if (monster1.HP>0){
									monsterHit=1;
								}else {if (!isRunning)StartCoroutine (slowText ());
									currentState = BattleStates.ENEMYCHOICE;}
									}
						}
						switch(monsterHit){

						case 1: 

							if (monster1.HP>0){
								if(Random.Range((1+m.Level/200),59)==58){
									damage=(int)Mathf.Ceil((m.Stren)*Random.Range(0.8f,1f));
								}else{
									damage=(int)Mathf.Ceil((m.Stren-(monster1.Defen)/2)*Random.Range (0.4f,0.6f));
								}
							if (damage<1)damage=1;
								monster1.HP -= damage;

							message[messageNum]=m.MonsterName+" attacks "+monster1.MonsterName+" for "+damage.ToString()+" damage";

							}
							else {
								message[messageNum]=m.MonsterName+" attack fails!";
							}
							break;

						case 2:

							if (monster2.HP > 0)
							{
								if(Random.Range((1+m.Level/200),59)==58){
									damage=(int)Mathf.Ceil((m.Stren)*Random.Range(0.8f,1f));
								}else{
									damage=(int)Mathf.Ceil((m.Stren-(monster2.Defen)/2)*Random.Range (0.4f,0.6f));
								}
							if (damage<1)damage=1;
								monster2.HP -=damage;

								message[messageNum]=m.MonsterName+" attacks "+monster2.MonsterName+" for "+damage.ToString()+" damage";

							}else{

								message[messageNum]=m.MonsterName+" attack fails!";

							}
							break;
						case 3:
							if (monster3.HP > 0)
							{
								if(Random.Range((1+m.Level/200),59)==58){
									damage=(int)Mathf.Ceil((m.Stren)*Random.Range(0.8f,1f));
								}else{
									damage=(int)Mathf.Ceil((m.Stren-(monster3.Defen))/2*Random.Range (0.4f,0.6f));
								}
								if (damage<1)damage=1;
									monster3.HP -= damage;
								message[messageNum]=m.MonsterName+" attacks "+monster3.MonsterName+" for "+damage.ToString()+" damage";
							}else{
								message[messageNum]=m.MonsterName+" attack fails!";
							}
							break;
						}


					}
					Debug.Log("HP: "+monster1.HP);
					Debug.Log ("MNUM: "+monsterNum);
				}
				fightPressed = true;
				showPlayerText1 = false;
			}
			}
			if (fightPressed) {
				if (!showPlayerText1) {
					//SLOW DESCRIPTION
					if (messageNum >= 1){
					GUI.Label (new Rect (20, 375, 100, 20), message[1], customName);

					if (messageNum >= 2){
						GUI.Label (new Rect (20, 405, 100, 20), message[2], customName);

					if (messageNum == 3)
						GUI.Label (new Rect (20, 435, 100, 20), message[3], customName);
					}
					}
				GUI.DrawTexture(new Rect(600, 445, 18, 18), arrow);

				if (!isRunning)StartCoroutine (slowText ());

				currentState = BattleStates.ENEMYCHOICE;

				}

			}


        if (!fightPressed && !scoutPressed && !skillPressed && !runPressed)
        {
            if (GUI.Button(new Rect(20, 420, 300, 45), "SKILL", customButton))
            {
                skillPressed = true;
                showPlayerText1 = false;

            }
        }
        if (skillPressed)
        {
            if (!showPlayerText1)
            {

                GUI.Label(new Rect(20, 375, 100, 20), "No Skills learned yet!", customName);
                GUI.DrawTexture(new Rect(600, 445, 18, 18), arrow);
                if (!isRunning) StartCoroutine(slowText());


            }
        }
		if (!fightPressed && !scoutPressed && !skillPressed && !runPressed)
        {
            if (GUI.Button(new Rect(320, 370, 300, 45), "SCOUT", customButton))
            {
                scoutPressed = true;
                showPlayerText1 = false;

            }
        }
        if (scoutPressed)
        {
            if (!showPlayerText1)
            {

                GUI.Label(new Rect(20, 375, 100, 20), monster1.MonsterName+" successfully captured!", customName);
                GUI.DrawTexture(new Rect(600, 445, 18, 18), arrow);

				if (Input.GetKeyDown("space")|| Input.GetKeyDown("e"))
                {
                    currentState = BattleStates.CAPTURE;
                }

            }
        }
		if (!fightPressed && !scoutPressed && !skillPressed && !runPressed)
        {
            if (GUI.Button(new Rect(320, 420, 300, 45), "RUN", customButton))
            {
                runPressed = true;
                showPlayerText1 = false;

            }
        }
        if (runPressed)
        {
            if (!showPlayerText1)
            {

                GUI.Label(new Rect(20, 375, 100, 20), "Sucessfully Escaped!", customName);
                GUI.DrawTexture(new Rect(600, 445, 18, 18), arrow);
                if (Input.GetKeyDown("space") || Input.GetKeyDown("e"))
                {
                    currentState = BattleStates.END;
                }

            }
        }
        //ENEMYCHOICE



        //CHECK IF DEATH AND IF END
        if (currentState == BattleStates.ENEMYCHOICE)
        {
            //DIVIDE BETWEEN 1 OR 2/3
            if (monster2 != null)
            {
                //DIVIDE BETWEEN 2 AND 3
                if (monster3 != null)
                {
                    //1-2-3
                    if (monster1.HP <= 0)
                    {
                        monster1Dead = true;
						monsterNum=2;

                        if (monster2.HP <= 0)
                        {
                            monster2Dead = true;
							monsterNum=1;

                            if (monster3.HP <= 0)
                            {
                                monster3Dead = true;
								monsterNum=0;
						
								currentState = BattleStates.WIN;
                            }
                            else
                            {
                                //ADD ENEMY ATTACK!!
                                currentState = BattleStates.PLAYERCHOICE;
                            }
                        }//1-3-2
                        else if (monster3.HP <= 0)
                        {
                            monster3Dead = true;
							monsterNum=1;

                            if (monster2.HP <= 0)
                            {
                                monster2Dead = true;
								monsterNum=0;

							
                                currentState = BattleStates.WIN;
                            }
                            else
                            {
                                //ADD ENEMY ATTACK!!
                                currentState = BattleStates.PLAYERCHOICE;
                            }
                        }
                        else
                        {
                            //ADD ENEMY ATTACK!!
                            currentState = BattleStates.PLAYERCHOICE;
                        }
                    }//2-1-3
                    else if (monster2.HP <= 0)
                    {
                        monster2Dead = true;
						monsterNum=2;

                        if (monster1.HP <= 0)
                        {
                            monster1Dead = true;
							monsterNum=1;

                            if (monster3.HP <= 0)
                            {
                                monster3Dead = true;
								monsterNum=0;
							
                                currentState = BattleStates.WIN;
                            }
                            else
                            {
                                //ADD ENEMY ATTACK!!
                                currentState = BattleStates.PLAYERCHOICE;
                            }
                        }//2-3-1
                        else if (monster3.HP <= 0)
                        {
                            monster3Dead = true;
							monsterNum=1;

                            if (monster1.HP <= 0)
                            {
                                monster1Dead = true;
								monsterNum=0;
							
                                currentState = BattleStates.WIN;
                            }
                            else
                            {
                                //ADD ENEMY ATTACK!!
                                currentState = BattleStates.PLAYERCHOICE;
                            }
                        }
                        else
                        {
                            //ADD ENEMY ATTACK!!
                            currentState = BattleStates.PLAYERCHOICE;
                        }
                    }//3-1-2
                    else if (monster3.HP <= 0)
                    {
                        monster3Dead = true;
						monsterNum=2;
					
                        if (monster1.HP <= 0)
                        {
                            monster1Dead = true;
							monsterNum=1;

                            if (monster2.HP <= 0)
                            {
                                monster2Dead = true;
								monsterNum=0;

                                currentState = BattleStates.WIN;
                            }
                            else
                            {
                                //ADD ENEMY ATTACK!!
                                currentState = BattleStates.PLAYERCHOICE;
                            }
                        }//3-2-1
                        else if (monster2.HP <= 0)
                        {
                            monster2Dead = true;
							monsterNum=1;
                            if (monster1.HP <= 0)
                            {
                                monster1Dead = true;
								monsterNum=0;

                                currentState = BattleStates.WIN;
                            }
                            else
                            {
                                //ADD ENEMY ATTACK!!
                                currentState = BattleStates.PLAYERCHOICE;
                            }
                        }
                        else
                        {
                            //ADD ENEMY ATTACK!!
                            currentState = BattleStates.PLAYERCHOICE;
                        }
                    }
                    else
                    {
                        //ADD ENEMY ATTACK!!
                        currentState = BattleStates.PLAYERCHOICE;
                    }

                }//1-2
                else
                {
                    if (monster1.HP <= 0)
                    {
                        monster1Dead = true;
						monsterNum=1;
                        if (monster2.HP <= 0)
                        {
                            monster2Dead = true;
							monsterNum=0;

							currentState = BattleStates.WIN;
                        }
                        else
                        {
                            //ADD ENEMY ATTACK!!
                            currentState = BattleStates.PLAYERCHOICE;
                        }
                    }//2-1
                    else if (monster2.HP <= 0)
                    {
                        monster2Dead = true;
						monsterNum=1;
                        if (monster1.HP <= 0)
                        {
                            monster1Dead = true;
							monsterNum=0;

							currentState = BattleStates.WIN;
                        }
                        else
                        {
                            //ADD ENEMY ATTACK!!
                            currentState = BattleStates.PLAYERCHOICE;
                        }
                    }
                    else
                    {
                        //ADD ENEMY ATTACK!!
                        currentState = BattleStates.PLAYERCHOICE;
                    }
                }

            }//1
            else
            {
                if (monster1.HP <= 0)
                {
					monsterNum=0;
                    monster1Dead = true;

					currentState = BattleStates.WIN;
                }
                else {
                    //ADD ENEMY ATTACK!!
                    currentState = BattleStates.PLAYERCHOICE;
                }
            }
        }
		if (currentState == BattleStates.WIN) {

			showPlayerText1=true;
			fightPressed = true;

			GUI.Label (new Rect (20, 375, 100, 20), "Monsters defeated!",customName);
			GUI.DrawTexture(new Rect(600, 445, 18, 18), arrow);

			if (Input.GetKeyDown ("space") || Input.GetKeyDown ("e")) {
				currentState = BattleStates.END;
			}
		}
	}
}
