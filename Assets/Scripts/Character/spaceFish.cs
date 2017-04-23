using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceFish : MonoBehaviour {

    Animator fishAnim;
    SpriteRenderer fishRenderer;

	void Start ()
    {
        //fishAnim = GetComponent<Animator>();
        fishRenderer = GetComponent<SpriteRenderer>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("Die");
    }

	void Update ()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            //fishAnim.SetFloat("speed", 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 200);
                //fishAnim.SetFloat("speed", 1);

                fishRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.RotateAround(Vector3.zero, Vector3.back, Time.deltaTime * 200);
                //fishAnim.SetFloat("speed", 1);

                fishRenderer.flipX = true;
            }
            else
            {
                //fishAnim.SetFloat("speed", 0);
            }
        }
	}
}
