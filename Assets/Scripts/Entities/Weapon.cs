using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Weapon 
{
    private string weaponName;
    private float damage;
    private float bulletSpeed;
    private float projectileSpread;

    public Weapon(string _name, float _damage, float _bulletSpeed)
    {
        weaponName = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }

    public Weapon()
    {

    }

    public void Shoot(Bullet _bullet, PlayableObject _shooter, string _targetTag, float timeToDie)
    {

        Bullet tempBullet = GameObject.Instantiate(_bullet, _shooter.transform.position, _shooter.transform.rotation);
        tempBullet.SetBullet(damage, bulletSpeed, _targetTag);

        GameObject.Destroy(tempBullet.gameObject, timeToDie);
    }

    public void ShootMultiple(Bullet _bullet, PlayableObject _shooter, string _targetTag, float timeToDie)
    {
        Vector3 rotation = new Vector3(0, 0, 30);
        Vector3 rotation2 = new Vector3(0, 0, -30);
    
        Bullet tempBullet = GameObject.Instantiate(_bullet, _shooter.transform.position, _shooter.transform.rotation);
        Bullet tempBullet2 = GameObject.Instantiate(_bullet, _shooter.transform.position, _shooter.transform.rotation);
        Bullet tempBullet3 = GameObject.Instantiate(_bullet, _shooter.transform.position, _shooter.transform.rotation);

        tempBullet.SetBullet(damage, bulletSpeed, _targetTag);
        tempBullet2.SetBullet(damage, bulletSpeed, _targetTag);
        tempBullet3.SetBullet(damage, bulletSpeed, _targetTag);

        tempBullet2.transform.Rotate(rotation);
        tempBullet3.transform.Rotate(rotation2);

        GameObject.Destroy(tempBullet.gameObject, timeToDie);
    }
    public float GetWeaponDamage()
    {
        return damage;
    }
}
