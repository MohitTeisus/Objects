using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : PlayableObject
{
    [SerializeField] protected float speed;
    protected Transform target;

    private EnemyType enemyType;
    Rigidbody2D rb;

    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        try
        {
            target = GameObject.FindWithTag("Player").transform;
        } catch(NullReferenceException e)
        {
            Debug.Log("There is no player in the scene, enemy self destroying" + e);
            GameManager.GetInstance().SetEnemySpawnStatus(false);
        }
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot()
    {
        
    }

    public override void Attack(float interval)
    {
       

    }

    public override void Explode(float explosionRange)
    {
        
    }

    public override void Die()
    {
        
        GameManager.GetInstance().NotifyDeath(this);
        GameManager.GetInstance().scoreManager.IncrementScore();
        Destroy(gameObject);
    }
    
    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("enemy damaged");
        health.DeductHealth(damage);
        if (health.GetHealth() <= 0)
            Die();
    }
}
