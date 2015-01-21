using UnityEngine;
using System.Collections;

public class Usable : Item {
	public Stats stats;
	public bool res;
	public bool self;
	public bool aoe;

	public Usable(){
		icon = null;
		name = "";
		description = "";
		weight = 0.0f;
		stackable = true;
		stats = new Stats();
		res = false;
		self = false;
		aoe = false;
	}
	public Usable(Usable u){
		icon = u.icon;
		name = u.name;
		description = u.description;
		weight = u.weight;
		stackable = true;
		stats = u.stats;
		res = u.res;
		self = u.self;
		aoe = u.aoe;
	}
}
