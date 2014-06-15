using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public string NextLevel = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Win() {
		if(NextLevel!="")
			Application.LoadLevel(NextLevel);
	}
}
