using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [HideInInspector]
    public float speed = 10f;
 
    public float startSpeed = 0;
    [HideInInspector]
    public float health;

    public float startHealth = 100;

    public int worth = 50;

    public Slider healthBar;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.value = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * pct;
    }

    void Die()
    {
        PlayerStat.Money += worth;
        WaveSpaner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
