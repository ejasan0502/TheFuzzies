using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Player))]
public class InteractControl : MonoBehaviour {
	public KeyCode key = KeyCode.E;

	private bool animating = false;
	private Player p = null;
	private Animator anim;

	void Awake(){
		p = GetComponent<Player>();
		anim = GetComponent<Animator>();
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
		anim.SetBool("Pickup",animating);

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
		} else {
			Console.Log("No interactable object close by");
		}
	}

	// Called when any animation ends
	public void OnAnimationEnd(){
		animating = false;
		anim.SetBool("Pickup",animating);
	}
}
