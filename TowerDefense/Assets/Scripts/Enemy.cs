using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    private Transform target;
    private int wavepointIndex = 0;

	// Use this for initialization
	void Start () {
        target = WayPoints.points[0];
	}

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
	}

    void GetNextWayPoint()
    {
        if(wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStat.Lives--;
        Destroy(gameObject);
    }

    void Die()
    {
        PlayerStat.Money += value;
        Destroy(gameObject);
    }
}
