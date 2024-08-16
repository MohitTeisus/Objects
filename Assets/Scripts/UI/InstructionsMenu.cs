using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject bottomRung;
    [SerializeField] private Image sheet;
    [SerializeField] private GameObject endPoint, startPoint;   
    private float speed = 1;
    private float fillAmountSpeed = 1f;
    private bool isOpen;

    private float time;
    private Vector3 startPos;
    private Vector3 endPos;


    void Start()
    {
        time = 1.1f;
        startPos = startPoint.transform.position;
        endPos = endPoint.transform.position;
        sheet.fillAmount = 0;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenInstructions();
    }

    public void StartOpenInstructions()
    {
        if (time > 1)
        {
            isOpen = !isOpen;
            time = 0;
            startPos = startPoint.transform.position;
            endPos = endPoint.transform.position;
        }
    }

    public void OpenInstructions()
    {
        if (time <= 1)
        {
            time += Time.deltaTime * speed;

            if (isOpen == true)
            {
                sheet.fillAmount += 1f / fillAmountSpeed * Time.deltaTime;
                bottomRung.transform.position = Vector3.Lerp(startPos, endPos, time);

            }
            else
            {
                bottomRung.transform.position = Vector3.Lerp(endPos, startPos, time);
                sheet.fillAmount -= 1f / fillAmountSpeed * Time.deltaTime;
            }
        }
    }
}
