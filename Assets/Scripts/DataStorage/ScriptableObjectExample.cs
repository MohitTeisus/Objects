using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Scriptable Data", menuName = "CircuitStream/Create new Object", order = 1)]
public class ScriptableObjectExample : ScriptableObject
{
    public string objectName;
    public int score;
    public Vector2 startPos;
}
