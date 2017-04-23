using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceSpawn : MonoBehaviour {

    public GameObject[] asteroids;
    public float spawnMinimum;

    void Start ()
    {
        StartCoroutine(spawnAsteroid());
	}
	
    IEnumerator spawnAsteroid()
    {
        int enemyPick = Random.Range(0, asteroids.Length);

        Vector2 circlePosition = Random.insideUnitCircle;
        Vector2 spawnPosition = circlePosition.normalized * spawnMinimum;

        if(!(spawnPosition == Vector2.zero))
        Instantiate(asteroids[enemyPick], spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(1);
        StartCoroutine(spawnAsteroid());
    }
}
