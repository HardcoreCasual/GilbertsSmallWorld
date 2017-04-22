using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyFish : MonoBehaviour {

    Rigidbody2D fishBody;
    public Vector2 jumpForce;
    bool queueJump;

    void Start ()
    {
        fishBody = GetComponent<Rigidbody2D>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            Application.LoadLevel(0);
        }
    }

    void FixedUpdate()
    {
        if (queueJump)
        {
            fishBody.velocity = Vector2.zero;
            fishBody.AddForce(jumpForce, ForceMode2D.Impulse);
            queueJump = false;
        }
    }

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            queueJump = true;
        }
	}
}
