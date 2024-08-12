using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Transform lockedTarget;

    public void SetObstacleTarget(Transform target)
    {
        lockedTarget = target;
    }

    public void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        transform.Translate(lockedTarget.position * speed * Time.deltaTime);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move(lockedTarget.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("ObstacleBorder"))
            Destroy(gameObject);
    }
}
