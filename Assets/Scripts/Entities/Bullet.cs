using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;

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
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        if(damageable != null)
        {
            damageable.GetDamage(damage);
            Debug.Log($"Damage Something");

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(targetTag))
            return;

        Debug.Log(other.gameObject.name);

        IDamageable damageable = other.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
