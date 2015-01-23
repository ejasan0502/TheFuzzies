using UnityEngine;
using System.Collections;

public class Player : Character {
	public int level;
	public float exp;
	public float expNeeded;
	
	public Attributes attributes;
	public Stats baseStats;
	public Inventory inventory;
	
	public Equip[] equipment;	
		
	private static Object _lock = new Object();
	private static Player _instance;
	public static Player instance {
		get {
			if ( _instance == null ){
				lock(_lock){
					_instance = GameObject.FindWithTag("Player").GetComponent<Player>();
				}
			}
			return _instance;
		}
	}
	
	public float MaxWeight {
		get {
			return level*(attributes.str + attributes.vit*0.5f)*100.0f;
		}
	}
	
	void Awake(){
		LoadData();
	}

	private void LoadData(){
		level = 1;
		exp = 0f;
		expNeeded = level + level * level * 3.141592653f;
		inventory = new Inventory(inventory.maxSlots,inventory.money);
		equipment = new Equip[6];
		CalculateStats();
	}
	
	public void Equip(Equip e){
		if ( e == null ) return;
		
		if ( e.CanEquip(attributes) ){
			Console.Log (e.name + " has been equipped!");
			equipment[(int)e.equipSlot] = e;
			CalculateStats();
			CharacterManager.instance.UpdateCharacterWindow();
		} else {
			Console.Log ("You do not meet the requirements to equip this item");
		}
	}
	
	public void Unequip(int x){
		Equip e = equipment[x];
		if ( e != null ){
			Console.Log (e.name + " has been unequipped!");
			equipment[x] = null;
			CalculateStats();
			CharacterManager.instance.UpdateCharacterWindow();
		}
	}
	
	public void LevelUp(){
		level++;
		CalculateStats();
		
		if ( exp > expNeeded ){
			exp = exp - expNeeded;
		} else {
			exp = 0f;
		}
		expNeeded = level + level * level * 3.141592653f;
	}
	
	private void CalculateBaseStats(){
		baseStats = new Stats();
		baseStats.hp = 10 + level*(attributes.vit + attributes.str*0.5f); 
		baseStats.mp = 10 + level*(attributes.psy + attributes.intel*0.5f); 
		baseStats.hpRecov = baseStats.hp * 0.03f * attributes.vit * level;
		baseStats.mpRecov = baseStats.mp * 0.03f * attributes.psy * level;
		baseStats.physMinDmg = attributes.str * attributes.dex * level * 0.75f;
		baseStats.physMaxDmg = attributes.str * attributes.dex * level;
		baseStats.magMinDmg = attributes.intel * attributes.intel * level * 0.75f;
		baseStats.magMaxDmg = attributes.intel * attributes.intel * level;
		baseStats.pdef = level*(attributes.vit + attributes.str*0.35f);
		baseStats.mdef = level*(attributes.psy + attributes.intel*0.35f);
		baseStats.critChance = 0f;
		baseStats.critDmg = 0f;
		baseStats.atkSpd = 1f;
		baseStats.castSpd = 1f;
		baseStats.movSpd = 20f;
	}
	
	private void CalculateStats(){
		CalculateBaseStats();
		stats = baseStats;
		foreach (Equip e in equipment){
			if ( e != null ) stats += e.stats;
		}
		
		float hp = currentStats.hp;
		float mp = currentStats.mp;
		currentStats = stats;
		currentStats.hp = hp;
		currentStats.mp = mp;
	}
}
