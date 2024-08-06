using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virtual : VirtualTEst
{
    void Start()
    {
        Test();
        Test2();
    }

    public override void Test()
    {
        base.Test();
    }

    public override void Test2()
    {
        Debug.Log("override test2");
    }
}
