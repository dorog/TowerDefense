using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpaner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    public Text waveCount;
    private float countdown = 2f;

    private int waveNumber = 0;

    public Transform spawnPoint;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(EnemiesAlive > 0)
        {
            return;
        }

		if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
	}

    IEnumerator SpawnWave()
    {
        PlayerStat.Rounds++;

        Wave wave = waves[waveNumber];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveCount.text = "Wave: " + waveNumber;
        waveNumber++;

        if(waveNumber == waves.Length)
        {
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
