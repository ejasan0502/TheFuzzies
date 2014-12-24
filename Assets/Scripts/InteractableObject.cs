using UnityEngine;
using System.Collections;

public abstract class InteractableObject : MonoBehaviour {
	public bool isLoot = false;

	protected virtual void Start(){
		tag = "interactable";
	}

	public abstract void Interact(Player p);
}
