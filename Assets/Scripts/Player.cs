using UnityEngine;
using System.Collections;

public class Player : Character {
	public Attributes attributes;
	public Inventory inventory;
	
	private static Object _lock = new Object();
	private static Player _instance;
	public static Player instance {
		get {
			if ( _instance == null ){
				lock(_lock){
					_instance = GameObject.FindWithTag("Player").GetComponent<Player>();
				}
			}
			return _instance;
		}
	}
	
	public float MaxWeight {
		get {
			return (attributes.str + attributes.vit*0.5f)*100.0f;
		}
	}
	
	void Awake(){
		LoadData();
	}

	private void LoadData(){
		// Check if data is there, if not
		inventory = new Inventory(inventory.maxSlots,inventory.money);
	}
}
