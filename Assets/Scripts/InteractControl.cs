using UnityEngine;
using System.Collections;

public class InteractControl : MonoBehaviour {
	public KeyCode pickupKey = KeyCode.E;

	private bool animating = false;

	void Update(){
		if ( Input.GetKeyDown(pickupKey) && !animating ){
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
				closestInteractable.Interact(GetComponent<Player>());
			}
		}
	}

	// Called when pickup animation ends
	public void OnPickUpEnd(){
		animating = false;
	}
}
