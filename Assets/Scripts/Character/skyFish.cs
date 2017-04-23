using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyFish : MonoBehaviour {

    Rigidbody2D fishBody;
    public Vector2 jumpForce;
    bool queueJump;
    Vector3 jumpRotation = new Vector3(0, 0, 45);
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
            transform.eulerAngles = jumpRotation;
        }
    }

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            queueJump = true;
        }
        if (!queueJump && transform.eulerAngles.z > -44)
        {
            Vector3 tempRotation = transform.eulerAngles;
            tempRotation.z -= 1;
            transform.eulerAngles = tempRotation;
        }

    }
}
