using UnityEngine;
using System.Reflection;
using System.Collections;

[System.Serializable]
public class Stats {
	public float hp;
	public float mp;

	public float hpRecov;
	public float mpRecov;

	public float physMinDmg;
	public float physMaxDmg;

	public float magMinDmg;
	public float magMaxDmg;

	public float pdef;
	public float mdef;

	public float critChance;
	public float critDmg;

	public float atkSpd;
	public float castSpd;
	public float movSpd;

	public Stats(){
		hp = 1f;
		mp = 0f;
		hpRecov = 0f;
		mpRecov = 0f;
		physMinDmg = 0f;
		physMaxDmg = 0f;
		magMinDmg = 0f;
		magMaxDmg = 0f;
		pdef = 0f;
		mdef = 0f;
		critChance = 0f;
		critDmg = 0f;
		atkSpd = 1f;
		castSpd = 1f;
		movSpd = 1f;
	}

	public Stats(Stats s){
		hp = s.hp;
		mp = s.mp;
		hpRecov = s.hpRecov;
		mpRecov = s.mpRecov;
		physMinDmg = s.physMinDmg;
		physMaxDmg = s.physMaxDmg;
		magMinDmg = s.magMinDmg;
		magMaxDmg = s.magMaxDmg;
		pdef = s.pdef;
		mdef = s.mdef;
		critChance = s.critChance;
		critDmg = s.critDmg;
		atkSpd = s.atkSpd;
		castSpd = s.castSpd;
		movSpd = s.movSpd;
	}

	public static Stats operator+(Stats s1, Stats s2){
		Stats s = new Stats();
		s.hp = s1.hp + s2.hp;
		s.mp = s1.mp + s2.mp;
		s.hpRecov = s1.hpRecov + s2.hpRecov;
		s.mpRecov = s1.mpRecov + s2.mpRecov;
		s.physMinDmg = s1.physMinDmg + s2.physMinDmg;
		s.physMaxDmg = s1.physMaxDmg + s2.physMaxDmg;
		s.magMinDmg = s1.magMinDmg + s2.magMinDmg;
		s.magMaxDmg = s1.magMaxDmg + s2.magMaxDmg;
		s.pdef = s1.pdef + s2.pdef;
		s.mdef = s1.mdef + s2.mdef;
		s.critChance = s1.critChance + s2.critChance;
		s.critDmg = s1.critDmg + s2.critDmg;
		s.atkSpd = s1.atkSpd + s2.atkSpd;
		s.castSpd = s1.castSpd + s2.castSpd;
		s.movSpd = s1.movSpd + s2.movSpd;

		return s;
	}

	public static Stats operator-(Stats s1, Stats s2){
		Stats s = new Stats();
		s.hp = s1.hp - s2.hp;
		s.mp = s1.mp - s2.mp;
		s.hpRecov = s1.hpRecov - s2.hpRecov;
		s.mpRecov = s1.mpRecov - s2.mpRecov;
		s.physMinDmg = s1.physMinDmg - s2.physMinDmg;
		s.physMaxDmg = s1.physMaxDmg - s2.physMaxDmg;
		s.magMinDmg = s1.magMinDmg - s2.magMinDmg;
		s.magMaxDmg = s1.magMaxDmg - s2.magMaxDmg;
		s.pdef = s1.pdef - s2.pdef;
		s.mdef = s1.mdef - s2.mdef;
		s.critChance = s1.critChance - s2.critChance;
		s.critDmg = s1.critDmg - s2.critDmg;
		s.atkSpd = s1.atkSpd - s2.atkSpd;
		s.castSpd = s1.castSpd - s2.castSpd;
		s.movSpd = s1.movSpd - s2.movSpd;

		return s;
	}

	public static Stats operator*(Stats s1, Stats s2){
		Stats s = new Stats();
		s.hp = s1.hp * s2.hp;
		s.mp = s1.mp * s2.mp;
		s.hpRecov = s1.hpRecov * s2.hpRecov;
		s.mpRecov = s1.mpRecov * s2.mpRecov;
		s.physMinDmg = s1.physMinDmg * s2.physMinDmg;
		s.physMaxDmg = s1.physMaxDmg * s2.physMaxDmg;
		s.magMinDmg = s1.magMinDmg * s2.magMinDmg;
		s.magMaxDmg = s1.magMaxDmg * s2.magMaxDmg;
		s.pdef = s1.pdef * s2.pdef;
		s.mdef = s1.mdef * s2.mdef;
		s.critChance = s1.critChance * s2.critChance;
		s.critDmg = s1.critDmg * s2.critDmg;
		s.atkSpd = s1.atkSpd * s2.atkSpd;
		s.castSpd = s1.castSpd * s2.castSpd;
		s.movSpd = s1.movSpd * s2.movSpd;

		return s;
	}

	public static Stats operator/(Stats s1, Stats s2){
		Stats s = new Stats();
		s.hp = s1.hp / s2.hp;
		s.mp = s1.mp / s2.mp;
		s.hpRecov = s1.hpRecov / s2.hpRecov;
		s.mpRecov = s1.mpRecov / s2.mpRecov;
		s.physMinDmg = s1.physMinDmg / s2.physMinDmg;
		s.physMaxDmg = s1.physMaxDmg / s2.physMaxDmg;
		s.magMinDmg = s1.magMinDmg / s2.magMinDmg;
		s.magMaxDmg = s1.magMaxDmg / s2.magMaxDmg;
		s.pdef = s1.pdef / s2.pdef;
		s.mdef = s1.mdef / s2.mdef;
		s.critChance = s1.critChance / s2.critChance;
		s.critDmg = s1.critDmg / s2.critDmg;
		s.atkSpd = s1.atkSpd / s2.atkSpd;
		s.castSpd = s1.castSpd / s2.castSpd;
		s.movSpd = s1.movSpd / s2.movSpd;

		return s;
	}
}