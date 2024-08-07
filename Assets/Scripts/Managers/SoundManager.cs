using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource playerSFX, powerUpSFX, uiSFX;

    [SerializeField] private AudioClip damaged, powerUp, shoot;

    public void PlaySound(string soundClip)
    {
        switch (soundClip)
        {
            case "damaged":
                playerSFX.PlayOneShot(damaged);
                break;
            case "shoot":
                playerSFX.PlayOneShot(shoot);
                break;
            case "power-up":
                powerUpSFX.PlayOneShot(powerUp);
                break;
        }
    }
}
