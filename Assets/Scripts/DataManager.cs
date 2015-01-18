using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {
	// Equipment
	public List<Equip> bombs;
	public List<Equip> swords;
	public List<Equip> hammers;
	public List<Equip> armors;

	private string path;
	private Dictionary<string,byte[]> data = new Dictionary<string,byte[]>();

	private static object _lock = new object();
	private static DataManager _instance;
	public static DataManager instance {
		get {
			if ( _instance == null ) {
				lock(_lock){
					DataManager d = GameObject.Find("DataManager").GetComponent<DataManager>();
					if ( d == null ){
						GameObject o = new GameObject("DataManager");
						_instance = o.AddComponent<DataManager>();
					} else {
						_instance = d;
					}
				}
			}
			return _instance;
		}
	}

	void Awake(){
		DontDestroyOnLoad(this);
	}

	void Start(){
		path = Application.persistentDataPath + "/data.data";
		LoadData();
	}

	#region SetData overload methods
	public void SetData(string name, string val){
		if ( data.ContainsKey(name) ){
			data[name] = stringToBytes(val);
		} else {
			data.Add(name,stringToBytes(val));
		}
	}
	public void SetData(string name, bool val){
		if ( data.ContainsKey(name) ){
			data[name] = boolToBytes(val);
		} else {
			data.Add(name,boolToBytes(val));
		}
	}
	public void SetData(string name, float val){
		if ( data.ContainsKey(name) ){
			data[name] = intToBytes((int)(val * 1000));
		} else {
			data.Add(name,intToBytes((int)(val * 1000)));
		}
	}
	public void SetData(string name, int val){
		if ( data.ContainsKey(name) ){
			data[name] = intToBytes(val);
		} else {
			data.Add(name,intToBytes(val));
		}
	}
	#endregion
	#region GetData methods
	public string GetDataAsString(string label) {
		if ( data.ContainsKey(label) ){
			return bytesToString(data[label]);
		}
		return "";
	}
	
	public int GetDataAsInt(string label) {
		if ( data.ContainsKey(label) ){
			return bytesToInt(data[label]);
		}
		return 0;
	}
	
	public float GetDataAsFloat(string label) {
		if ( data.ContainsKey(label) ){
			return bytesToInt(data[label]) / 1000.00f;
		}
		return 0f;
	}
	
	public bool GetDataAsBool(string label) {
		if ( data.ContainsKey(label) ){
			return bytesToBool(data[label]);
		}
		return false;
	}
	#endregion

	public void SaveData() {
		List<byte[]> blocks = new List<byte[]>();
		
		int size = 0;

		foreach(var v in data){
			byte[] label = Encoding.ASCII.GetBytes(v.Key);
			for(int i = 0; i < label.Length; i++) {
				label[i] = (byte)(label[i] ^ 0xff);
			}
			byte[] val = v.Value;
			
			byte[] value_bytes = new byte[label.Length + 5];
			
			value_bytes[0] = (byte)label.Length;
			
			System.Buffer.BlockCopy(label, 0, value_bytes, 1, label.Length);
			System.Buffer.BlockCopy(val, 0, value_bytes, 1 + label.Length, 4);
			
			blocks.Add(value_bytes);
			
			size += value_bytes.Length;
		}
		
		byte[] values_bytes = new byte[size];
		int index = 0;
		for(int i = 0; i < blocks.Count; i++) {
			System.Buffer.BlockCopy(blocks[i], 0, values_bytes, index, blocks[i].Length);
			index += blocks[i].Length;
		}
		
		if (!System.IO.File.Exists(path))
		{
			FileStream fs = System.IO.File.Create(path);
			fs.Close();
		}
		
		File.WriteAllBytes(path, values_bytes);
	}
	
	public void LoadData() {
		byte[] bytes;
		data.Clear();
		
		if(File.Exists(path)) {
			bytes = File.ReadAllBytes(path);
		} else {
			FileStream fs = System.IO.File.Create(path);
			fs.Close();
			return;
		}
		
		int index = 0;
		while(index < bytes.Length) {
			int l = bytes[index];
			byte[] labelBytes = new byte[l];
			byte[] dataBytes = new byte[4];
			System.Buffer.BlockCopy(bytes, index + 1, labelBytes, 0, l);
			System.Buffer.BlockCopy(bytes, index + 1 + l, dataBytes, 0, 4);
			
			for(int i = 0; i < labelBytes.Length; i++) {
				labelBytes[i] = (byte)(labelBytes[i] ^ 0xff);
			}
			string label = Encoding.ASCII.GetString(labelBytes);
			byte[] val = dataBytes;
			
			data.Add(label,val);
			
			index += 5 + l;
		}
	}

	private byte[] stringToBytes(string str) {
		return Encoding.ASCII.GetBytes(str);
	}
	
	private string bytesToString(byte[] byteArray) {
		return Encoding.ASCII.GetString(byteArray);
	}
	
	private byte[] intToBytes(int myInteger){
		byte[] byteArray = new byte[4];
		byteArray[0] = (byte)(myInteger >> 24);
		byteArray[1] = (byte)(myInteger >> 16);
		byteArray[2] = (byte)(myInteger >> 8);
		byteArray[3] = (byte)myInteger;
		return byteArray;
	}
	
	private int bytesToInt(byte[] byteArray){
		if (System.BitConverter.IsLittleEndian)
			System.Array.Reverse(byteArray);
		int myInteger = System.BitConverter.ToInt32(byteArray, 0);
		return myInteger;
	}
	
	private byte[] boolToBytes(bool myBool) {
		int num = (myBool) ? 1 : 0;
		byte[] byteArray = new byte[4];
		byteArray[0] = (byte)0;
		byteArray[1] = (byte)0;
		byteArray[2] = (byte)0;
		byteArray[3] = (byte)num;
		return byteArray;
	}
	
	private bool bytesToBool(byte[] byteArray) {
		return (byteArray[3] == 1);
	}	
}