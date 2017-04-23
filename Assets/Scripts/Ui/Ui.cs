using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeleteAllData()
	{
		DataSaving ds = new DataSaving();
		ds.DeleteScores(true);
	}
}
