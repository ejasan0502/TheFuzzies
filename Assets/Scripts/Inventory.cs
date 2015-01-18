using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory {
	public int maxSlots;
	public InventorySlot[] slots;
	public int money;

	public Inventory(){
		maxSlots = 0;
		slots = new InventorySlot[maxSlots];
	}
	public Inventory(int ms, InventorySlot[] s, int m){
		maxSlots = ms;
		slots = s;
		money = m;
	}
	public Inventory(Inventory i){
		maxSlots = i.maxSlots;
		slots = i.slots;
		money = i.money;
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

		return true;
	}

	public void RemoveItem(int x){
		slots[x] = null;
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

	private int GetEmptySlot(){
		for (int i = 0; i < slots.Length; i++){
			if ( slots[i] == null ){
				return i;
			}
		}

		return -1;
	}
	private int GetItemSlot(Item item){
		if ( item.stackable ){
			for (int i = 0; i < slots.Length; i++){
				if ( item.name.ToLower() == slots[i].item.name.ToLower() ){
					return i;
				}
			}
		}

		return GetEmptySlot();
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
