using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string name;
	public string description;
	public bool stackable;

	public Item(){
		name = "";
		description = "";
		stackable = false;
	}
	public Item(string n,string d,bool s){
		name = n;
		description = d;
		stackable = s;
	}
	public Item(Item i){
		name = i.name;
		description = i.description;
		stackable = i.stackable;
	}
}
