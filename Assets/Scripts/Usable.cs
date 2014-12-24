using UnityEngine;
using System.Collections;

public class Usable : Item {
	public Stats stats;
	public bool res;
	public bool self;
	public bool aoe;

	public Usable(){
		name = "";
		description = "";
		stackable = true;
		stats = new Stats();
		res = false;
		self = false;
		aoe = false;
	}
	public Usable(Usable u){
		name = u.name;
		description = u.description;
		stackable = true;
		stats = u.stats;
		res = u.res;
		self = u.self;
		aoe = u.aoe;
	}
}
