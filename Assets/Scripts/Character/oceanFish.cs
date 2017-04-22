using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oceanFish : MonoBehaviour {

    public float moveSpeed, rotationSpeed, yMin, yMax;

    Vector3 positionVector;
    float zRotation;

	void Start ()
    {
        positionVector = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(0);
        }
    }

    void Update ()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            if (zRotation < 0 && zRotation + Time.deltaTime * rotationSpeed < 0)
                zRotation += Time.deltaTime * rotationSpeed;
            else if (zRotation > 0 && zRotation - Time.deltaTime * rotationSpeed > 0)
                zRotation -= Time.deltaTime * rotationSpeed;
            else
                zRotation = 0;
        }
        else
        { 
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (transform.position.y < yMax && (transform.position.y + (Time.deltaTime * moveSpeed) < yMax))
                {
                    positionVector.y += Time.deltaTime * moveSpeed;

                    if (zRotation > -45 && zRotation - Time.deltaTime * rotationSpeed > -45)
                        zRotation -= Time.deltaTime * rotationSpeed;
                    else
                        zRotation = -45;
                }
                else
                {
                    if (zRotation < 0 && zRotation + Time.deltaTime * rotationSpeed < 0)
                        zRotation += Time.deltaTime * rotationSpeed;
                    else if (zRotation > 0 && zRotation - Time.deltaTime * rotationSpeed > 0)
                        zRotation -= Time.deltaTime * rotationSpeed;
                    else
                        zRotation = 0;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (transform.position.y > yMin && (transform.position.y - (Time.deltaTime * moveSpeed) > yMin))
                {
                    positionVector.y -= Time.deltaTime * moveSpeed;

                    if (zRotation < 45 && zRotation + Time.deltaTime * rotationSpeed < 45)
                        zRotation += Time.deltaTime * rotationSpeed;
                    else
                        zRotation = 45;
                }
                else
                {
                    if (zRotation < 0 && zRotation + Time.deltaTime * rotationSpeed < 0)
                        zRotation += Time.deltaTime * rotationSpeed;
                    else if (zRotation > 0 && zRotation - Time.deltaTime * rotationSpeed > 0)
                        zRotation -= Time.deltaTime * rotationSpeed;
                    else
                        zRotation = 0;
                }
            }
            else
            {
                if (zRotation < 0 && zRotation + Time.deltaTime * rotationSpeed < 0)
                    zRotation += Time.deltaTime * rotationSpeed;
                else if (zRotation > 0 && zRotation - Time.deltaTime * rotationSpeed > 0)
                    zRotation -= Time.deltaTime * rotationSpeed;
                else
                    zRotation = 0;
            }
        }

        transform.eulerAngles = new Vector3(0, 180, zRotation);

        transform.position = positionVector;
	}
}