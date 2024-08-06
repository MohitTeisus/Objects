using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DictionaryExample : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTriangle, txtSquare, txtCircle;

    public Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public string checkForKey = "Rectangles";


    // Start is called before the first frame update
    void Start()
    {
        dictionary.Add("Triangles", 0);
        dictionary.Add("Squares", 0);
        dictionary.Add("Circles", 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Updating Number of Triangles
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (dictionary.ContainsKey("Triangles"))
            {
                dictionary["Triangles"]++;
                txtTriangle.text = dictionary["Triangles"].ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (dictionary.ContainsKey("Squares"))
            {
                dictionary["Squares"]++;
                txtSquare.text = dictionary["Squares"].ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (dictionary.ContainsKey("Circles"))
            {
                dictionary["Circles"]++;
                txtCircle.text = dictionary["Circles"].ToString();
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            int val = 0;
            bool hasKey = dictionary.TryGetValue(checkForKey, out val);
            Debug.Log(checkForKey + " = " + hasKey + " - " + val);
        }
    }
}
