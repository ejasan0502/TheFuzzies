using UnityEngine;
using System.Collections;

[System.Serializable]
public class Equip : Item {
	public EquipSlot equipSlot;
	public float dura;
	public Stats stats;
	public Attributes reqs;

	public Equip(){
		name = "";
		description = "";
		stackable = false;
		equipSlot = EquipSlot.primaryWeap;
		dura = 100f;
		stats = new Stats();
		reqs = new Attributes();
	}
	public Equip(Equip e){
		name = e.name;
		description = e.description;
		stackable = false;
		equipSlot = e.equipSlot;
		dura = e.dura;
		stats = e.stats;
		reqs = e.reqs;
	}

	public bool CanEquip(Attributes a){
		return a >= reqs;
	}
}

public enum EquipSlot {
	primaryWeap = 0,
	secondaryWeap = 1,

	helm = 2,
	chest = 3,
	pants = 4,
	boots = 5,
	gloves = 6,

	necklace = 7,
	ring1 = 8,
	ring2 = 9,
	earring = 10,
	bracelet = 11,
}
