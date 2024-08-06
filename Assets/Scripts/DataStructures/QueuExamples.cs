using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuExamples : MonoBehaviour
{
    public GameObject objectPrefab;
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    GameObject tempObj;
    Vector2 lastEnqueuePosition = Vector2.zero; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //push object to top of the stack
        if (Input.GetKeyDown(KeyCode.Q))
        {
            tempObj = Instantiate(objectPrefab, transform);
            tempObj.transform.position = new Vector2(lastEnqueuePosition.x + 1, 0);

            tempObj.name = "STACKED-" + objQueue.Count;
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            objQueue.Enqueue(tempObj);
            lastEnqueuePosition = tempObj.transform.position;

            Debug.Log("Pushed " + tempObj.name);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var removedObj = objQueue.Dequeue();
            Destroy(removedObj);
            Debug.Log("Popped from the stack: " + removedObj.name);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"Object at the top is {objQueue.Peek().name}");
        }
    }
}
