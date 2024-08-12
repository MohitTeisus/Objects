using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] Obstacle obstacle;
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = obstacle.rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
