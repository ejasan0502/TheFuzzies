using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string name;
	public string description;
	public bool stackable;
	public Recipe recipe = null;

	public Item(){
		name = "";
		description = "";
		stackable = false;
		recipe = null;
	}
	public Item(string n,string d,bool s, Recipe r){
		name = n;
		description = d;
		stackable = s;
		recipe = r;
	}
	public Item(Item i){
		name = i.name;
		description = i.description;
		stackable = i.stackable;
		recipe = i.recipe;
	}
}
