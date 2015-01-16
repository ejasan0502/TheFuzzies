using UnityEngine;
using System.Collections;

public class Loot : InteractableObject {
	public Item item;

	protected override void Start(){
		base.Start();
	}

	public override void Interact(Player p){
		if ( item != null ){
			p.inventory.AddItem(item);
			Destroy(gameObject);
		}
	}
}
