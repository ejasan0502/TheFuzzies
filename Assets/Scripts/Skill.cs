using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill {
	public string name;
	public string description;
	public Stats stats;
	public List<Skill> prerequisites;

	public virtual void Cast(Character c){}
}
