using UnityEngine;
using System.Collections;

public class Player : Character {
	public Inventory inventory;

	void Awake(){
		LoadData();
	}

	private void LoadData(){
		// Check if data is there, if not
		inventory = new Inventory(inventory.maxSlots,inventory.money);
	}
}
