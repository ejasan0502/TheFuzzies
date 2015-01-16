using UnityEngine;
using System.Collections;

public class InteractControl : MonoBehaviour {
	public KeyCode key = KeyCode.E;

	private bool animating = false;
	private Player p = null;

	void Start(){
		p = GetComponent<Player>();
		if ( p == null ) {
			Console.Log(this.name + " does not have a Player component attached... Removing InteractControl");
			Destroy(GetComponent<InteractControl>());
		}
	}

	void Update(){
		#if UNITY_EDITOR || UNITY_STANDALONE
		if ( Input.GetKeyDown(key) && !animating ){
			InteractWithObject();
		}
		#endif
	}

	public void InteractWithObject(){
		if ( animating ) return;

		animating = true;
		InteractableObject closestInteractable = null;
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("interactable")){
			InteractableObject l = o.GetComponent<InteractableObject>();

			if ( l == null ) break;

			if ( closestInteractable != null ){
				if ( Vector3.Distance(closestInteractable.gameObject.transform.position,transform.position) > 
					 Vector3.Distance(l.gameObject.transform.position,transform.position) ){
					closestInteractable = l;
				}
			} else {
				closestInteractable = l;
			}
		}

		if ( closestInteractable != null ){
			closestInteractable.Interact(p);
		}
	}

	// Called when any animation ends
	public void OnAnimationEnd(){
		animating = false;
	}
}
