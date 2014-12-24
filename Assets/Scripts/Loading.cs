using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loading : MonoBehaviour {
	private bool isLoading = false;
	private float percent = 0.0f;
	private float newPercent = 0.0f;
	private List<string> methods = new List<string>();
	private List<GameObject> objects = new List<GameObject>();

	private object _lock = new object();
	public static Loading instance;

	public static bool IsLoading {
		get {
			return instance.isLoading;
		}
	}

	void Awake(){
		lock(_lock){
			if ( instance == null ) instance = this;
		}
	}

	void FixedUpdate(){
		if ( isLoading ){
			percent = Mathf.Lerp(percent,newPercent,Time.deltaTime);
		}
	}

	void OnGUI(){
		if ( isLoading ){
			GUI.depth = -99;
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Loading... " + percent + "%");
		}
	}

	public static void Begin(List<string> l, List<GameObject> o){
		instance.percent = 0.0f;
		instance.newPercent = 0.0f;
		instance.isLoading = true;

		instance.methods = l;
		instance.objects = o;
		instance.StartCoroutine("StartLoading");
	} 

	private IEnumerator StartLoading(){
		int index = 0;

		while ( index < methods.Count ){
			objects[index].SendMessage(methods[index]);
			yield return new WaitForSeconds(5.0f);
			index++;
			newPercent += 100.0f / methods.Count;
		}

		while ( percent < newPercent - 1 ){
			yield return new WaitForSeconds(1.0f);
		}

		percent = 100.0f;
		isLoading = false;
	}
}