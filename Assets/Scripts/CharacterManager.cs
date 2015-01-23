using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterManager : MonoBehaviour
{
	public Text statsText;
	public bool display = false;
	
	private static Object _lock = new Object();
	private static CharacterManager _instance;
	public static CharacterManager instance {
		get {
			if ( _instance == null ) {
				lock(_lock){
					_instance = GameObject.FindWithTag("CharacterManager").GetComponent<CharacterManager>();
				}
			}
			return _instance;
		}
	}
	
	void Start(){
		if ( _instance == null ) _instance = this;
		statsText.text = Player.instance.stats.ToString ();
		foreach (Transform t in transform){
			t.gameObject.SetActive(display);
		}
	}
	
	void Update(){
		#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		if ( Input.GetKeyUp(KeyCode.C) ){
			OpenClose();
		}
		if ( Input.GetKeyUp(KeyCode.Escape) ){
			Exit();
		}
		#endif
	}
	public void UpdateCharacterWindow(){
		statsText.text = Player.instance.stats.ToString ();
	}
	
	public void OpenClose(){
		display = !display;
		foreach (Transform t in transform){
			t.gameObject.SetActive(display);
		}
		UpdateCharacterWindow();
	}
	
	public void Exit(){
		display = false;
		foreach (Transform t in transform){
			t.gameObject.SetActive(display);
		}
	}
}

