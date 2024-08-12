using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBossEnemy : Enemy
{
    [SerializeField] private float shootRange, fireRate;
    [SerializeField] private GameObject explodingEnemy;

    private Weapon explodingWeapon = new Weapon("Exploder", 20f, 0f);

    private float timer = 0;
    private float setSpeed = 0;

    public void SetMachineGunEnemy(float _shootRange, float _fireRate)
    {
        fireRate = _fireRate;
        shootRange = _shootRange;
    }

    protected override void Start()
    {
        base.Start();
        health = new Health(10, 0, 10);
        setSpeed = speed;
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
            return;

        if (Vector2.Distance(transform.position, target.position) < shootRange)
        {
            speed = 0;
            timer += Time.deltaTime;
            if (timer >= 1 / fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
        else
        {
            speed = setSpeed;
        }
    }

    public override void Shoot()
    {
        //Spawns exploding enemies
        explodingEnemy = Instantiate(explodingEnemy);
        explodingEnemy.transform.position = this.transform.position;
        //Gives weapon
        explodingEnemy.GetComponent<Enemy>().weapon = explodingWeapon;
        explodingEnemy.GetComponent<ExplodingEnemy>().SetExplodingEnemy(1.5f, 3, 0.75f);
    }
}
