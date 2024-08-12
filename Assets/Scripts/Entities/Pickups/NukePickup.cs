using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup : Pickup
{
    [SerializeField] private PickupManager pickupManager;
    private UIManager uiManager;

    public override void Start()
    {
        base.Start();
        pickupManager = FindObjectOfType<PickupManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public override void OnPicked()
    {
        base.OnPicked();

        pickupManager.nukesStored++;
        uiManager.UpdateNukeStorageUI(pickupManager.nukesStored);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || pickupManager.nukesStored == 3)
            return;

        OnPicked();

    }
}
