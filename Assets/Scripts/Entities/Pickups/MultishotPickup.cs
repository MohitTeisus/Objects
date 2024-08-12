using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MultishotPickup : Pickup
{
    private Player player;
    [SerializeField] private float cooldown = 10;


    public override void OnPicked()
    {
        base.OnPicked();
        player = GameManager.GetInstance().GetPlayer();
        player.StartMultishotTimer(cooldown);
        player.GetComponent<CooldownDisplay>().CooldownUI(cooldown, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        OnPicked();
    }
}
