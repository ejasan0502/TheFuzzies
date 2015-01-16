using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
	public string description;

	public Stats stats;
	public Stats currentStats;

	protected bool invincible = false;
	protected List<Skill> skills = new List<Skill>();

	#region Get Methods
	public List<Skill> SkillsLearned {
		get { return skills; }
	}
	#endregion

	public void AddSkill(Skill s){
		foreach (Skill ss in skills){
			if ( s == ss ){
				Console.Log(this.name + " already learned " + s.name);
				return;
			}
		}

		skills.Add(s);
	}

	public void RemoveSkill(Skill s){
		foreach (Skill ss in skills){
			if ( s == ss ) {
				skills.Remove(s);
				Console.Log(this.name + " unlearned " + s.name);
				return;
			}
		}
		Console.Log(this.name + " does not have the skill " + s.name);
	}

	public IEnumerator Invincibility(float x){
		invincible = true;
		yield return new WaitForSeconds(x);
		invincible = false;
	}

	public void MagicHit(float rawDmg){
		if ( invincible ) return;

		rawDmg -= currentStats.mdef;
		if ( rawDmg < 0 ) rawDmg = 1f;

		currentStats.hp -= rawDmg;
		if ( currentStats.hp < 1 ){
			Death();
		}
	}
	public void PhysicalHit(float rawDmg){
		if ( invincible ) return;

		rawDmg -= currentStats.pdef;
		if ( rawDmg < 0 ) rawDmg = 1f;

		currentStats.hp -= rawDmg;
		if ( currentStats.hp < 1 ){
			Death();
		}
	}
	public void Attack(){
		
	}
	protected virtual void Death(){}
}
