using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skySpawn : MonoBehaviour {

    public GameObject Cloud, Pillar;

    bool up;    //True if the last enemy spawned was high

    void Start()
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
            float spawnY = Random.Range(-5f, -2f);

            Instantiate(Pillar, new Vector3(10, spawnY, 0), Quaternion.identity);

            up = false;
        }
        else
        {
            float spawnY = Random.Range(-3.15f, 3.15f);

            Instantiate(Cloud, new Vector3(10, spawnY, 0), Quaternion.identity);

            up = true;
        }
        yield return new WaitForSeconds(1.25f);
        StartCoroutine(spawnEnemy());
    }
}
