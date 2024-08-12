using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [Header("Game Attributes")]
    [SerializeField] private GameObject[] bossEnemyPrefab;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] obstaclePrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private Transform[] obstacleSpawnPositions;
    [SerializeField] private Transform[] obstacleTargets;
    [SerializeField] private float enemySpawnRate;
    [SerializeField] private GameObject playerPrefab;
    

    [Header("Managers")]
    public ScoreManager scoreManager;
    public PickupManager pickUpManager;
    public UIManager uiManager;

    public Action OnGameStart;
    public Action OnGameOver;

    private GameObject tempBossEnemy;
    private GameObject tempEnemy;
    private GameObject tempObstacle;
    public bool isEnemySpawning;
    public bool isObstacleSpawning;
    private int enemiesSpawned;

    private Weapon meleeWeapon = new Weapon("Melee", 1f , 0f);
    private Weapon explodingWeapon = new Weapon("Exploder", 20f, 0f);
    private Weapon machineGunWeapon = new Weapon("MachineGun", 1.5f, 3f);
    private Weapon shooterWeapon = new Weapon("Shooter", 5f, 14f);



    private Player player;
    private bool isPlaying = false;

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        
        instance = this;
    }

    void Update()
    {
       
    }
    
    /// <summary>
    /// Spawns enemies
    /// </summary>
    void CreateEnemy()
    {
        //Choose which enemy to spawn
        int index = UnityEngine.Random.Range(0, enemyPrefab.Length);
        tempEnemy = Instantiate(enemyPrefab[index]);
        tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
        
        //Sets Enemy values
        switch (index)
        {
            case 0:
                tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
                tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);
                break;
            case 1:
                tempEnemy.GetComponent<Enemy>().weapon = explodingWeapon;
                tempEnemy.GetComponent<ExplodingEnemy>().SetExplodingEnemy(1.5f, 3, 0.75f);
                break;
            case 2:
                tempEnemy.GetComponent<Enemy>().weapon = machineGunWeapon;
                tempEnemy.GetComponent<MachineGunEnemy>().SetMachineGunEnemy(5, 2);
                break;
            case 3:
                tempEnemy.GetComponent<Enemy>().weapon = shooterWeapon;
                tempEnemy.GetComponent<ShooterEnemy>().SetShooterEnemy(9, .5f);
                break;
        }

        enemiesSpawned++;

        //Increases Rate that enemies spawn after a number of enemies have been spawned

        int increaseThreshold = 50;
        if (enemiesSpawned == increaseThreshold) 
        {
            enemySpawnRate++;
            enemiesSpawned = 0;
            increaseThreshold += 50;
        }
    }

    void CreateObstacle()
    {
        if (FindObjectsOfType(typeof(Obstacle)).Length >= 2)
            return;

        int index = UnityEngine.Random.Range(0, obstaclePrefab.Length);
        tempObstacle = Instantiate(obstaclePrefab[index]);
        // Set Spawn
        int spawnPoint = UnityEngine.Random.Range(0, obstacleSpawnPositions.Length);
        tempObstacle.transform.position = obstacleSpawnPositions[spawnPoint].position;
        // Set the target (The formula selects the opposite direction and picks a spawn from the available points)
        int target = ((spawnPoint * 3) + 6) % obstacleTargets.Length;
        Debug.Log(target);
        target += UnityEngine.Random.Range(0, 3);
        tempObstacle.GetComponent<Obstacle>().SetObstacleTarget(obstacleTargets[target]);
    }

    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds (1 / enemySpawnRate); 
            CreateEnemy();
        }
    }
    IEnumerator ObstacleSpawner()
    {
        while (isObstacleSpawning)
        {
            yield return new WaitForSeconds (1); 
            CreateObstacle();
        }
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickUpManager.SpawnPickup(enemy.transform.position);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity).GetComponent<Player>();

        enemySpawnRate = 1;

        player.onDeath += StopGame;
        isPlaying = true;

        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2.0f);
        isEnemySpawning = true;
        isObstacleSpawning = true;
        enemiesSpawned = 0;
        pickUpManager.nukesStored = 0;
        StartCoroutine(EnemySpawner());
        StartCoroutine(ObstacleSpawner());
    }

    public void StopGame()
    {
        scoreManager.SetHighScore();

        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        SetEnemySpawnStatus(false);
        SetObstacleSpawnStatus(false);
        yield return new WaitForSeconds(2.0f);
        isPlaying = false;

        //Delete All Enemies
        foreach (Enemy item in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(item.gameObject);
        }

        //Search for and Delete Pickups
        foreach(Pickup item in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(item.gameObject);
        }

        // Destroy leftover obstacles
        foreach (Obstacle item in FindObjectsOfType(typeof(Obstacle)))
        {
            Destroy(item.gameObject);
        }

        OnGameOver?.Invoke();
    }

    public void SetEnemySpawnStatus(bool SetEnemySpawn)
    {
        isEnemySpawning = SetEnemySpawn;
    }
    
    public void SetObstacleSpawnStatus(bool SetObstacleSpawn)
    {
        isObstacleSpawning = SetObstacleSpawn;
    }
}
