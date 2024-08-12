using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodingBossEnemy : Enemy
{
    [SerializeField] private float explodeStartRange;
    [SerializeField] private float explodeRange;
    [SerializeField] private float explodeDelay;

    [SerializeField] private Image explosionTimerUI;
    private float opacity;

    private Player player;

    private float timer = 0;
    private float setSpeed = 0;

    protected override void Start()
    {
        base.Start();
        target = GameObject.FindWithTag("Explode").transform;
        health = new Health(1, 0, 1);
        setSpeed = speed;

        player = GameObject.FindAnyObjectByType<Player>();
    }

    public void SetExplodingBossEnemy(float _explodeStartRange, float _attackRange, float _attackDelay)
    {
        explodeStartRange = _explodeStartRange;
        explodeRange = _attackRange;
        explodeDelay = _attackDelay;
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
            return;

        if (Vector2.Distance(transform.position, target.position) <= explodeStartRange)
        {
            speed = 0;
            timer += Time.deltaTime;
            ExplosionUIStart();
            if (timer >= explodeDelay)
            {
                Explode(explodeRange);
                Destroy(gameObject);
            }
        }
        else if ((Vector2.Distance(transform.position, target.position) > explodeStartRange))
        {
            timer = 0;
            speed = setSpeed;
            ExplosionUIReset();
        }
    }

    public override void Explode(float explosionRange)
    {
        if (Vector2.Distance(transform.position, target.position) < explosionRange)
        {
            player.GetComponent<IDamageable>().GetDamage(weapon.GetWeaponDamage());
        }
    }

    public void ExplosionUIReset()
    {
        explosionTimerUI.fillAmount = 0f;
        opacity = 0f;
    }

    private void ExplosionUIStart()
    {

        opacity = timer;
        explosionTimerUI.color = new Color(255f, 255f, 255f, opacity);
        explosionTimerUI.fillAmount += 1.0f / explodeDelay * Time.deltaTime;
    }
}
