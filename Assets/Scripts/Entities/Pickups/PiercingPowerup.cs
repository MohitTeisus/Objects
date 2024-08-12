using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingPowerup : Pickup
{
    private Player player;
    [SerializeField] private float cooldown = 10;


    public override void OnPicked()
    {
        base.OnPicked();
        player = GameManager.GetInstance().GetPlayer();
        player.StartPiercingTimer(cooldown);
        player.GetComponent<CooldownDisplay>().CooldownUI(cooldown, 4);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        OnPicked();
    }
}
