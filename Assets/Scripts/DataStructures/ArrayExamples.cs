using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExamples : MonoBehaviour
{
    public int[] studentScores = new int[7];

    public GameObject objectPrefab;

    public GameObject[] objectArrays = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        objectArrays[0] = Instantiate(objectPrefab, transform);
        objectArrays[0].transform.position = new Vector2(0, 0);
        
        objectArrays[1] = Instantiate(objectPrefab, new Vector2(1, 0), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        //Assign a random colour to a random objects
        if (Input.GetKeyDown(KeyCode.R))
        {
            objectArrays[Random.Range(0, objectArrays.Length)].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

        //Destroy the gameobject
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(objectArrays[0].gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !objectArrays[0])
        {
            objectArrays[0] = Instantiate(objectPrefab, transform);
            objectArrays[0].transform.position = new Vector2(0, 0);
        }
    }
}
