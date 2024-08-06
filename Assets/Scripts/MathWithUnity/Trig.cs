using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{


    public Transform obj;

    [Header("Trig")]
    public Vector2 startpos;
    public Vector2 amplitude;
    public Vector2 frequency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sine();
        Ellipse();
    }

    void Sine()
    {
        float xPos = startpos.x + Time.timeSinceLevelLoad;
        float yPos = startpos.y + amplitude.y * Mathf.Sin(frequency.y * Time.timeSinceLevelLoad);

        obj.position = new Vector2(xPos, yPos);
    }

    void Ellipse()
    {
        float xPos = startpos.x + amplitude.x * Mathf.Sin(frequency.x * Time.timeSinceLevelLoad);
        float yPos = startpos.y + amplitude.y * Mathf.Cos(frequency.y * Time.timeSinceLevelLoad);

        obj.position = new Vector2(xPos, yPos);

        //Pause
        //Time.timeScale = 0;
        //Time.timeScale = 1
    }

}
