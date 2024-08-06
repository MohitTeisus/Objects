using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectData : MonoBehaviour
{
    [SerializeField] ScriptableObjectExample example; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"File name = {example.objectName}, score = {example.score}, Start position at {example.startPos} ...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
