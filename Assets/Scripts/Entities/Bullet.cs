using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;


    [SerializeField] private bool isPiercing = false;
    private float entitiesPierced;

    private string targetTag;

    public void SetBullet(float _damage, float _speed, string _targetTag)
    {
        damage = _damage;
        moveSpeed = _speed;
        targetTag = _targetTag; 
    }

    private void Update()
    {
        Move();
    }


    void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.right);
    }

    void Damage(IDamageable damageable)
    {
        if (damageable != null && isPiercing)
        {
            damageable.GetDamage(damage);
            entitiesPierced++;
            if (entitiesPierced >= 3)
                Destroy(gameObject);
        }
        else if(damageable != null)
        {
            damageable.GetDamage(damage);
            Debug.Log($"Damage Something");

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the bullet hits an obstacle, the bullet will be destroyed
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            return;
        }
        else if (!other.gameObject.CompareTag(targetTag))
            return;

        Debug.Log(other.gameObject.name);

        IDamageable damageable = other.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
