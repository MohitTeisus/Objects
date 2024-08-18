using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private PickupSpawn[] pickups;

    [Range(0, 1)]
    [SerializeField] private float pickupProbability, defaultPickupProbability, maxPickupProbability;

    List<Pickup> pickupPool = new List<Pickup>();
    Pickup chosenPickup;

    [Range(0, 3)]
    public int nukesStored = 0;

    private void Start()
    {
        ResetPickUpProbability();

        //populate pool of pickup with pickups
        foreach (PickupSpawn spawn in pickups)
        {
            for (int i = 0; i < spawn.spawnWeight; i++)
            {
                pickupPool.Add(spawn.pickup);
            } 
        }
    }
    /// <summary>
    /// Spawns pickup
    /// </summary>
    /// <param name="position">spawn point</param>
    public void SpawnPickup(Vector2 position)
    {
        if (pickupPool.Count < 0)
            return;

        if(Random.Range(0.0f, 1.0f) < pickupProbability)
        {
            chosenPickup = pickupPool[Random.Range(0, pickupPool.Count)];
            Instantiate(chosenPickup, position, Quaternion.identity);
        }
    }

    public void IncreasePickUpSpawns(float increase)
    {
        pickupProbability += increase;
        if (pickupProbability > maxPickupProbability)
            pickupProbability = maxPickupProbability;
    }

    public void ResetPickUpProbability()
    {
        pickupProbability = defaultPickupProbability;
    }
}

[System.Serializable]
public struct PickupSpawn
{
    public Pickup pickup;
    public int spawnWeight;
}