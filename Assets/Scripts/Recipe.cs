using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Recipe {
	public string name;
	public string description;
	public List<Ingredient> ingredients;

	public Recipe(){
		name = "";
		description = "";
		ingredients = new List<Ingredient>();
	}
	public Recipe(string n, string d, List<Ingredient> m){
		name = n;
		description = d;
		ingredients = m;
	}
}

[System.Serializable]
public class Ingredient {
	public string name;
	public Item item;
	public int amt;

	public Ingredient(){
		name = "";
		item = null;
		amt = 0;
	}
	public Ingredient(string n, Item i, int a){
		name = n;
		item = i;
		amt = a;
	}
}
