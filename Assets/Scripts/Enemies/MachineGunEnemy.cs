using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] private float shootRange, fireRate;
    [SerializeField] private Bullet bulletPrefab;
    
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
        health = new Health(1, 0, 1);
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
        weapon.Shoot(bulletPrefab, this, "Player", 6f);
    }
}
