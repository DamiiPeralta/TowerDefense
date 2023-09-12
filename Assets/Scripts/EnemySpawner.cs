using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 1f;

    [SerializeField] private float enemiesPerSecondCap = 15f;

    [SerializeField] public CenterTextChanged centerTextChanged;

    [SerializeField] private Button nextWaveButton;

    [SerializeField] private Button resetLevelBt;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;

    public int lastWave = 10;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    

    public GameObject[] enemiesGo;

    private float eps; // enemies Ped second

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
        StartCoroutine(ChangeText());
        nextWaveButton.onClick.AddListener(WaveStart);
        resetLevelBt.onClick.AddListener(ResetLevel);  
    }

    private void Update()
    {
        if(LevelManager.main.state == LevelManager.LevelState.Lose)
        {
            resetLevelBt.gameObject.SetActive(true);
            return;
        }
        enemiesGo = GameObject.FindGameObjectsWithTag("Enemie");
        enemiesAlive = enemiesGo.Length;
        
        if(!isSpawning) return;

        

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f/ eps) && enemiesLeftToSpawn > 0)
        {
            
            SpawnEnemy();
            enemiesLeftToSpawn--;
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        //enemiesAlive--;
    }

    public void WaveStart()
    {
        nextWaveButton.gameObject.SetActive(false);
        centerTextChanged.WaveNumberText(currentWave);
        centerTextChanged.gameObject.SetActive(true);
        StartCoroutine(ChangeText());
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();
    }

    private IEnumerator StartWave()
    {
        nextWaveButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(timeBetweenWaves);
        centerTextChanged.WaveNumberText(currentWave);
        centerTextChanged.gameObject.SetActive(true);
        StartCoroutine(ChangeText());
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();

    }
    private IEnumerator ChangeText()
    {
        yield return new WaitForSeconds(2);
        centerTextChanged.gameObject.SetActive(false);
    }

    private void ResetLevel()
    {
        for (int i = 0; i < enemiesGo.Length; i++)
        {
            Destroy(enemiesGo[i]);
        }
        
        isSpawning = false;
        currentWave = 1;
        enemiesLeftToSpawn = 0;
        WaveStart();
        resetLevelBt.gameObject.SetActive(false);
        centerTextChanged.gameObject.SetActive(false);
        LevelManager.main.ResetHearts();
        

    }

    private void EndWave()
    {
        
        if(currentWave <= lastWave)
        {
            isSpawning = false;
            timeSinceLastSpawn = 0f;
            currentWave++;
            centerTextChanged.gameObject.SetActive(true);
            centerTextChanged.WaveNumberText(currentWave);
            StartCoroutine(ChangeText());
            nextWaveButton.gameObject.SetActive(true);
            return;
        }
        centerTextChanged.EndLevelText();
        centerTextChanged.gameObject.SetActive(true);
        resetLevelBt.gameObject.SetActive(true);
        StartCoroutine(ChangeText());

    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f,
         enemiesPerSecondCap);
    }
}
