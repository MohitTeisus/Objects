using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShipIcon : MonoBehaviour
{
    [SerializeField] private RectTransform ship;
    [SerializeField] private float pulseSpeed, pulseDistance, pulseOffset, spinSpeed;

    // Update is called once per frame
    void Update()
    {
        float pulse = Mathf.Sin(Time.time * pulseSpeed) * pulseDistance + pulseOffset;
        Vector3 pulseScale = new Vector3(pulse, pulse, pulse);
        ship.localScale = pulseScale;

        Vector3 rotation = new Vector3();
        rotation.z = spinSpeed * Time.deltaTime;
        ship.Rotate(rotation);
    }
}
