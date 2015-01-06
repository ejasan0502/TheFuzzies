using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill : MonoBehaviour {
	public string name;
	public string description;
	public bool passive;
	public bool percent;
	public Stats stats;
	public List<Skill> prerequisites;

	public virtual void Cast(Character c){}

	public Skill(){
		name = "";
		description = "";
		passive = false;
		percent = false;
		stats = new Stats();
		prerequisites = new List<Skill>();
	}
	public Skill(Skill s){
		name = s.name;
		description = s.description;
		passive = s.passive;
		percent = s.percent;
		stats = s.stats;
		prerequisites = s.prerequisites;
	}

	protected void Learn(Character c){
		if ( CanLearn(c) ){
			c.AddSkill(new Skill(this));
		} else {
			Console.Log(c.name + " does not meet the prerequisites. Cannot learn this skill.");
		}
	}

	private bool CanLearn(Character c){
		int count = 0;
		foreach (Skill r in prerequisites){	
			foreach (Skill s in c.SkillsLearned){
				if ( r.name.ToLower() == s.name.ToLower() ){
					count++;
				}
			}	
		}

		return count >= prerequisites.Count ? true : false;
	}
}
