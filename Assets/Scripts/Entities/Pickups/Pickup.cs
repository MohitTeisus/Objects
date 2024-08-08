using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public SoundManager soundManager;

    public virtual void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    public virtual void OnPicked()
    {
        soundManager.PlaySound("power-up");
        Destroy(gameObject);
    }
}
