using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public string description;

	public Stats stats;
	public Stats currentStats;

	protected bool invincible = false;

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
