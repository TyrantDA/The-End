using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject earth;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = earth.transform;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(earth.transform.position, Vector3.forward, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
     }
}
