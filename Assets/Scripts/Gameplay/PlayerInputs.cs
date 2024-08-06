using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Player player;
    private float horizontal, vertical;
    private Vector2 lookTarget;
    

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!GameManager.GetInstance().IsPlaying())
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
            player.Shoot();
        }

        if(Input.GetMouseButtonDown(1))
        {
            player.Nuke();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2 (horizontal, vertical), lookTarget);
    }
}
