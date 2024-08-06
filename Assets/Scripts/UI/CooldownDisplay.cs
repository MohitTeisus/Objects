using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField] private Image cooldownIMG;
    private float cooldown;


    private void Start()
    {
        cooldownIMG.fillAmount = 0f; 
        cooldown = 0;
        
    }

    private void Update()
    {
        CooldownDecrease();
    }

    public void CooldownUI(float _cooldown)
    {
        cooldown = _cooldown;
        Debug.Log(cooldown);
        cooldownIMG.fillAmount = 1.0f;
    }

    private void CooldownDecrease()
    {
        cooldownIMG.fillAmount -= 1.0f / cooldown * Time.deltaTime;
    }
}
