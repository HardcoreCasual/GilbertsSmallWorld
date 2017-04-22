using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {



    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 5);
	}
}
