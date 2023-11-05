using System.Collections;
using UnityEngine;
using TMPro;

public class WaveController : MonoBehaviour
{
    public static WaveController main;
    public EnemieWave[] enemieWave;
    public GameObject enemieSelected;
    public Mision mision;

    public float timeBtwWaves = 2f;
    public float timeBetweenSpawns = 0.2f;

    private int currentWaveIndex = 0;
    private int currentSpawnIndex = 0;
    public int aliveEnemies;
    private bool isSpawning = false;
    public int losedHearts = 0;

    private void Awake()
    {
        main = this;
        ResetAliveEnemies();
    }

    private void Update()
    {
        if (isSpawning)
        {
            timeBetweenSpawns -= Time.deltaTime;
            if (timeBetweenSpawns <= 0f)
            {
                SpawnEnemy();
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemie");
                aliveEnemies = enemies.Length;
                Debug.Log("Alive Enemies: " + aliveEnemies);

                currentSpawnIndex++;
                timeBetweenSpawns = 3f;
            }

            if (currentSpawnIndex >= enemieWave[currentWaveIndex].Stack)
            {
                currentWaveIndex++;
                if (currentWaveIndex < enemieWave.Length)
                {
                    StartWave(); // Llamar a StartWave para iniciar la siguiente oleada
                }
                else
                {
                    isSpawning = false;
                    Debug.Log("Final!");
                    WinMision();
                    LevelManager.main.state = LevelManager.LevelState.Win;
                    Restart();
                }
            }
        }
    }

    public void ResetAliveEnemies()
    {
        aliveEnemies = 0;
        for (int i = 0; i < enemieWave.Length; i++)
        {
            aliveEnemies += enemieWave[i].Stack; // Suma la cantidad de enemigos en la oleada actual al total
        }
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemieSelected;
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        aliveEnemies--; // Reduce la cantidad de enemigos vivos
    }

    public void StartWave()
    {
        LevelManager.main.state = LevelManager.LevelState.Playing;
        Debug.Log("Empezó la oleada " + currentWaveIndex);
        currentSpawnIndex = 0;
        enemieSelected = enemieWave[currentWaveIndex].Enemie;
        isSpawning = true;
    }

    public void Restart()
    {
        timeBtwWaves = 2f;
        timeBetweenSpawns = 0.2f;
        currentWaveIndex = 0;
        currentSpawnIndex = 0;
        losedHearts = 0;
        isSpawning = false;
        LevelManager.main.ResetHearts();
        mision = null;
    }

    public void WinMision()
    {
        int rewardCoins = 3;
        if (losedHearts > 1)
        {
            rewardCoins--;
        }
        if (losedHearts > 5)
        {
            rewardCoins--;
        }

        mision.rewardCoins = rewardCoins;
        mision.win = true;
        Restart();
    }
}
