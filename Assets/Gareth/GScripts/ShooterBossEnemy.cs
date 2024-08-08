using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBossEnemy : Enemy
{
    [SerializeField] private float shootRange, fireRate;
    [SerializeField] private Bullet bulletPrefab;
    private LineRenderer lineRenderer;

    private float timer = 0;
    private float setSpeed = 0;

    public void SetShooterEnemy(float _shootRange, float _fireRate)
    {
        fireRate = _fireRate;
        shootRange = _shootRange;
    }

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        setSpeed = speed;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
            return;

        lineRenderer.SetPosition(0, gameObject.transform.position);
        lineRenderer.SetPosition(1, target.position);

        if (Vector2.Distance(transform.position, target.position) < shootRange)
        {
            lineRenderer.enabled = true;
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
            lineRenderer.enabled = false;
        }
    }

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Player", 3f);
    }
}
