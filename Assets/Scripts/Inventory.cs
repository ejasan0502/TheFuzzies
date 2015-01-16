using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory {
	public int maxSlots;
	public Item[] items;	// ???
	public int[] amt;		// ??? Why not use dictionary instead? Limitation?
	public int money;

	public Inventory(){
		maxSlots = 0;
		items = new Item[maxSlots];
		amt = new int[maxSlots];
	}
	public Inventory(int ms, Item[] i, int[] a, int m){
		maxSlots = ms;
		items = i;
		amt = a;
		money = m;
	}
	public Inventory(Inventory i){
		maxSlots = i.maxSlots;
		items = i.items;
		amt = i.amt;
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

		items[index] = i;
		if ( i.stackable ) amt[index] += a;

		return true;
	}

	public void RemoveItem(Item item){
		RemoveItem(item,1);
	}

	public void RemoveItem(Item item, int a){
		for (int i = 0; i < items.Length; i++){
			if ( items[i].name.ToLower() == item.name.ToLower() ){
				amt[i] -= a;
				if ( amt[i] < 1 ){
					items[i] = null;
					amt[i] = 0;
				}
				break;
			}
		}
	}

	public Dictionary<Item,int> IncreaseCapacity(int x){
		maxSlots = x;

		Dictionary<Item,int> extra = new Dictionary<Item,int>();
		Item[] newInv = new Item[maxSlots];
		int[] newAmt = new int[maxSlots];
		for (int i = 0; i < maxSlots; i++){
			newInv[i] = items[i];
			newAmt[i] = amt[i];
		}

		if ( items.Length > newInv.Length ){
			for (int i = newInv.Length; i < items.Length; i++){
				extra.Add(items[i],amt[i]);
			}
		}

		items = newInv;
		amt = newAmt;

		return extra;
	}

	public Item GetItem(Item i){
		foreach (Item item in items){
			if ( i.name.ToLower() == item.name.ToLower()){
				return item;
			}
		}
		return null;
	}
	public Item GetItem(string i){
		foreach (Item item in items){
			if ( i.ToLower() == item.name.ToLower()){
				return item;
			}
		}
		return null;
	}

	private int GetEmptySlot(){
		for (int i = 0; i < items.Length; i++){
			if ( items[i] == null ){
				return i;
			}
		}

		return -1;
	}
	private int GetItemSlot(Item item){
		if ( item.stackable ){
			for (int i = 0; i < items.Length; i++){
				if ( item.name.ToLower() == items[i].name.ToLower() ){
					return i;
				}
			}
		}

		return GetEmptySlot();
	}
}
