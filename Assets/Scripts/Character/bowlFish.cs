using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlFish : MonoBehaviour
{

    Rigidbody2D fishBody;
    Vector3 leftRotation = new Vector3(0, 0, 0), rightRotation = new Vector3(0, 180, 0);
    Vector3 inputVector = Vector3.zero;

    Animator fishAnim;
    Animation Swim, Idle;

    void Start()
    {
        fishBody = GetComponent<Rigidbody2D>();
        fishAnim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        inputVector = Vector3.zero;
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            if(inputVector.y > 0)
            {
                if (inputVector.y - Time.deltaTime > 0)
                    inputVector.y -= Time.deltaTime;
                else
                    inputVector.y = 0;
            }
            else if (inputVector.y < 0)
            {
                if (inputVector.y + Time.deltaTime < 0)
                    inputVector.y += Time.deltaTime;
                else
                    inputVector.y = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (inputVector.y + Time.deltaTime < 1.5f)
                    inputVector.y += Time.deltaTime;
                else
                    inputVector.y = 1.5f;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (inputVector.y - Time.deltaTime > -1.5f)
                    inputVector.y -= Time.deltaTime;
                else
                    inputVector.y = -1.5f;
            }
            else
            {
                if (inputVector.y > 0)
                {
                    if (inputVector.y - Time.deltaTime > 0)
                        inputVector.y -= Time.deltaTime;
                    else
                        inputVector.y = 0;
                }
                else if (inputVector.y < 0)
                {
                    if (inputVector.y + Time.deltaTime < 0)
                        inputVector.y += Time.deltaTime;
                    else
                        inputVector.y = 0;
                }
            }
        }

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            if (inputVector.x > 0)
            {
                if (inputVector.x - Time.deltaTime > 0)
                    inputVector.x -= Time.deltaTime;
                else
                    inputVector.x = 0;
            }
            else if (inputVector.x < 0)
            {
                if (inputVector.x + Time.deltaTime < 0)
                    inputVector.x += Time.deltaTime;
                else
                    inputVector.x = 0;
            }
        }
        else
        { 
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (inputVector.x - Time.deltaTime > -1.5f)
                    inputVector.x -= Time.deltaTime;
                else
                    inputVector.x = -1.5f;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (inputVector.x + Time.deltaTime < 1.5f)
                    inputVector.x += Time.deltaTime;
                else
                    inputVector.x = 1.5f;
            }
            else
            {
                if (inputVector.x > 0)
                {
                    if (inputVector.x - Time.deltaTime > 0)
                        inputVector.x -= Time.deltaTime;
                    else
                        inputVector.x = 0;
                }
                else if (inputVector.x < 0)
                {
                    if (inputVector.x + Time.deltaTime < 0)
                        inputVector.x += Time.deltaTime;
                    else
                        inputVector.x = 0;
                }
            }
        }

        if (inputVector.x > 0)
        {
            transform.eulerAngles = rightRotation;
        }
        else if (inputVector.x < 0)
        {
            transform.eulerAngles = leftRotation;
        }

        //if (inputVector == Vector3.zero)
        //{
        //    inputVector = fishBody.velocity * 0.9f;
        //}

        if (inputVector.x != 0)
        {
            print("fish is moving");
            fishAnim.SetFloat("speed", Mathf.Abs(inputVector.x));
        }
        else
        {
            fishAnim.SetFloat("speed", 0);
        }

        fishBody.velocity = inputVector;
    }
}
