using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class ToSaveLoad  {

    public float positionx = PlayerMovement.old_pos.x;
    public float positiony = PlayerMovement.old_pos.y;

    public List<BaseStatMonster> monsterTeam = Team.team;
    public List<BaseStatMonster> monsterList = MonsterList.monstersList;
}
