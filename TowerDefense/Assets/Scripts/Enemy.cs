using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [HideInInspector]
    public float speed = 10f;
 
    public float startSpeed = 0;

    public float health = 100;

    public int worth = 50;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
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
        Destroy(gameObject);
    }
}
