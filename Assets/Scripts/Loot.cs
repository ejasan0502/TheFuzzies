using UnityEngine;
using System.Collections;

public class Loot : InteractableObject {
	public Item item;
	public int amt;

	protected override void Start(){
		base.Start();
	}

	public override void Interact(Player p){
		if ( item != null ){
			if ( p.inventory.AddItem(new Item(item),amt) ){
				Console.Log(p.name + " has gained " + amt + " " + item.name);
				GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>().UpdateInventory();
				Destroy(gameObject);
			} else {
				Console.Log("Inventory is full!");
			}
		}
	}
}
