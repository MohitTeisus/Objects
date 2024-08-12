using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public SoundManager soundManager;

    public virtual void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private float timer = 15;

    public virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnPicked()
    {
        soundManager.PlaySound("power-up");
        Destroy(gameObject);
    }
}
