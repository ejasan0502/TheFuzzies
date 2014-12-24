using UnityEngine;
using System.Collections;

[System.Serializable]
public class Attributes {
	public int str;
	public int vit;

	public int dex;
	public int agi;

	public int intel;
	public int psy;

	public int luk;

	public Attributes(){
		str = 0;
		vit = 0;
		dex = 0;
		agi = 0;
		intel = 0;
		psy = 0;
		luk = 0;
	}

	public Attributes(Attributes a){
		str = a.str;
		vit = a.vit;
		dex = a.dex;
		agi = a.agi;
		intel = a.intel;
		psy = a.psy;
		luk = a.luk;
	}

	public static Attributes operator+(Attributes a1, Attributes a2){
		Attributes a = new Attributes();
		a.str = a1.str + a2.str;
		a.vit = a1.vit + a2.vit;
		a.dex = a1.dex + a2.dex;
		a.agi = a1.agi + a2.agi;
		a.intel = a1.intel + a2.intel;
		a.psy = a1.psy + a2.psy;
		a.luk = a1.luk + a2.luk;
		return a;
	}
	public static Attributes operator-(Attributes a1, Attributes a2){
		Attributes a = new Attributes();
		a.str = a1.str - a2.str;
		a.vit = a1.vit - a2.vit;
		a.dex = a1.dex - a2.dex;
		a.agi = a1.agi - a2.agi;
		a.intel = a1.intel - a2.intel;
		a.psy = a1.psy - a2.psy;
		a.luk = a1.luk - a2.luk;
		return a;
	}
	public static Attributes operator*(Attributes a1, Attributes a2){
		Attributes a = new Attributes();
		a.str = a1.str * a2.str;
		a.vit = a1.vit * a2.vit;
		a.dex = a1.dex * a2.dex;
		a.agi = a1.agi * a2.agi;
		a.intel = a1.intel * a2.intel;
		a.psy = a1.psy * a2.psy;
		a.luk = a1.luk * a2.luk;
		return a;
	}
	public static Attributes operator/(Attributes a1, Attributes a2){
		Attributes a = new Attributes();
		a.str = a1.str / a2.str;
		a.vit = a1.vit / a2.vit;
		a.dex = a1.dex / a2.dex;
		a.agi = a1.agi / a2.agi;
		a.intel = a1.intel / a2.intel;
		a.psy = a1.psy / a2.psy;
		a.luk = a1.luk / a2.luk;
		return a;
	}

	public static bool operator>=(Attributes a1, Attributes a2){
		if ( a1.str < a2.str ) return false;
		if ( a1.vit < a2.vit ) return false;
		if ( a1.dex < a2.dex ) return false;
		if ( a1.agi < a2.agi ) return false;
		if ( a1.intel < a2.intel ) return false;
		if ( a1.psy < a2.psy ) return false;
		if ( a1.luk < a2.luk ) return false;
		return true;
	}
	public static bool operator<=(Attributes a1, Attributes a2){
		if ( a1.str > a2.str ) return false;
		if ( a1.vit > a2.vit ) return false;
		if ( a1.dex > a2.dex ) return false;
		if ( a1.agi > a2.agi ) return false;
		if ( a1.intel > a2.intel ) return false;
		if ( a1.psy > a2.psy ) return false;
		if ( a1.luk > a2.luk ) return false;
		return true;
	}
}
