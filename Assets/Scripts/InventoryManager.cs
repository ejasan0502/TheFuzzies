using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryManager : MonoBehaviour {
	public Player p;
	public Text currencyText;
	public GameObject iconRef;
	public GameObject slotsRect;

	private static Object _lock;
	private static InventoryManager _instance;
	public static InventoryManager instance {
		get {
			if ( _instance == null ) {
				lock(_lock){
					_instance = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
				}
			}
			return _instance;
		}
	}
	private bool display = false;

	void Start(){
		foreach (Transform t in transform){
			t.gameObject.SetActive(display);
		}
		UpdateInventory();
	}

	void Update(){
		#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		if ( Input.GetKeyUp(KeyCode.I) ){
			OpenClose();
		}
		if ( Input.GetKeyUp(KeyCode.Escape) ){
			Exit();
		}
		#endif
	}

	public void OpenClose(){
		display = !display;
		foreach (Transform t in transform){
			t.gameObject.SetActive(display);
		}
		UpdateInventory();
	}

	public void Exit(){
		display = false;
		foreach (Transform t in transform){
			t.gameObject.SetActive(display);
		}
	}

	public void UpdateInventory(){
		foreach (Transform t in transform.GetChild(1)){
			Destroy(t.gameObject);
		}
		for (int i = 0; i < p.inventory.slots.Length; i++){
			if ( p.inventory.slots[i] != null ){
				GameObject o = Instantiate(iconRef) as GameObject;
				o.transform.position = slotsRect.transform.position;
				o.transform.SetParent(slotsRect.transform);
				o.name = i+"";
				if ( p.inventory.slots[i].item.stackable )
					o.transform.localScale *= 0.25f;
				else
					o.transform.localScale *= 0.5f;
				o.SetActive(display);
				if ( display ) {
					o.GetComponent<RawImage>().texture = p.inventory.slots[i].item.icon;
				}
			}
		}
	}

	public void OnDrag(){
		EventSystem.current.currentSelectedGameObject.transform.position = Input.mousePosition;
	}
}
