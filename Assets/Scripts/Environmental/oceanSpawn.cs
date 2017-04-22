using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oceanSpawn : MonoBehaviour {

    public GameObject Hook, Seaweed;

    bool up;    //True if the last enemy spawned was high

	void Start ()
    {
        int startBool = Random.Range(0, 2);
        if (startBool == 0)
            up = true;
        else
            up = false;

        StartCoroutine(spawnEnemy());
	}
	
    IEnumerator spawnEnemy()
    {
        if (up)
        {
            float spawnY = Random.Range(-4.5f, -1.5f);

            Instantiate(Seaweed, new Vector3(10, spawnY, 0), Quaternion.identity);

            up = false;
        }
        else
        {
            float spawnY = Random.Range(1.5f, 5);

            Instantiate(Hook, new Vector3(10, spawnY, 0), Quaternion.identity);

            up = true;
        }
        yield return new WaitForSeconds(1.25f);
        StartCoroutine(spawnEnemy());
    }

}
