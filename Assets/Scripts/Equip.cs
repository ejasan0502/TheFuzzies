using UnityEngine;
using System.Collections;

[System.Serializable]
public class Equip : Item {
	public EquipSlot equipSlot;
	public float dura;
	public Stats stats;
	public Attributes reqs;

	public Equip(){
		icon = null;
		name = "";
		description = "";
		weight = 0.0f;
		stackable = false;
		equipSlot = EquipSlot.weapon;
		dura = 100f;
		stats = new Stats();
		reqs = new Attributes();
	}
	public Equip(Equip e){
		icon = e.icon;
		name = e.name;
		description = e.description;
		weight = e.weight;
		stackable = false;
		equipSlot = e.equipSlot;
		dura = e.dura;
		stats = e.stats;
		reqs = e.reqs;
	}

	public bool CanEquip(Attributes a){
		return a >= reqs;
	}
	
	public override Equip GetAsEquip ()
	{
		return this;
	}
}

public enum EquipSlot {
	weapon = 0,
	hat = 1,
	shirt = 2,
	pants = 3,
	shoes = 4,
	gloves = 5
}
