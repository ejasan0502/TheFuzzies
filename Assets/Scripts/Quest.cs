using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest : MonoBehaviour {
	public string description;
	public List<QuestObjective> objectives;
	public List<Quest> prerequisites;

	public int reward_money;
	public List<Item> reward_items;

	public void Reward(Player p){
		p.inventory.AddMoney(reward_money);
		foreach (Item i in reward_items){
			p.inventory.AddItem(i);
		}
	}
}

[System.Serializable]
public class QuestObjective {
	public NPC npc;
	public List<Character> monsters;
	public List<Item> items;

	public QuestObjective(){
		npc = null;
		monsters = null;
		items = null;
	}
	public QuestObjective(NPC n, List<Character> m, List<Item> i){
		npc = n;
		monsters = m;
		items = i;
	}
	public QuestObjective(QuestObjective qo){
		npc = qo.npc;
		monsters = qo.monsters;
		items = qo.items;
	}
}
