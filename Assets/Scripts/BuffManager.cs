using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffManager : MonoBehaviour {

	private Character c = null;

	private List<Status> statuses = new List<Status>();

	void Start(){
		c = GetComponent<Character>();
		if ( c == null ) {
			Console.Log(this.name + " does not have a Character component attached... Removing BuffManager");
			Destroy(GetComponent<BuffManager>());
		}

		InvokeRepeating("CheckStatus",1f,1f);
	}

	void OnDisable(){
		CancelInvoke();
	}

	private void CheckStatus(){
		foreach (Status s in statuses){
			if ( s.frequency > 0 ){
				float currentTime = Time.time - s.startTime;
				if ( currentTime%s.frequency == 0 && currentTime != 0 ){
					c.currentStats += s.stats;
				}
			} else if ( s.duration == s.maxDuration ){
				c.currentStats += s.stats;
			}

			s.duration -= 1;
			if ( s.duration < 0 ){
				RemoveStatus(s);
			}
		}
	}

	private int Has(Status s){
		for (int i = 0; i < statuses.Count; i++){
			if ( statuses[i].name.ToLower() == s.name.ToLower() ) return i;
		}
		return -1;
	}

	public void AddStatus(Status s){
		int index = Has(s);
		if ( index == -1 ){
			statuses.Add(s);
		} else {
			statuses[index].maxDuration += s.maxDuration;
			statuses[index].duration = statuses[index].maxDuration;
		}
	}

	public void RemoveStatus(Status s){
		c.currentStats -= s.stats;
		statuses.Remove(s);
	}
	public void RemoveStatus(int x){
		if ( x >= statuses.Count || x < 0 ) return;
		c.currentStats -= statuses[x].stats;
		statuses.Remove(statuses[x]);
	}
}

/*
	Rules:
	There cannot be more than one of the same name status on a character.
	Being inflicted with an existing status will reset the timer for that status.


	Names of all Statuses:
	resting,	// Increase in hp and mp recovery
	atkBoost,	// Increase in damage
	defBoost,	// Increase in defense
	spdBoost,	// Increase in speed
	critBoost,	// Increase in crit

	burn,		// Damage over time, high damage over a short period of time
	frostbite,	// Decrease in speed (atk, cast, movt)
	frozen,		// Cannot perform an action, chance to instant death upon receiving critical hits
	stunned,	// Momentarily cannot perform an action
	sleep,		// Cannot perform an action, chance to wake up upon receiving damage
	fear,		// Cannot perform an action, random movement
	paralysis,	// Cancels/Cannot perform an action every X seconds for X seconds
	poison		// Damage over time, low damage over a long period of time
*/

public class Status {
	public string name;		// Name of status
	public Stats stats;		// Stats to apply to target
	public int duration;	// How long the state lasts
	public int frequency;	// How frequent the stats are applied to the target, 0 = once, x > 0 = every x

	public float startTime;	// Time when inflicted
	public int maxDuration;	// Duration

	public Status(string n, Stats s, int d, int f){
		name = n;
		stats = s;
		duration = d;
		frequency = f;
		startTime = Time.time;
		maxDuration = d;
	}
}