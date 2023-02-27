using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSatellites : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sat;
    float[] dimentions = { -10.50f, 10.50f,-4.51f,4.51f };

    float currentTime;
    float minTimeBetweenSpawns;
    float maxTimeBetweenSpawns;

    void Start()
    {
        minTimeBetweenSpawns = 5;
        maxTimeBetweenSpawns = 10;
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Instantiate(sat, new Vector3(Random.Range(dimentions[0], dimentions[1]), Random.Range(dimentions[2], dimentions[3]), transform.position.z), transform.rotation);
            currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        }
    }
}
