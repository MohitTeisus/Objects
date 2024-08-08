using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBossEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime;

    private float timer = 0;
    private float setSpeed = 0;

    protected override void Start()
    {
        base.Start();
        health = new Health(2, 0, 2);
        setSpeed = speed;
    }

    public void SetMeleeEnemy(float _attackRange, float _attackTime)
    {
        attackRange = _attackRange;
        attackTime = _attackTime;
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
            return;

        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Attack(attackTime);
            speed = 0;
        }
        else
        {
            speed = setSpeed;
        }
    }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;

            target.GetComponent<IDamageable>().GetDamage(weapon.GetWeaponDamage());
            Debug.Log($"Damage dealt = {weapon.GetWeaponDamage()}");
        }
    }
}
