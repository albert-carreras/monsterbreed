using UnityEngine;
using System.Collections;

[System.Serializable]

public class BaseStatMonster : BaseMonster {

	private int hp;
	private int mp;
	private int stren;
	private int intel;
	private int wisdom;
	private int defen;
	private int level;
	private float modLevel;
	private int ml;
	private int sprite;
	public int HP{

		get{return hp;}
		set{hp=value;}

	}
	public int MP{
		
		get{return mp;}
		set{mp=value;}
		
	}
	public int Stren{
		
		get{return stren;}
		set{stren=value;}
		
	}
	public int Intel{
		
		get{return intel;}
		set{intel=value;}
		
	}
	public int Wisdom{
		
		get{return wisdom;}
		set{wisdom=value;}
		
	}
	public int Defen{
		
		get{return defen;}
		set{defen=value;}
		
	}
	public int Level{
		get{return level;}
		set{level=value;}
	}
	public float ModLevel{
		get{return modLevel;}
		set{modLevel=value;}
	}
	public int ML{
		get{return ml;}
		set{ml=value;}
	}
	public int Sprite{
		get{return sprite;}
		set{sprite=value;}
	}
}
