using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    public Transform target;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        try
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        catch (NullReferenceException)
        {
           
        }
        catch (MissingReferenceException)
        {

        }

        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;
            targetPosition.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
        }
        //Vector3 targetPosition = target.position + offset;
        //targetPosition.z = transform.position.z;

        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}
