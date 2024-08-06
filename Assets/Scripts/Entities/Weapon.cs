using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    private string weaponName;
    private float damage;
    private float bulletSpeed;

    public Weapon(string _name, float _damage, float _bulletSpeed)
    {
        weaponName = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }

    public Weapon()
    {

    }

    public void Shoot(Bullet _bullet, PlayableObject _player, string _targetTag, float timeToDie)
    { 
        Bullet tempBullet = GameObject.Instantiate(_bullet, _player.transform.position, _player.transform.rotation);
        tempBullet.SetBullet(damage, bulletSpeed, _targetTag);

        GameObject.Destroy(tempBullet.gameObject, timeToDie);
    }

    public float GetWeaponDamage()
    {
        return damage;
    }
}
