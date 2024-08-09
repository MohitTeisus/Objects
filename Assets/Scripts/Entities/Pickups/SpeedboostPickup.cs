using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedboostPickup : Pickup
{
    [SerializeField] private float duration, speedMult;


    public override void OnPicked()
    {
        base.OnPicked();
        var player = GameManager.GetInstance().GetPlayer();
        player.SpeedboostTimer(duration);
        player.SetSpeedMult(speedMult);
        player.GetComponent<CooldownDisplay>().CooldownUI(duration, 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        OnPicked();

    }
}
