using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    private Player player;
    private float horizontal, vertical;
    private Vector2 lookTarget;

    

    private void Start()
    {
        player = GetComponent<Player>();
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void Update()
    {
        if (!GameManager.GetInstance().IsPlaying())
            return;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.GetInstance().PauseGame();
        }


        if (GameManager.isPaused)
            return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        lookTarget = Input.mousePosition;

        if(Input.GetMouseButton(0) && player.machineGunEnabled)
        {
            player.MachineGunShoot();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            soundManager.PlaySound("shoot");
            player.Shoot();
        }

        if(Input.GetMouseButtonDown(1))
        {
            soundManager.PlaySound("nuke");
            player.Nuke();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2 (horizontal, vertical), lookTarget);
    }
}
