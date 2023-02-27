using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float rot;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.transform.rotation = Quaternion.Euler(0f, 0f, rot + Random.Range(-range, range));
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("move");
        this.rigidbody.AddForce(this.transform.up * 5);
    }


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("BarrierUp"))
    //    {
    //        this.rigidbody.velocity = new Vector3(0f, -2f, 0f);
            
    //    }
    //    if (collision.gameObject.CompareTag("BarrierDown"))
    //    {
    //        this.rigidbody.velocity = new Vector3(0f, 2f, 0f);
            
    //    }
    //    if (collision.gameObject.CompareTag("BarrierLeft"))
    //    {
    //        this.rigidbody.velocity = new Vector3(2f, 0f, 0f);
            
    //    }
    //    if (collision.gameObject.CompareTag("BarrierRight"))
    //    {
    //        this.rigidbody.velocity = new Vector3(-2f, 0f, 0f);
            
    //    }
    //}
}
