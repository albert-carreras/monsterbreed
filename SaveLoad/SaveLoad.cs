

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
    
    public static void Save() {
        BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/save.gd");

        ToSaveLoad toSaveLoad = new ToSaveLoad();

        bf.Serialize(file, toSaveLoad);
		file.Close();
	}   
	
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/save.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/save.gd", FileMode.Open);

			ToSaveLoad toSaveLoad = (ToSaveLoad)bf.Deserialize(file);

            PlayerPrefs.SetFloat("xPos", toSaveLoad.positionx);
            PlayerPrefs.SetFloat("yPos", toSaveLoad.positiony);
            PlayerPrefs.SetInt("returning", 1);

            foreach (BaseStatMonster m in toSaveLoad.monsterTeam)
            {

                Team.team.Add(m);
            }

            foreach (BaseStatMonster n in toSaveLoad.monsterList)
            {

                MonsterList.monstersList.Add(n);
            }

            file.Close();
		}
	}
}