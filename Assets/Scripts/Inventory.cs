using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory {
	public int maxSlots;
	public InventorySlot[] slots = null;
	public int money;
	public float weight;
	public float maxWeight;

	public Inventory(){
		maxSlots = 0;
		slots = new InventorySlot[maxSlots];
		money = 0;
		weight = 0.0f;
		maxWeight = 0.0f;
	}
	public Inventory(int ms){
		maxSlots = ms;
		slots = new InventorySlot[maxSlots];
		money = 0;
		weight = 0.0f;
		maxWeight = 0.0f;
	}
	public Inventory(int ms, int m){
		maxSlots = ms;
		slots = new InventorySlot[maxSlots];
		money = m;
		weight = 0.0f;
		maxWeight = 0.0f;
	}
	public Inventory(int ms, InventorySlot[] s, int m){
		maxSlots = ms;
		slots = s;
		money = m;
		CalculateWeight();
	}
	public Inventory(Inventory i){
		maxSlots = i.maxSlots;
		slots = i.slots;
		money = i.money;
		CalculateWeight();
	}

	public void AddMoney(int x){
		money += x;
		if ( money < 0 ) money = 0;
	} 

	public bool AddItem(Item i){
		return AddItem(i,1);
	}

	public bool AddItem(Item i, int a){
		int index = GetItemSlot(i);

		if ( index == -1 ) return false;

		if ( slots[index] == null || !slots[index].item.stackable )
			slots[index] = new InventorySlot(i,a);
		else {
			slots[index].amt += a;
		}
		
		CalculateWeight();

		return true;
	}

	public void RemoveItem(int x){
		slots[x] = null;
		CalculateWeight();
	}

	public List<InventorySlot> SetCapacity(int x){
		maxSlots = x;

		List<InventorySlot> extra = new List<InventorySlot>();
		InventorySlot[] newInv = new InventorySlot[maxSlots];
		for (int i = 0; i < maxSlots; i++){
			newInv[i] = slots[i];
		}

		if ( slots.Length > newInv.Length ){
			for (int i = newInv.Length; i < slots.Length; i++){
				extra.Add(slots[i]);
			}
		}

		slots = newInv;

		return extra;
	}

	public InventorySlot GetSlot(Item it){
		for (int i = 0; i < slots.Length; i++){
			if ( slots[i].item.name.ToLower() == it.name.ToLower() ){
				return slots[i];
			}
		}
		return null;
	}
	
	public Item GetItemAtSlot(int x){
		return slots[x].item;
	}
	
	private void CalculateWeight(){
		maxWeight = Player.instance.MaxWeight;
		weight = 0.0f;
		foreach (InventorySlot i in slots){
			if ( i != null ) weight += i.item.weight*i.amt;
		}
		
		if ( weight > maxWeight*0.8f ){
			Player.instance.currentStats.movSpd = Player.instance.stats.movSpd * 0.5f;
		} else if ( weight > maxWeight*0.4f ){
			Player.instance.currentStats.movSpd = Player.instance.stats.movSpd;
		} else {
			Player.instance.currentStats.movSpd = Player.instance.stats.movSpd;
		}
	}

	private int GetItemSlot(Item item){
		for (int i = 0; i < slots.Length; i++){
			if ( slots[i] == null || (item.stackable && item.name.ToLower() == slots[i].item.name.ToLower()) ){
				return i;
			}
		}

		return -1;
	}
}

public class InventorySlot {
	public Item item;
	public int amt;

	public InventorySlot(){
		item = null;
		amt = 0;
	}

	public InventorySlot(Item i, int a){
		item = i;
		amt = a;
	}
}
