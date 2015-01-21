using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string name;
	public Texture2D icon;
	public string description;
	public float weight;
	public bool stackable;
	public Recipe recipe = null;

	public Item(){
		icon = null;
		name = "";
		description = "";
		weight = 0.0f;
		stackable = false;
		recipe = null;
	}
	public Item(Texture2D t, string n, string d, float w, bool s, Recipe r){
		icon = t;
		name = n;
		description = d;
		weight = w;
		stackable = s;
		recipe = r;
	}
	public Item(Item i){
		icon = i.icon;
		name = i.name;
		description = i.description;
		weight = i.weight;
		stackable = i.stackable;
		recipe = i.recipe;
	}
}
