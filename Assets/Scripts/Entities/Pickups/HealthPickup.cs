using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] private float healthMin, healthMax;

   
    public override void OnPicked()
    {
        base.OnPicked();

        float health = Random.Range(healthMin, healthMax);
        var player = GameManager.GetInstance().GetPlayer();
        player.health.AddHealth(health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        
        OnPicked();
        
    }
}
