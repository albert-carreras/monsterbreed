using UnityEngine;
using System.Collections;

public class CreateNewMonster : MonoBehaviour {


	public BaseStatMonster newMonster;
	private string[] nameList = {"Alien",
		"Android",
		"Anon",
		"Anubis",
		"Cyborg",
		"Cyclops",
		"Dryad",
		"Faun",
		"Genie",
		"Gnome",
		"Goblin",
		"God",
		"Godmother",
		"Headless Horseman",
		"Jenny Greenteeth",
		"Kappa",
		"Leprechaun",
		"Liz",
		"Mara",
		"Martian",
		"Mother Goat",
		"Mothman",
		"Mutant",
		"Oni",
		"Orc",
		"Ra",
		"Red Cap",
		"Robot",
		"Robot",
		"Satan",
		"Scribblenaut",
		"Siren",
		"Skeleton Warrior",
		"Spring",
		"Tanuki",
		"Tengu",
		"Vampire",
		"Werewolf",
		"Wight",
		"Zombie",
		"Ahool",
		"Amphis Baena",
		"Elemental",
		"Fairy",
		"Gargoyle",
		"Ghost",
		"Harpy",
		"Jackalope",
		"Mecha",
		"Merman",
		"Ooze",
		"Phoenix",
		"Shoggoth",
		"Wickerman",
		"Wisp",
		"Wolpertinger",
		"Bigfoot",
		"Boggart",
		"Cecaelia",
		"Chupacabra",
		"Death",
		"Flatwoods",
		"Jersey",
		"Medusa",
		"Mermaid",
		"Minotaur",
		"Monster",
		"Mummy",
		"Nuckelavee",
		"Scylla",
		"Succubus",
		"Wraith",
		"Yeti",
		"Ymir",
		"Behemoth",
		"Centaur",
		"Cerberus",
		"Chi",
		"Chimera",
		"Cockatrice",
		"Cthulhu",
		"Dragon",
		"Edison",
		"Giant",
		"Griffin",
		"Haetae",
		"Hydra",
		"Jabberwock",
		"Kraken",
		"Leviathan",
		"Manticore",
		"Nessie",
		"Ninja Shark",
		"Pegasus",
		"Philosoraptor",
		"Robosaur",
		"Roc",
		"Sand Worm",
		"Shambler",
		"Sleipnir",
		"Sphinx",
		"Unicorn"};
	public BaseStatMonster createMonster(){

		newMonster = new BaseStatMonster ();
		int myIndex = Random.Range(0,(nameList.Length-1));
		newMonster.Sprite = Random.Range(1,5);
		newMonster.ML=PlayerPrefs.GetInt("locationLevel");
		newMonster.MonsterName = nameList[myIndex];
		newMonster.MonsterID = Random.Range (0, 101);
		switch(newMonster.ML){
		case 1:
			newMonster.Level = 2;
			newMonster.HP=Random.Range (7,24);
			
			if (newMonster.HP > 20) {
				newMonster.MP = Random.Range (1, 4);
				newMonster.Stren = Random.Range (6, 10);
				if (newMonster.Stren > 8) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
				else{
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 3);
				newMonster.Wisdom = Random.Range (0, 3);
				newMonster.Defen = Random.Range (2, 5);
			}
			else if (newMonster.HP > 16) {
				newMonster.MP = Random.Range (2, 6);
				newMonster.Stren = Random.Range (4, 8);
				newMonster.Intel = Random.Range (2, 6);
				newMonster.Wisdom = Random.Range (2, 5);
				newMonster.Defen = Random.Range (4, 10);
				if (newMonster.Defen > 8) {			
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
				else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}
				
			} else if (newMonster.HP > 12) {
				newMonster.MP = Random.Range (10, 24);
				newMonster.Stren = Random.Range (2, 5);
				newMonster.Intel = Random.Range (3, 8);
				newMonster.Wisdom = Random.Range (3, 7);
				newMonster.Defen = Random.Range (2, 5);
				if (newMonster.Intel > 5 && newMonster.Stren > 3 && newMonster.Defen > 3) {
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
				}
				else{
					newMonster.ModLevel = 1.2f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}
				
			} else if (newMonster.HP > 10) {
				newMonster.MP = Random.Range (20, 40);
				newMonster.Stren = Random.Range (1, 2);
				newMonster.Intel = Random.Range (5, 9);
				newMonster.Wisdom = Random.Range (5, 9);
				newMonster.Defen = Random.Range (1, 4);
				if (newMonster.Intel > 7 && newMonster.Wisdom > 6) {
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
				}else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
				}
				
			} else {
				newMonster.MP = Random.Range (25, 70);
				newMonster.Stren = Random.Range (1, 2);
				newMonster.Intel = Random.Range (6, 12);
				newMonster.Wisdom = Random.Range (6, 12);
				newMonster.Defen = Random.Range (1, 1);
				if (newMonster.Intel > 8) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
				else{			newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
			}
			
			
			break;
		case 2:
			newMonster.Level = 49;
			newMonster.HP=Random.Range (100,999);
			
			if (newMonster.HP > 600) {
				newMonster.MP = Random.Range (6, 40);
				newMonster.Stren = Random.Range (60, 100);
				if (newMonster.Stren > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
				else{
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 13);
				newMonster.Wisdom = Random.Range (0, 13);
				newMonster.Defen = Random.Range (12, 30);
			}
			else if (newMonster.HP > 400) {
				newMonster.MP = Random.Range (24, 90);
				newMonster.Stren = Random.Range (40, 80);
				newMonster.Intel = Random.Range (21, 44);
				newMonster.Wisdom = Random.Range (19, 44);
				newMonster.Defen = Random.Range (41, 100);
				if (newMonster.Defen > 85) {			
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
				else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}
				
			} else if (newMonster.HP > 300) {
				newMonster.MP = Random.Range (103, 260);
				newMonster.Stren = Random.Range (25, 50);
				newMonster.Intel = Random.Range (26, 76);
				newMonster.Wisdom = Random.Range (29, 70);
				newMonster.Defen = Random.Range (12, 49);
				if (newMonster.Intel > 50 && newMonster.Stren > 38 && newMonster.Defen > 33) {
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
				}
				else{
					newMonster.ModLevel = 1.2f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}
				
			} else if (newMonster.HP > 200) {
				newMonster.MP = Random.Range (200, 400);
				newMonster.Stren = Random.Range (10, 25);
				newMonster.Intel = Random.Range (49, 91);
				newMonster.Wisdom = Random.Range (49, 86);
				newMonster.Defen = Random.Range (12, 32);
				if (newMonster.Intel > 70 && newMonster.Wisdom > 60) {
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
				}else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
				}
				
			} else {
				newMonster.MP = Random.Range (300, 800);
				newMonster.Stren = Random.Range (1, 6);
				newMonster.Intel = Random.Range (70, 100);
				newMonster.Wisdom = Random.Range (69, 100);
				newMonster.Defen = Random.Range (1, 15);
				if (newMonster.Intel > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
				else{			newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
			}
			
			
			break;
		case 3:
			newMonster.Level = 49;
			newMonster.HP=Random.Range (100,999);
			
			if (newMonster.HP > 600) {
				newMonster.MP = Random.Range (6, 40);
				newMonster.Stren = Random.Range (60, 100);
				if (newMonster.Stren > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
				else{
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 13);
				newMonster.Wisdom = Random.Range (0, 13);
				newMonster.Defen = Random.Range (12, 30);
			}
			else if (newMonster.HP > 400) {
				newMonster.MP = Random.Range (24, 90);
				newMonster.Stren = Random.Range (40, 80);
				newMonster.Intel = Random.Range (21, 44);
				newMonster.Wisdom = Random.Range (19, 44);
				newMonster.Defen = Random.Range (41, 100);
				if (newMonster.Defen > 85) {			
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
				else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}
				
			} else if (newMonster.HP > 300) {
				newMonster.MP = Random.Range (103, 260);
				newMonster.Stren = Random.Range (25, 50);
				newMonster.Intel = Random.Range (26, 76);
				newMonster.Wisdom = Random.Range (29, 70);
				newMonster.Defen = Random.Range (12, 49);
				if (newMonster.Intel > 50 && newMonster.Stren > 38 && newMonster.Defen > 33) {
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
				}
				else{
					newMonster.ModLevel = 1.2f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}
				
			} else if (newMonster.HP > 200) {
				newMonster.MP = Random.Range (200, 400);
				newMonster.Stren = Random.Range (10, 25);
				newMonster.Intel = Random.Range (49, 91);
				newMonster.Wisdom = Random.Range (49, 86);
				newMonster.Defen = Random.Range (12, 32);
				if (newMonster.Intel > 70 && newMonster.Wisdom > 60) {
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
				}else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
				}
				
			} else {
				newMonster.MP = Random.Range (300, 800);
				newMonster.Stren = Random.Range (1, 6);
				newMonster.Intel = Random.Range (70, 100);
				newMonster.Wisdom = Random.Range (69, 100);
				newMonster.Defen = Random.Range (1, 15);
				if (newMonster.Intel > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
				else{			newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
			}
			
			
			break;
		case 4:
			newMonster.Level = 49;
			newMonster.HP=Random.Range (100,999);
			
			if (newMonster.HP > 600) {
				newMonster.MP = Random.Range (6, 40);
				newMonster.Stren = Random.Range (60, 100);
				if (newMonster.Stren > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
				else{
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 13);
				newMonster.Wisdom = Random.Range (0, 13);
				newMonster.Defen = Random.Range (12, 30);
			}
			else if (newMonster.HP > 400) {
				newMonster.MP = Random.Range (24, 90);
				newMonster.Stren = Random.Range (40, 80);
				newMonster.Intel = Random.Range (21, 44);
				newMonster.Wisdom = Random.Range (19, 44);
				newMonster.Defen = Random.Range (41, 100);
				if (newMonster.Defen > 85) {			
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
				else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}
				
			} else if (newMonster.HP > 300) {
				newMonster.MP = Random.Range (103, 260);
				newMonster.Stren = Random.Range (25, 50);
				newMonster.Intel = Random.Range (26, 76);
				newMonster.Wisdom = Random.Range (29, 70);
				newMonster.Defen = Random.Range (12, 49);
				if (newMonster.Intel > 50 && newMonster.Stren > 38 && newMonster.Defen > 33) {
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
				}
				else{
					newMonster.ModLevel = 1.2f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}
				
			} else if (newMonster.HP > 200) {
				newMonster.MP = Random.Range (200, 400);
				newMonster.Stren = Random.Range (10, 25);
				newMonster.Intel = Random.Range (49, 91);
				newMonster.Wisdom = Random.Range (49, 86);
				newMonster.Defen = Random.Range (12, 32);
				if (newMonster.Intel > 70 && newMonster.Wisdom > 60) {
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
				}else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
				}
				
			} else {
				newMonster.MP = Random.Range (300, 800);
				newMonster.Stren = Random.Range (1, 6);
				newMonster.Intel = Random.Range (70, 100);
				newMonster.Wisdom = Random.Range (69, 100);
				newMonster.Defen = Random.Range (1, 15);
				if (newMonster.Intel > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
				else{			newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
			}
			
			
			break;
		case 5:
			newMonster.Level = 49;
			newMonster.HP=Random.Range (100,999);
			
			if (newMonster.HP > 600) {
				newMonster.MP = Random.Range (6, 40);
				newMonster.Stren = Random.Range (60, 100);
				if (newMonster.Stren > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
				else{
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 13);
				newMonster.Wisdom = Random.Range (0, 13);
				newMonster.Defen = Random.Range (12, 30);
			}
			else if (newMonster.HP > 400) {
				newMonster.MP = Random.Range (24, 90);
				newMonster.Stren = Random.Range (40, 80);
				newMonster.Intel = Random.Range (21, 44);
				newMonster.Wisdom = Random.Range (19, 44);
				newMonster.Defen = Random.Range (41, 100);
				if (newMonster.Defen > 85) {			
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
				else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}
				
			} else if (newMonster.HP > 300) {
				newMonster.MP = Random.Range (103, 260);
				newMonster.Stren = Random.Range (25, 50);
				newMonster.Intel = Random.Range (26, 76);
				newMonster.Wisdom = Random.Range (29, 70);
				newMonster.Defen = Random.Range (12, 49);
				if (newMonster.Intel > 50 && newMonster.Stren > 38 && newMonster.Defen > 33) {
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
				}
				else{
					newMonster.ModLevel = 1.2f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}
				
			} else if (newMonster.HP > 200) {
				newMonster.MP = Random.Range (200, 400);
				newMonster.Stren = Random.Range (10, 25);
				newMonster.Intel = Random.Range (49, 91);
				newMonster.Wisdom = Random.Range (49, 86);
				newMonster.Defen = Random.Range (12, 32);
				if (newMonster.Intel > 70 && newMonster.Wisdom > 60) {
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
				}else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
				}
				
			} else {
				newMonster.MP = Random.Range (300, 800);
				newMonster.Stren = Random.Range (1, 6);
				newMonster.Intel = Random.Range (70, 100);
				newMonster.Wisdom = Random.Range (69, 100);
				newMonster.Defen = Random.Range (1, 15);
				if (newMonster.Intel > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
				else{			newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
			}
			
			
			break;
		case 6:
			newMonster.Level = 49;
			newMonster.HP=Random.Range (100,999);
			
			if (newMonster.HP > 600) {
				newMonster.MP = Random.Range (6, 40);
				newMonster.Stren = Random.Range (60, 100);
				if (newMonster.Stren > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
				else{
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 13);
				newMonster.Wisdom = Random.Range (0, 13);
				newMonster.Defen = Random.Range (12, 30);
			}
			else if (newMonster.HP > 400) {
				newMonster.MP = Random.Range (24, 90);
				newMonster.Stren = Random.Range (40, 80);
				newMonster.Intel = Random.Range (21, 44);
				newMonster.Wisdom = Random.Range (19, 44);
				newMonster.Defen = Random.Range (41, 100);
				if (newMonster.Defen > 85) {			
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
				else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}
				
			} else if (newMonster.HP > 300) {
				newMonster.MP = Random.Range (103, 260);
				newMonster.Stren = Random.Range (25, 50);
				newMonster.Intel = Random.Range (26, 76);
				newMonster.Wisdom = Random.Range (29, 70);
				newMonster.Defen = Random.Range (12, 49);
				if (newMonster.Intel > 50 && newMonster.Stren > 38 && newMonster.Defen > 33) {
					newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
				}
				else{
					newMonster.ModLevel = 1.2f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}
				
			} else if (newMonster.HP > 200) {
				newMonster.MP = Random.Range (200, 400);
				newMonster.Stren = Random.Range (10, 25);
				newMonster.Intel = Random.Range (49, 91);
				newMonster.Wisdom = Random.Range (49, 86);
				newMonster.Defen = Random.Range (12, 32);
				if (newMonster.Intel > 70 && newMonster.Wisdom > 60) {
					newMonster.ModLevel = 0.9f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
				}else{
					newMonster.ModLevel = 1.1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
				}
				
			} else {
				newMonster.MP = Random.Range (300, 800);
				newMonster.Stren = Random.Range (1, 6);
				newMonster.Intel = Random.Range (70, 100);
				newMonster.Wisdom = Random.Range (69, 100);
				newMonster.Defen = Random.Range (1, 15);
				if (newMonster.Intel > 89) {			
					newMonster.ModLevel = 0.8f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
				else{			newMonster.ModLevel = 1f;
					newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
			}
			
			
			break;

		case 7:
		newMonster.Level = 49;
		newMonster.HP=Random.Range (100,999);

		if (newMonster.HP > 600) {
				newMonster.MP = Random.Range (6, 40);
				newMonster.Stren = Random.Range (60, 100);
			if (newMonster.Stren > 89) {			
				newMonster.ModLevel = 0.8f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an absolute KillingMachine!"; }
			else{
				newMonster.ModLevel = 1f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has excellent HP.";}
				newMonster.Intel = Random.Range (0, 13);
				newMonster.Wisdom = Random.Range (0, 13);
				newMonster.Defen = Random.Range (12, 30);
			}
		else if (newMonster.HP > 400) {
			newMonster.MP = Random.Range (24, 90);
			newMonster.Stren = Random.Range (40, 80);
			newMonster.Intel = Random.Range (21, 44);
			newMonster.Wisdom = Random.Range (19, 44);
			newMonster.Defen = Random.Range (41, 100);
			if (newMonster.Defen > 85) {			
				newMonster.ModLevel = 0.9f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is an unkillable Tank!"; }
			else{
				newMonster.ModLevel = 1.1f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " has good HP and Defence.";}

		} else if (newMonster.HP > 300) {
			newMonster.MP = Random.Range (103, 260);
			newMonster.Stren = Random.Range (25, 50);
			newMonster.Intel = Random.Range (26, 76);
			newMonster.Wisdom = Random.Range (29, 70);
			newMonster.Defen = Random.Range (12, 49);
			if (newMonster.Intel > 50 && newMonster.Stren > 38 && newMonster.Defen > 33) {
				newMonster.ModLevel = 1f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is very well rounded!"; 
			}
			else{
				newMonster.ModLevel = 1.2f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is moderately good.";}

		} else if (newMonster.HP > 200) {
			newMonster.MP = Random.Range (200, 400);
			newMonster.Stren = Random.Range (10, 25);
			newMonster.Intel = Random.Range (49, 91);
			newMonster.Wisdom = Random.Range (49, 86);
			newMonster.Defen = Random.Range (12, 32);
			if (newMonster.Intel > 70 && newMonster.Wisdom > 60) {
				newMonster.ModLevel = 0.9f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a very strong SpellCaster!"; 
			}else{
				newMonster.ModLevel = 1.1f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a decent Mage.";
			}

		} else {
			newMonster.MP = Random.Range (300, 800);
			newMonster.Stren = Random.Range (1, 6);
			newMonster.Intel = Random.Range (70, 100);
			newMonster.Wisdom = Random.Range (69, 100);
			newMonster.Defen = Random.Range (1, 15);
			if (newMonster.Intel > 89) {			
				newMonster.ModLevel = 0.8f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " is a GlassCannon!"; }
			else{			newMonster.ModLevel = 1f;
				newMonster.MonsterDescription = "This "+ newMonster.MonsterName + " a weakling Mage!";}
		}


			break;
	}
		choseMonsterType ();
		return newMonster;
	}
	public void choseMonsterType(){

		int temp = Random.Range (0,8);
	switch (temp){
			case 0:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.be;
			break;
			case 1:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.bi;
			break;
			case 2:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.z;
				break;
			case 3:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.bu;
				break;
			case 4:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.p;
				break;
			case 5:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.dr;
			newMonster.ModLevel = newMonster.ModLevel - 0.1f;
				break;
			case 6:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.m;
				break;
			case 7:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.s;
				break;
			case 8:
			newMonster.MonsterType = BaseStatMonster.monsterTypes.bo;
				break;
		}

	}
}			