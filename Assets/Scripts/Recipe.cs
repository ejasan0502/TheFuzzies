using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Recipe {
	public string name;
	public string description;
	public Dictionary<Item,int> materials;

	public Recipe(){
		name = "";
		description = "";
		materials = new Dictionary<Item,int>();
	}
	public Recipe(string n, string d, Dictionary<Item,int> m){
		name = n;
		description = d;
		materials = m;
	}
}
