using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField] private Image mgCooldownIMG;
    [SerializeField] private Image msCooldownIMG;
    [SerializeField] private Image invincibilityCooldownIMG;
    [SerializeField] private Image speedboostCooldownIMG;
    [SerializeField] private Image piercingCooldownIMG;

    private float mgCooldown;
    private float msCooldown;
    private float invincibilityCooldown;
    private float speedboostCooldown;
    private float piercingCooldown;

    private void Start()
    {
        ResetCooldownImages();
    }

    public void ResetCooldownImages()
    {
        mgCooldownIMG.fillAmount = 0f;
        msCooldownIMG.fillAmount = 0f;
        invincibilityCooldownIMG.fillAmount = 0f;
        speedboostCooldownIMG.fillAmount = 0f;
        piercingCooldownIMG.fillAmount = 0f;

        mgCooldown = 0;
        msCooldown = 0;
        invincibilityCooldown = 0;
        speedboostCooldown = 0;
        piercingCooldown = 0;
    }

    private void Update()
    {
        CooldownDecrease();
    }

    public void CooldownUI(float _cooldown, int index)
    {
            switch (index)
        {
            case 0:
                mgCooldown = _cooldown;
                mgCooldownIMG.fillAmount = 1.0f;
                break;
            case 1:
                msCooldown = _cooldown;
                msCooldownIMG.fillAmount = 1.0f;
                break;
            case 2:
                invincibilityCooldown = _cooldown;
                invincibilityCooldownIMG.fillAmount = 1.0f; 
                break;
            case 3:
                speedboostCooldown = _cooldown;
                speedboostCooldownIMG.fillAmount = 1.0f;
                break;
            case 4:
                piercingCooldown = _cooldown;
                piercingCooldownIMG.fillAmount = 1.0f;
                break;
        }
    }

    private void CooldownDecrease()
    {
        if (Time.timeScale == 0 || Time.deltaTime == 0)
            return;

        mgCooldownIMG.fillAmount -= 1.0f / mgCooldown * Time.deltaTime;
        msCooldownIMG.fillAmount -= 1.0f / msCooldown * Time.deltaTime;
        invincibilityCooldownIMG.fillAmount -= 1.0f / invincibilityCooldown * Time.deltaTime;
        speedboostCooldownIMG.fillAmount -= 1.0f / speedboostCooldown * Time.deltaTime;
        piercingCooldownIMG.fillAmount -= 1.0f / piercingCooldown * Time.deltaTime;
    }
}
