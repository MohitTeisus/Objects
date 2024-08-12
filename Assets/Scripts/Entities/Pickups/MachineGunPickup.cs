using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunPickup : Pickup
{
    private Player player;
    [SerializeField] private float cooldown = 10;

 

    public override void OnPicked()
    {
        base.OnPicked();
        player = GameManager.GetInstance().GetPlayer();
        player.StartMachineGunTimer(cooldown);
        player.GetComponent<CooldownDisplay>().CooldownUI(cooldown, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        OnPicked();
    }
}
