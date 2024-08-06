using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExamples : MonoBehaviour
{
    //public List<string> studentNames = new List<string>();

    public GameObject objectPrefab;

    public List<GameObject> objectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObj;
        tempObj = Instantiate(objectPrefab, transform);
        tempObj.transform.position = new Vector2(0,0);
        objectList.Add(tempObj);

        GameObject tempObj1;
        tempObj1 = Instantiate(objectPrefab, transform);
        tempObj1.transform.position = new Vector2(1, 0);
        objectList.Add(tempObj1);

        GameObject tempObj2;
        tempObj2 = Instantiate(objectPrefab, transform);
        tempObj2.transform.position = new Vector2(2, 0);
        objectList.Add(tempObj2);
    }

    // Update is called once per frame
    void Update()
    {
        //Assign a random colour to a random objects
        if (Input.GetKeyDown(KeyCode.R))
        {
            objectList[Random.Range(0, objectList.Count)].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

        //Remove an object at index 1
        if (Input.GetKeyDown(KeyCode.X))
        {
            Destroy(objectList[1].gameObject);
            objectList.RemoveAt(1);
        }
    }
}
