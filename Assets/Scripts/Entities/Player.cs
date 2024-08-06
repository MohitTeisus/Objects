using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private string nickName;
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPrefab;
    private GameManager gameManager;

    private float timer;
    private float firerate;

    private float machineGunTimer;
    public bool machineGunEnabled;
    private float machineGunFireRate = 8;
    private float machineGunFireTimer;

    private Rigidbody2D playerRB;

    public Action onDeath;

    private void Awake()
    {
        health = new Health(100, 0.5f, 50);
        playerRB = GetComponent<Rigidbody2D>();
        gameManager = GameManager.GetInstance();

        //Give the player the weapon
        weapon = new Weapon("playerWeapon", weaponDamage, bulletSpeed);

        //OnHealthUpdate?.Invoke(health.GetHealth());

        cam = Camera.main;
    }

    /// <summary>
    /// moving the player in a direction towards a target
    /// </summary>
    /// <param name="direction">the direction of the movement</param>
    /// <param name="target">target is the mouse movement</param>
    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRB.velocity = direction * speed * Time.deltaTime;

        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2 (target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void Update()
    {
        health.RegenHealth();

        StartMachineGunTimer(machineGunTimer);
    }

    public void StartMachineGunTimer(float timer)
    {
        machineGunTimer = timer;

       
        if (machineGunTimer >= 0)
        {
            machineGunEnabled = true;
            machineGunTimer -= Time.deltaTime;
        }
        else if (machineGunTimer < 0)
        {
            machineGunEnabled = false;
        }
    }

    public void MachineGunShoot()
    {
        if (machineGunEnabled)
        {
            machineGunFireTimer += Time.deltaTime;
            if (machineGunFireTimer >= 1 / machineGunFireRate)
            {
                weapon.Shoot(bulletPrefab, this, "Enemy", 3f);
                machineGunFireTimer = 0;
            }
        }
    }
    public void Nuke()
    {
        if (gameManager.pickUpManager.nukesStored >= 1)
        {
            gameManager.pickUpManager.nukesStored--;
            foreach (Enemy item in FindObjectsOfType(typeof(Enemy)))
            {
                Destroy(item.gameObject);
            }
            gameManager.uiManager.UpdateNukeStorageUI(gameManager.pickUpManager.nukesStored);
        }
            
    }

    /// <summary>
    /// Responsible for making the player shoot
    /// </summary>
    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Enemy", 3f);
    }

    public override void Die()
    {
        Debug.Log("Player died");
        onDeath?.Invoke();

        Destroy(gameObject);
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Player damaged = " + damage); 
        health.DeductHealth(damage);

        //update health value form c# action
        //OnHealthUpdate?.Invoke(health.GetHealth());

        if (health.GetHealth() <= 0)
            Die();
    }

    public override void Attack(float interval)
    {

    }

    public override void Explode(float explosionRange)
    {

    }

}
