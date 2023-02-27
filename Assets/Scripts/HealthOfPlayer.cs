using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthOfPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float health;
    [SerializeField] private float colDamage;
    [SerializeField] private float satHeal;

    public AudioSource pickup;
    public AudioSource explosion;

    public GameObject colObject;
    public Timer t;

    private float currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(currentHealth <= 0)
        {
            Debug.Log("player Is dead");
            float hold = t.GetTime();
            float h1 = PlayerPrefs.GetFloat("highScore1", 0);
            float h2 = PlayerPrefs.GetFloat("highScore2", 0);
            float h3 = PlayerPrefs.GetFloat("highScore3", 0);
            float h4 = PlayerPrefs.GetFloat("highScore4", 0);
            float h5 = PlayerPrefs.GetFloat("highScore5", 0);

            if (h1 < hold)
            {
                PlayerPrefs.SetFloat("highScore1", hold);
                hold = h1;
            }

            if (h2 < hold)
            {
                PlayerPrefs.SetFloat("highScore2", hold);
                hold = h2;
            }

            if (h3 < hold)
            {
                PlayerPrefs.SetFloat("highScore3", hold);
                hold = h3;
            }

            if (h4 < hold)
            {
                PlayerPrefs.SetFloat("highScore4", hold);
                hold = h4;
            }

            if (h5 < hold)
            {
                PlayerPrefs.SetFloat("highScore5", hold);
                hold = h5;
            }

            SceneManager.LoadScene("StartScene");
            hold = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            explosion.Play();
            currentHealth -= colDamage;
            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.CompareTag("Satellite"))
        {
            pickup.Play();
            currentHealth += satHeal;
            healthBar.SetHealth(currentHealth);
            colObject = collision.transform.gameObject;
            Destroy(colObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Satellite"))
        {
            pickup.Play();
            currentHealth += satHeal;
            healthBar.SetHealth(currentHealth);
            colObject = collision.transform.gameObject;
            Destroy(colObject);
        }
    }
}
