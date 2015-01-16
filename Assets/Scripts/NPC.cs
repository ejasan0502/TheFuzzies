using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPC : InteractableObject {
	public NPCType npcType;
	public float affection = 0.0f;
	public List<string> interests = new List<string>();
	public List<string> dislikes = new List<string>();
	public List<Quest> quests = new List<Quest>();
	public List<Item> inventory = new List<Item>();
	public List<Item> crafts = new List<Item>();

	protected GameObject npcCanvas;
	protected List<string> listedTopic = new List<string>();
	protected string[] topics = new string[10]{
		"food",
		"games",
		"flowers",
		"dragons",
		"fairies",
		"sleep",
		"legends",
		"myths",
		"cats",
		"dogs"
	};

	void Awake(){
		npcCanvas = GameObject.FindWithTag("NPC Canvas") as GameObject;
		if ( npcCanvas != null ){
			npcCanvas.SetActive(false);
		} else {
			Console.Log(this.name + " could not find NPC Canvas object!");
		}
	}

	public override void Interact(Player p){
		if ( npcCanvas == null ) return;

		Show();
		AddListeners();
	}

	protected void HideAllButtons(){
		foreach (Transform o in npcCanvas.transform.GetChild(0).transform){
			o.gameObject.SetActive(false);
		}
	}

	protected void AddListeners(){
		foreach (Transform o in npcCanvas.transform.GetChild(0).transform){
			o.GetComponent<Button>().onClick.RemoveAllListeners();

			switch(o.name.ToLower()){
				case "talk":
				o.GetComponent<Button>().onClick.AddListener(() => Talk());
				break;
				case "quest":
				o.GetComponent<Button>().onClick.AddListener(() => Quest());
				break;
				case "exit":
				o.GetComponent<Button>().onClick.AddListener(() => Exit());
				break;
				case "buy":
				o.GetComponent<Button>().onClick.AddListener(() => Buy());
				break;
				case "craft":
				o.GetComponent<Button>().onClick.AddListener(() => Craft());
				break;
				case "gift":
				o.GetComponent<Button>().onClick.AddListener(() => Gift());
				break;
			}
		}
	}

	protected void Show(){
		npcCanvas.SetActive(true);

		HideAllButtons();

		npcCanvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
		npcCanvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
		npcCanvas.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
		npcCanvas.transform.GetChild(0).GetChild(5).gameObject.SetActive(true);

		switch(npcType){
			case NPCType.craft:
			npcCanvas.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
			break;
			case NPCType.person:
			break;
			case NPCType.shop:
			npcCanvas.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
			break;
		}
	}

	protected void Say(string s){
		if ( npcCanvas == null ) return;

		npcCanvas.transform.GetChild(3).GetComponent<Text>().text = s;
	}

	public void Talk(){
		HideAllButtons();

		npcCanvas.transform.GetChild(0).GetChild(6).gameObject.SetActive(true);

		listedTopic = new List<string>();
		int i = 0;
		foreach (Transform t in npcCanvas.transform.GetChild(0).GetChild(6).transform){
			string s = topics[Random.Range(0,topics.Length)];

			t.GetComponent<Text>().text = s;
			listedTopic.Add(s);

			t.GetComponent<Button>().onClick.RemoveAllListeners();
			if ( i == 0 ) t.GetComponent<Button>().onClick.AddListener(() => Topic1()); else
			if ( i == 1 ) t.GetComponent<Button>().onClick.AddListener(() => Topic2()); else
			if ( i == 2 ) t.GetComponent<Button>().onClick.AddListener(() => Topic3());
			i++;
		}
	}
	public void Topic1(){
		Topic(1);
	}
	public void Topic2(){
		Topic(2);
	}
	public void Topic3(){
		Topic(3);
	}
	protected void Topic(int x){
		if ( x > listedTopic.Count ) return;
		if ( interests.Contains(listedTopic[x]) ){
			affection += affection*0.25f + 1f;
			Say("(Looks intrigued)");
		} else if ( dislikes.Contains(listedTopic[x]) ){
			affection -= affection*0.25f + 1f;
			Say("(Looks annoyed)");
		}

		Show();
	}

	public void Quest(){
		HideAllButtons();

		npcCanvas.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
	}
	public void Exit(){
		npcCanvas.SetActive(false);
	}
	public void Buy(){}
	public void Craft(){}
	public void Gift(){}
}

public enum NPCType {
	shop,
	person,
	craft
}

/*
	
	NPC Canvas Structure:
	NPC Canvas
	-> 0 NPC Buttons
	--> 0 Talk 
	--> 1 Quest
	--> 2 Exit
	--> 3 Buy
	--> 4 Craft
	--> 5 Gift
	--> 6 Topic Buttons
	---> 0 Topic 1
	---> 1 Topic 2
	---> 2 Topic 3
	--> 7 Quest List
	-> 1 Background
	-> 2 NPC Name
	-> 3 Text

	NPC Interaction:
	Affection can provide discounts, unlock quests, recipes, or areas.

	Talk
	Quest 	
	Exit
	Buy
	Sell
	Craft
	Gift

*/
