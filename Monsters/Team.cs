using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]

public class Team : MonoBehaviour {

    public static List<BaseStatMonster> team = new List<BaseStatMonster>();


        void Start() {


        if (team.Count == 0) {
            BaseStatMonster monster = new CreateNewMonster().createMonster();
            monster.MonsterName = "Slimy";
            monster.MonsterType = BaseMonster.monsterTypes.s;
            monster.Sprite = 1;
            team.Add(monster);
            
        }
        foreach (BaseStatMonster m in team) {

            Debug.Log(m.MonsterName);
        }
        foreach (BaseStatMonster n in MonsterList.monstersList)
        {

            Debug.Log(n.MonsterName);
        }
    }
}
