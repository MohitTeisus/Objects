using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblityPickup : Pickup
{
    [SerializeField] private float duration = 10f;

    public override void OnPicked()
    {
        base.OnPicked();
        var player = GameManager.GetInstance().GetPlayer();
        player.Invicibility(duration);
        player.GetComponent<CooldownDisplay>().CooldownUI(duration, 2);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        OnPicked();

    }
}
