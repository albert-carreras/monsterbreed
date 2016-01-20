using UnityEngine;
using System.Collections;

[System.Serializable]

public class BaseMonster{

	private string monsterName;
	private string monsterDescription;
	private int monsterID;
	public enum monsterTypes{

		s,
		m,
		dr,
		p,
		z,
		be,
		bi,
		bu,
		bo
	}
	private monsterTypes monsterType;
	public string MonsterName{
		get{return monsterName;}
		set{monsterName=value;}

	}
	public string MonsterDescription{
		get{return monsterDescription;}
		set{monsterDescription=value;}
		
	}
	public int MonsterID{
		get{return monsterID;}
		set{monsterID=value;}
		
	}
	public monsterTypes MonsterType{
		get{return monsterType;}
		set{monsterType=value;}
		
	}

}
