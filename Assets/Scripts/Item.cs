using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public Texture2D icon;
	public string name;
	public string description;
	public bool stackable;
	public Recipe recipe = null;

	public Item(){
		icon = null;
		name = "";
		description = "";
		stackable = false;
		recipe = null;
	}
	public Item(Texture2D t, string n,string d,bool s, Recipe r){
		icon = t;
		name = n;
		description = d;
		stackable = s;
		recipe = r;
	}
	public Item(Item i){
		icon = i.icon;
		name = i.name;
		description = i.description;
		stackable = i.stackable;
		recipe = i.recipe;
	}
}
