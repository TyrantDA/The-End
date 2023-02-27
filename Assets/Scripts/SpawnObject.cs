using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    float currentTime;
    float minTimeBetweenSpawns;
    float maxTimeBetweenSpawns;

    public  GameObject obj;
    public bool side;
    // Start is called before the first frame update
    void Start()
    {
        minTimeBetweenSpawns = 1;
        maxTimeBetweenSpawns = 3;
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            if (side)
            {
                Instantiate(obj, new Vector3(transform.position.x, Random.Range(-3f, 3f), transform.position.z), transform.rotation);
            }
            else
            {
                Instantiate(obj, new Vector3(Random.Range(-9f, 9f), transform.position.y, transform.position.z), transform.rotation);
            }
        }
    }
}
