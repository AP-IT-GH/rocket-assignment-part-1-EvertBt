using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 100;
    public float damageMultiplier = 1;
    public float invincibilityPeriod = 1;
    public string respawnScene;

    private Text healthText;
    private float timer;
    private bool isDamaged = false;
    private bool isInvincible = false;
    public static float Health = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(respawnScene == "")
        {
            respawnScene = "Level_1";
        }
        healthText = GameObject.Find("Health").GetComponent<Text>();
        timer = invincibilityPeriod;
        if (Health == 0)
        {
            Health = health;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged)
        {
            if (timer > 0)
            {
                isInvincible = true;
                timer -= Time.deltaTime;
            }
            else
            {
                isDamaged = false;
                isInvincible = false;
                timer = invincibilityPeriod;
            }
        }

        if (Health <= 0)
        {
            Health = health;
            SceneManager.LoadScene(respawnScene);            
        }
        else
        {
            healthText.text = ((int)Health).ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid" && !isInvincible && GameManager.state == GameManager.GameState.Playing)
        {
            if (collision.relativeVelocity.magnitude > 10)
            {
                isDamaged = true;
                Health -= damageMultiplier * collision.relativeVelocity.magnitude;
            }   
        }
    }

    public static void Damage(int damage)
    {
        if (GameManager.state == GameManager.GameState.Playing) 
            Health -= damage;
    }
}
