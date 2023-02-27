using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public GameObject bulletPrefab;
    public GameObject thruster;
    public GameObject thruster2;
    public GameObject thruster3;
    public GameObject fire;

    GameObject holdObj;
    GameObject holdObj2;
    GameObject holdObj3;

    public AudioSource th;

    public float thrustSpeed = 1.0f;
    public bool thrusting { get; private set; }

    public float turnDirection { get; private set; } = 0.0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3.0f;
    public float respawnInvulnerability = 3.0f;

    bool thrustUnderway = false;
    bool underBoost = false;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!thrustUnderway)
            {
                holdObj = Instantiate(fire, (thruster.transform.position + new Vector3(0f,0f,1f)), (thruster.transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, 180f))));
                holdObj.transform.parent = thruster.transform;
                th.loop = true;
                th.Play();
                thrustUnderway = true;
            }
        }
        else if(thrustUnderway)
        {
            Debug.Log("destroy");
            Destroy(holdObj.gameObject);
            thrustUnderway = false;
            th.Stop();
        }
        
            
       

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.turnDirection = -1.0f;
        } else {
            this.turnDirection = 0.0f;
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            thrustSpeed = 4.0f;

            if (!underBoost && thrustUnderway)
            {
                holdObj2 = Instantiate(fire, (thruster2.transform.position + new Vector3(0f, 0f, 1f)), (thruster2.transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, -225f))));
                holdObj2.transform.parent = thruster2.transform;

                holdObj3 = Instantiate(fire, (thruster3.transform.position + new Vector3(0f, 0f, 1f)), (thruster3.transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, 225f))));
                holdObj3.transform.parent = thruster3.transform;
                underBoost = true;
            }
        }
        else
        {
            thrustSpeed = 1.0f;

            if(underBoost)
            {
                Destroy(holdObj2.gameObject);
                Destroy(holdObj3.gameObject);
                underBoost = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (this.thrusting) {
            this.rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if (this.turnDirection != 0.0f) {
            this.rigidbody.AddTorque(this.rotationSpeed * this.turnDirection);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BarrierUp"))
        {
            this.rigidbody.velocity = new Vector3(0f,-2f,0f);
        }
        if (collision.gameObject.CompareTag("BarrierDown"))
        {
            this.rigidbody.velocity = new Vector3(0f, 2f, 0f);
        }
        if (collision.gameObject.CompareTag("BarrierLeft"))
        {
            this.rigidbody.velocity = new Vector3(2f, 0f, 0f);
        }
        if (collision.gameObject.CompareTag("BarrierRight"))
        {
            this.rigidbody.velocity = new Vector3(-2f, 0f, 0f);
        }
    }



}
