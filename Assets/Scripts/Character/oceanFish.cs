using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oceanFish : MonoBehaviour {

    public GameObject Below, Above, Front;
    public float moveSpeed, rotationSpeed, yMin, yMax;

    Vector3 positionVector;
    float zRotation;

	void Start ()
    {
        positionVector = transform.position;
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
                    transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, Above.transform.position, 0.1f, 0.1f);

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
                    transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, Below.transform.position, 0.1f, 0.1f);

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